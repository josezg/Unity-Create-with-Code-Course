using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DifficultyButton : MonoBehaviour
{
    private Button button;
    private GameManager _gameManager;
    public int difficulty;// Easy: 1, Medium : 2, Hard : 3
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    void SetDifficulty()
    {
        _gameManager.StartGame(difficulty);
    }
}
