using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    public Sprite[] life_images;
    public Image lifeImageDisplay;
    public GameObject titleScreen;
    public int score = 0;
    public Text scoreText;

    public void UpdateLives(int argCurrentLives)
    {
        lifeImageDisplay.sprite = life_images[argCurrentLives]; 
    }

    public void UpdateScore()
    {
        score += 10;
        scoreText.text = "Score : " + score;
    }

    public void SetTitleScreen(bool argState)
    {
        titleScreen.SetActive(argState);
    }

    public void ClearBoard()
    {
        score = 0;
        scoreText.text = "Score : " + score;
    }
}
