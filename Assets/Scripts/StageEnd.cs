using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageEnd : MonoBehaviour
{
    AudioSource audioSource;
    private GameManager gameManager;
    private PauseMenu pauseMenu;

    private int loopSentinel = 0;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null) Debug.LogError("Audio source in -Music Object- is NULL");

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        pauseMenu = GameObject.Find("Canvas").GetComponent<PauseMenu>();
    }

    void Update()
    {
        LoseCondition();
    }

    private void LoseCondition()
    {
        // The stage is finish
        if (!audioSource.isPlaying && !pauseMenu.GetIsPaused() && loopSentinel < 1)
        {
            loopSentinel++;
            gameManager.EndOfStage();
        }
    }
}
