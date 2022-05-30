using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPointer : MonoBehaviour
{
    #region Public Fields

    #endregion

    #region Private Fields
    private Transform player;
    #endregion

    #region MonoBehaviour Callbacks
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
   

    // Update is called once per frame
    private void Update()
    {
        if(Vector3.Distance(transform.position, player.position)<= 1.3f)
        {
            Destroy(gameObject);
        }
    }

    #endregion

    #region Public Methods

    #endregion

    #region Private Methods

    #endregion
}
