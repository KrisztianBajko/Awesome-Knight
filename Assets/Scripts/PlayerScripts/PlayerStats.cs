using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    public Image expImg;
    public TextMeshProUGUI levelText;
    public float exp;
    public float expToNextLevel;
    public int level;
    public float expMultiplayer;
    public TextMeshProUGUI expBarExp;
    public GameManager gameManager;
    private void Update()
    {
        
        DisplayExpAndLevel();
        HandleExp();
    }
    public void Exp(float expAmount)
    {
        exp += expAmount;
        expImg.fillAmount = exp / expToNextLevel;
    }
    void HandleExp()
    {
        if (exp >= expToNextLevel)
        {
            gameManager.LevelUp();
            exp = 0f;
            expToNextLevel += 100 * expMultiplayer;
            expImg.fillAmount = 0;
            expMultiplayer += 0.1f;
            level++;
            
        }
    }
    void DisplayExpAndLevel()
    {
        levelText.text = level.ToString();
        expImg.fillAmount = exp / expToNextLevel;
        expBarExp.text = exp + "/" + expToNextLevel;
    }
}
