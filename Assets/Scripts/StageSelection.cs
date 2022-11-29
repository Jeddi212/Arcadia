using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class StageSelection : MonoBehaviour
{

    public GameObject shopPanel;
    public TextMeshProUGUI inStockTMP;

    void Start()
    {
        if (shopPanel == null) Debug.LogError("The Shop Panel in -Canvas > StageSelection (Script)- is NULL");
        if (inStockTMP == null) Debug.LogError("The In Stock TMP in -Canvas > StageSelection (Script)- is NULL");

        shopPanel.SetActive(false);
    }

    void Update()
    {
        
    }

    public void ShopPanelOn()
    {
        shopPanel.SetActive(true);
    }

    public void ShopPanelOff()
    {
        shopPanel.SetActive(false);
    }

    // The number argument is
    // the index of scene loaded
    // in the build setting

    public void LoadStageD()
    {
        SceneManager.LoadScene(2);
    }
    
    public void LoadStageE()
    {
        SceneManager.LoadScene(3);
    }

    public void LoadStageJ()
    {
        SceneManager.LoadScene(4);
    }

    public void LoadStageT()
    {
        SceneManager.LoadScene(5);
    }
}
