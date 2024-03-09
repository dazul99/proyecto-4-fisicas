using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    private UIManager ui;

    private bool gamestarted = false;

    private bool lost = false;

    private RotateCamera rotateCamera;
    private PlayerController playerController;
    private SpawnManager spawnManager;

    private PowerUp power;
    private Enemy enemy;
    private bool paused = false;
    public int defeated = 0;

    void Start()
    {
        ui = FindObjectOfType<UIManager>();
        rotateCamera = FindObjectOfType<RotateCamera>();
        playerController = FindObjectOfType<PlayerController>();
        spawnManager = FindObjectOfType<SpawnManager>();
        ui.Gotomenu();
    }

    public bool Hasgamestarted()
    {
        return gamestarted;
    }

    public void Startgame()
    {
        gamestarted = true;
        ui.Gamestart();
    }

    public void Gameover()
    {
        ui.Gameover(defeated);
        lost = true;
    }

    public void Restart()
    {
        rotateCamera.Restart();
        ui.Gamestart();
        playerController.Restart();
        Time.timeScale = 1;
        paused = false;
        lost = false;
        if (spawnManager.Thereispowerup())
        {
            DestroyPowerUp();
        }
        while (spawnManager.Thereisenemy())
        {
            Destroyenemy();
        }
        spawnManager.Restart();
    }

    private void DestroyPowerUp()
    {
        power = FindObjectOfType<PowerUp>();
        Destroy(power.gameObject);
    }

    private void Destroyenemy()
    {
        enemy = FindObjectOfType<Enemy>();
        Destroy(enemy.gameObject);
        spawnManager.EnemyDestroyed();
    }

    public void ReturnMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape) && gamestarted && !lost)
        {
            if (!paused)
            {
                PauseGame();
            }
            else
            {
                Unpause();
            }
        }
    }

    public void PauseGame()
    {
        paused = true;
        Time.timeScale = 0;
        ui.PauseGame();
    }

    public void Unpause()
    {
        paused = false;
        Time.timeScale = 1;
        ui.Resume();
    }

}