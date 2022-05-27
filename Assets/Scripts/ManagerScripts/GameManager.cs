using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip groundImpact;
    public AudioClip basicAttack;
    public AudioClip hit;
    public AudioClip shield;
    public AudioClip heal;
    public AudioClip thunder;
    public AudioClip tornado;
    public AudioClip lvlUp;
    public AudioClip playerDie;
    public GameObject pauseMenu;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;






        }
    }
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
}
