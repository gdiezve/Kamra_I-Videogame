using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public Player player;
    public GameObject gameOverMenuUI;
    public GameObject playerObject;
    public GameObject grid;
    public GameObject scenery;
    public GameObject enemy;

    // Update is called once per frame
    void Update()
    {
        if (player.isDead)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        gameOverMenuUI.SetActive(true);
        playerObject.SetActive(false);
        grid.SetActive(false);
        scenery.SetActive(false);
        enemy.SetActive(false);
        Time.timeScale = 0f;
    }

    public void RestartButton ()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitButton ()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
