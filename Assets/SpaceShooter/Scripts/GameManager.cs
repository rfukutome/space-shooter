using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public bool gameOver;
    public GameObject player;
    private UIManager _uiManager;
    private SpawnManager _spawnManager;
    // Use this for initialization
	void Start () {
        _uiManager = GameObject.FindObjectOfType<UIManager>();
        _spawnManager = GameObject.FindObjectOfType<SpawnManager>();
        gameOver = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (gameOver)
        {
            _uiManager.SetTitleScreen(true);
            _spawnManager.gameOver = true;
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

            foreach (GameObject enemy in enemies)
            {
                Destroy(enemy);
            }

            if (Input.GetButtonDown("Fire2"))
            {
                Instantiate(player);
                _uiManager.SetTitleScreen(false);
                _uiManager.ClearBoard();
                _spawnManager.gameOver = false;
                gameOver = false;
                _spawnManager.enabled = true;
            }
        }
	}

    public void SetGameOver()
    {
        gameOver = true;
    }
}
