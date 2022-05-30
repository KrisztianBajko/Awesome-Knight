using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    #region Public Fields


    #endregion

    #region Private Fields
    [SerializeField] private float followHeight = 8f;
    [SerializeField] private float followDistance = 6f;

    private Transform player;
    private float targetHeight;
    private float currentHeight;
    private float currentRotation;

    #endregion

    #region MonoBehaviour Callbacks
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        FollowPlayer();



    }

    #endregion

    #region Public Methods

    #endregion

    #region Private Methods

    private void FollowPlayer()
    {
        targetHeight = player.position.y + followHeight;

        currentRotation = transform.eulerAngles.y;

        currentHeight = Mathf.Lerp(transform.position.y, targetHeight, 0.9f * Time.deltaTime);

        Quaternion euler = Quaternion.Euler(0f, currentRotation, 0f);

        Vector3 targetPosition = player.position - (euler * Vector3.forward) * followDistance;

        targetPosition.y = currentHeight;

        transform.position = targetPosition;
        transform.LookAt(player);
    }

    #endregion
}
