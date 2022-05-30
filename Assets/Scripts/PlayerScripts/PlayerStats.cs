using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    #region Public Fields
    public int level;
    #endregion

    #region Private Fields
    [SerializeField] private Image expImg;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private float exp;
    [SerializeField] private float expToNextLevel;
    [SerializeField] private float expMultiplayer;
    [SerializeField] private TextMeshProUGUI expBarExp;
    [SerializeField] private GameManager gameManager;

    #endregion

    #region MonoBehaviour Callbacks
    private void Update()
    {
        
        DisplayExpAndLevel();
        HandleExp();
    }

    #endregion

    #region Public Methods
    public void Exp(float expAmount)
    {
        exp += expAmount;
        expImg.fillAmount = exp / expToNextLevel;
    }
    #endregion

    #region Private Methods

    private void HandleExp()
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
    private void DisplayExpAndLevel()
    {
        levelText.text = level.ToString();
        expImg.fillAmount = exp / expToNextLevel;
        expBarExp.text = exp + "/" + expToNextLevel;
    }

    #endregion
}
