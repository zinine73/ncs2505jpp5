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
    public GameObject gameOverText;
    public GameObject titleScreen;
    public bool isGameActive;
    public Button restartButton;
    float spawnRate = 1.0f;
    int score;
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

    public void CreatTarget(Vector3 pos)
    {
        int index = Random.Range(0, targets.Count);
        Instantiate(targets[index]).GetComponent<Target>().SetPosition(pos);
    }
    
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = $"Score : {score}";
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
        titleScreen.SetActive(false);
    }
}
