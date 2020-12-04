using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIHandler : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject Creds;
    public GameObject Exit;
    public GameObject PauseScr;
    public GameObject InGame;
    public GameManager gMan;
    public GameObject MenuAd;
    public GameObject GameAd;
    public GameObject PauseAd;
    public GameObject DieAd;
    public GameObject gOver;
    public TextMeshProUGUI scoretext;
    public TextMeshProUGUI scoretext2;
    public TextMeshProUGUI hscoretext;

    // Start is called before the first frame update
    public void Start()
    {
        gMan.PlayerShip.SetActive(true);
        Time.timeScale = 1;
        hscoretext.text = "High Score: " + PlayerPrefs.GetInt("HS", 0);
        PurgeUI();
        MainMenu.SetActive(true);
        MenuAd.SetActive(true);
        gMan.GameplayActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        scoretext.text = "Score: " + gMan.score;
        scoretext2.text = "Score: " + gMan.score;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gMan.GameplayActive)
            {
                PauseMenu();
            }
            else
            {
                ExitDiag();
            }
        }

    }

    void PurgeUI()
    {
        Exit.SetActive(false);
        MainMenu.SetActive(false);
        Creds.SetActive(false);
        PauseScr.SetActive(false);
        InGame.SetActive(false);
        GameAd.SetActive(false);
        MenuAd.SetActive(false);
        PauseAd.SetActive(false);
        gOver.SetActive(false);
        DieAd.SetActive(false);
    }

    public void ExitDiag()
    {
        PurgeUI();
        Exit.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Credits()
    {
        PurgeUI();
        Creds.SetActive(true);
        PauseAd.SetActive(true);
    }

    public void BeginPlay()
    {
        PurgeUI();
        InGame.SetActive(true);
        gMan.GameplayActive = true;
        gMan.StartCoroutine(gMan.SpawnLoop());
        GameAd.SetActive(true);
    }
    public void PauseMenu()
    {
        PurgeUI();
        PauseScr.SetActive(true);
        Time.timeScale = 0;
        PauseAd.SetActive(true);
    }
    public void UnPause()
    {
        PurgeUI();
        InGame.SetActive(true);
        Time.timeScale = 1;
    }

    public void gameOver()
    {
        PurgeUI();
        DieAd.SetActive(true);
        gMan.PlayerShip.SetActive(false);
        Time.timeScale = 0;
        if (gMan.score > PlayerPrefs.GetInt("HS"))
        {
            PlayerPrefs.SetInt("HS", gMan.score);
        }
        gMan.StopCoroutine(gMan.SpawnLoop());
        gOver.SetActive(true);
        PauseAd.SetActive(true);
    }

    public void respawn()
    {
        SceneManager.LoadScene(0);
    }

    public void supprtus()
    {
        Application.OpenURL("https://ko-fi.com/theaidency");
    }
}
