using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Animator animator;
    public Menu menu;

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
  
  
}
