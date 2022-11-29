using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class StageSelection : MonoBehaviour
{

    public GameObject shopPanel;
    public TextMeshProUGUI moneyTMP;
    public TextMeshProUGUI inStockTMP;
    public TextMeshProUGUI healthCartTMP;
    private int healthCart = 0;
    private int healthPrice = 10;
    private DataPersistance dataController;

    void Start()
    {
        if (shopPanel == null) Debug.LogError("The Shop Panel in -Canvas > StageSelection (Script)- is NULL");
        if (moneyTMP == null) Debug.LogError("The Money TMP in -Canvas > StageSelection (Script)- is NULL");
        if (inStockTMP == null) Debug.LogError("The In Stock TMP in -Canvas > StageSelection (Script)- is NULL");
        if (healthCartTMP == null) Debug.LogError("The Health Cart TMP in -Canvas > StageSelection (Script)- is NULL");

        dataController = GameObject.Find("Data").GetComponent<DataPersistance>();

        shopPanel.SetActive(false);
    }

    void Update()
    {
        
    }

    private void UpdateInStockTMP()
    {
        inStockTMP.text = "In stock : " + dataController.GetHealthPowerUp();
    }

    private void UpdateMoneyTMP()
    {
        moneyTMP.text = dataController.GetMoney().ToString();
    }

    public void ShopPanelOn()
    {
        shopPanel.SetActive(true);

        UpdateMoneyTMP();
        UpdateInStockTMP();
    }

    public void ShopPanelOff()
    {
        dataController.SaveData();
        shopPanel.SetActive(false);
    }

    public void IncrementHealth()
    {
        if (((healthPrice * (healthCart + 1))) <= dataController.GetMoney())
        {
            healthCart += 1;
            healthCartTMP.text = healthCart + "x";
        }
    }

    public void DecrementHealth()
    {
        if (healthCart > 0)
        {
            healthCart -= 1;
            healthCartTMP.text = healthCart + "x";
        }
    }

    public void Buy()
    {
        dataController.SetHealthPowerUp(dataController.GetHealthPowerUp() + healthCart);
        UpdateInStockTMP();

        dataController.SetMoney(dataController.GetMoney() - (healthCart * healthPrice));
        UpdateMoneyTMP();

        healthCart = 0;
        healthCartTMP.text = healthCart + "x";
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
