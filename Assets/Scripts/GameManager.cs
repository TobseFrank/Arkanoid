using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public int score {get; set;}
    public int life{get; set;}
    public int ballsAlive {get; set;}

    [SerializeField]
    private TMP_Text scoreText;

    [SerializeField]
    private TMP_Text lifeText;
    [SerializeField]
    private TMP_Text gameOverText;

public static GameManager Instance
{
    get 
    {
        if(_instance is null)
            Debug.LogError("Game");

        return _instance;
    }
}

private void Awake() {
     _instance = this;
     life = 3;
     ballsAlive = 0;
     score = 0;
}

    private void Update() {
        scoreText.text = score + " Punkte";    
        lifeText.text = life + " Leben";

        if (life == 0) {
            gameOverText.text = "GAME OVER";
        } else {
            gameOverText.text = "";
        }

    }
}
