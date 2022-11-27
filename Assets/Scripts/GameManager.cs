using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{

    public TextMeshProUGUI scoreText;
    private ClosePanel closingPanel;
    private DataPersistance dataController;
    private int score;

    [SerializeField]
    public AudioClip fuelSound;
    public AudioClip gameOverSound;
    private AudioSource audioSource;

    void Start()
    {
        closingPanel = GameObject.Find("Canvas").GetComponent<ClosePanel>();
        dataController = GameObject.Find("Data").GetComponent<DataPersistance>();

        // Make sure the stage is running on start
        Time.timeScale = 1f;

        audioSource = GetComponent<AudioSource>();
        CheckAudioSource();

        if (scoreText == null) Debug.LogError("The score text in -game manager- is NULL");
        
        score = 0;
        UpdateScore(0);
    }

    void Update()
    {
        
    }

    private void CheckAudioSource()
    {
        if (audioSource == null)
        {
            Debug.LogError("Please add AudioSource component in GameManager Object");
        }
        else
        {
            audioSource.clip = fuelSound;
        }
    }

    public void PlayFuelSound()
    {
        audioSource.PlayOneShot(fuelSound);
    }

    public void PlayGameOverSound()
    {
        audioSource.PlayOneShot(gameOverSound);
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void EndOfStage()
    {
        // Do Something after the stage is finish
        // Save score, etc.
        dataController.SetHighscoreStage(GetCurrentStage(), score);
        dataController.SaveData();

        closingPanel.PanelOn(score, dataController.GetHighscore(GetCurrentStage()));
    }

    private string GetCurrentStage()
    {
        string res = "";

        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 2:
                res = "D";
                break;
            case 3:
                res = "E";
                break;
            case 4:
                res = "J";
                break;
            case 5:
                res = "T";
                break;
        }

        return res;
    }
}
