using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    #region Public Fields

    #endregion

    #region Private Fields
    [SerializeField] private Animator animator;
    [SerializeField] private Menu menu;

    #endregion

    #region MonoBehaviour Callbacks

    #endregion

    #region Public Methods
    public void OnClick()
    {
        menu.PlayClickSound();
    }
    public void OnHover()
    {
        menu.PlayeHoverSound();
    }
    public void StartGame()
    {
        animator.SetBool("Fade", true);
        

    }
    public void GateSound()
    {
        menu.PlayGateSound();
    }
    public void LaunchGame()
    {
        SceneManager.LoadSceneAsync(1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    #endregion

    #region Private Mehtods

    #endregion


}
