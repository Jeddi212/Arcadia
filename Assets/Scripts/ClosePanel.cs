using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ClosePanel : MonoBehaviour
{
    public GameObject closingPanel;
    public TextMeshProUGUI finalScore;
    private PauseMenu pauseMenu;
    private GameManager gameManager;
    private UniversalAudio universalAudio;

    void Start()
    {
        if (closingPanel == null) Debug.LogError("The Closing Panel in -Canvas > closePanel (Script)- is NULL");
        if (finalScore == null) Debug.LogError("The Final Score in -Canvas > closePanel (Script)- is NULL");

        closingPanel.SetActive(false);

        pauseMenu = GameObject.Find("Canvas").GetComponent<PauseMenu>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        universalAudio = GameObject.Find("Data").GetComponent<UniversalAudio>();
    }

    void Update()
    {
        
    }

    public void PanelOn(int fScore, int highscore)
    {
        closingPanel.SetActive(true);
        Time.timeScale = 0f;
        finalScore.text = "Score : " + fScore + "\nHighscore : " + highscore;

        pauseMenu.PauseAudio();
        gameManager.PlayGameOverSound();
    }

    public void PanelOff()
    {
        Time.timeScale = 1f;
        universalAudio.PlayButtonSFX();
        closingPanel.SetActive(false);
    }

    public void RestartStage()
    {
        PanelOff();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void BackToSelection()
    {
        PanelOff();
        SceneManager.LoadScene(1);
    }
}
