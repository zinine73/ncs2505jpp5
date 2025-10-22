using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    public float difficulty;
    GameManager gm;
    Button button;
    void Start()
    {
        gm = GameObject.Find("GameManager")
            .GetComponent<GameManager>();
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);
    }

    void SetDifficulty()
    {
        Debug.Log($"{gameObject.name} was clicked");
        gm.StartGame(difficulty);
    }
}
