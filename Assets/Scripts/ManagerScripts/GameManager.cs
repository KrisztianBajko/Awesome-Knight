using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    #region Public Fields

    #endregion

    #region Private Fields
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip groundImpact;
    [SerializeField] private AudioClip basicAttack;
    [SerializeField] private AudioClip hit;
    [SerializeField] private AudioClip shield;
    [SerializeField] private AudioClip heal;
    [SerializeField] private AudioClip thunder;
    [SerializeField] private AudioClip tornado;
    [SerializeField] private AudioClip lvlUp;
    [SerializeField] private AudioClip playerDie;
    [SerializeField] private GameObject pauseMenu;

    #endregion

    #region MonoBehaviour Callbacks
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }

    #endregion

    #region Public Mehtods
    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void BackToGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
    public void PlayerDie()
    {
        audioSource.PlayOneShot(playerDie);
    }
    public void LevelUp()
    {
        audioSource.PlayOneShot(lvlUp);
    }
    public void GroundImpactSound()
    {
        audioSource.PlayOneShot(groundImpact);
    }
    public void HitSound()
    {
        audioSource.PlayOneShot(hit);
    }
    public void FireShieldSound()
    {
        audioSource.PlayOneShot(shield);
    }
    public void FireTornadoSound()
    {
        audioSource.PlayOneShot(tornado);
    }
    public void HealSound()
    {
        audioSource.PlayOneShot(heal);
    }
    public void ThunderSound()
    {
        audioSource.PlayOneShot(thunder);
    }
    public void BasicAttackSound()
    {
        audioSource.PlayOneShot(basicAttack);
    }
    #endregion

    #region Private Mehtods

    #endregion
}
