using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public GameObject gameOverText;
    public GameObject titleScreen;
    public bool isGameActive;
    public Button restartButton;
    public Slider slider;
    float spawnRate = 1.0f;
    int score;
    int lives;
    void Start()
    {
        GameOver(false);
    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    public void CreateTarget(Vector3 pos)
    {
        int index = Random.Range(0, targets.Count);
        Instantiate(targets[index]).GetComponent<Target>().SetPosition(pos);
    }
    
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = $"Score : {score}";
    }

    public void UpdateLives(int liveToSub)
    {
        lives -= liveToSub;
        livesText.text = $"Lives : {lives}";
        if (lives <= 0)
        {
            GameOver(true);
        }
    }
    
    public void GameOver(bool value)
    {
        isGameActive = !value;
        gameOverText.SetActive(value);
        restartButton.gameObject.SetActive(value);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(
            SceneManager.GetActiveScene().name);
    }

    public void StartGame(float difficulty)
    {
        spawnRate = difficulty;
        StartCoroutine(SpawnTarget());
        score = 0;
        UpdateScore(0);
        lives = 3;
        UpdateLives(0);
        titleScreen.SetActive(false);
    }
    
    public void OnChangeSlide()
    {
        // volume
        Debug.Log(slider.value);
    }
}
