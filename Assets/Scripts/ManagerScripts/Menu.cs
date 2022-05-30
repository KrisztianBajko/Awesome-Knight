using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    #region Public Fields

    #endregion

    #region Private Fields

    [SerializeField] private GameObject lightning;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioSource rainSource;
    [SerializeField] private AudioClip thunder;
    [SerializeField] private AudioClip openGate;
    [SerializeField] private AudioClip click;
    [SerializeField] private AudioClip hover;

    #endregion

    #region MonoBehaviour Callbacks
    void Start()
    {
        audioSource.Play();
        rainSource.Play();
        InvokeRepeating("SpawnLightnings", 5, 10);
    }

    #endregion

    #region Public Methods
    public void PlayGateSound()
    {
        audioSource.PlayOneShot(openGate);
    }
    public void PlayClickSound()
    {
        audioSource.PlayOneShot(click);
    }
    public void PlayeHoverSound()
    {
        audioSource.PlayOneShot(hover);
    }
    #endregion

    #region Private Methods
    private void SpawnLightnings()
    {
        float randomXPos = Random.Range(-4f, 4f);
        Vector3 spawnPos = new Vector3(randomXPos,-1.2f,-6f);
        audioSource.PlayOneShot(thunder);
        Instantiate(lightning, spawnPos, Quaternion.identity);
    }
    #endregion
}
