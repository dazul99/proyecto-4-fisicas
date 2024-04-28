using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    [SerializeField] private GameObject pause;
    [SerializeField] private GameObject mainmenu;
    [SerializeField] private GameObject gameover;

    [SerializeField] private Button resume;
    [SerializeField] private Button restartpause;

    [SerializeField] private Button start;

    [SerializeField] private Button menu;
    [SerializeField] private Button restartover;

    [SerializeField] private Button load;
    [SerializeField] private Button save;

    private GameManager gameManager;

    [SerializeField] private TextMeshProUGUI defeat;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        start.onClick.AddListener(gameManager.Startgame);
        restartover.onClick.AddListener(gameManager.Restart);
        menu.onClick.AddListener(gameManager.ReturnMainMenu);
        restartpause.onClick.AddListener(gameManager.Restart);
        resume.onClick.AddListener(gameManager.Unpause);
        load.onClick.AddListener(gameManager.Loadgame);
        save.onClick.AddListener(gameManager.Savegame);
    }

    private void Hidepause()
    {
        pause.SetActive(false);
    }

    private void Showpause()
    {
        pause.SetActive(true);
    }

    private void Showmainmenu()
    {
        mainmenu.SetActive(true);
    }

    private void Hidemainmenu()
    {
        mainmenu.SetActive(false);
    }

    private void Hidegameover()
    {
        gameover.SetActive(false);
    }

    private void Showgameover(int x)
    {
        gameover.SetActive(true);
        defeat.text = "Enemies defeated: " + x;
    }

    public void Gamestart()
    {
        Hidemainmenu();
        Hidepause();
        Hidegameover();
    }

    public void Gotomenu()
    {
        Hidegameover();
        Hidepause();
        Showmainmenu();
    }

    public void Gameover(int x)
    {
        Hidepause() ;
        Showgameover(x);
    }

    public void PauseGame()
    {
        Showpause();
    }

    public void Resume()
    {
        Hidepause();
    }

}
