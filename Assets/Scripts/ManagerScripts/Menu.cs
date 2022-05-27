using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject lightning;
    public AudioSource audioSource;
    public AudioSource rainSource;
    public AudioClip thunder;
    public AudioClip openGate;
    public AudioClip click;
    public AudioClip hover;
    void Start()
    {
        audioSource.Play();
        rainSource.Play();
        InvokeRepeating("SpawnLightnings", 5, 10);
    }
   public void PlayGateSound()
    {
        audioSource.PlayOneShot(openGate);
    }
    void SpawnLightnings()
    {
        float randomXPos = Random.Range(-4f, 4f);
        Vector3 spawnPos = new Vector3(randomXPos,-1.2f,-6f);
        audioSource.PlayOneShot(thunder);
        Instantiate(lightning, spawnPos, Quaternion.identity);
    }
    public void PlayClickSound()
    {
        audioSource.PlayOneShot(click);
    }
    public void PlayeHoverSound()
    {
        audioSource.PlayOneShot(hover);
    }
}
