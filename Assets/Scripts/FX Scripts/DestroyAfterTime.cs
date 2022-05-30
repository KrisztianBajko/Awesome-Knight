using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    #region Public Fields

    #endregion

    #region Private Fields
    [SerializeField] private float timer;

    #endregion

    #region MonoBehaviour Callbacks
    private void Start()
    {
        Destroy(gameObject, timer);
    }
    #endregion

    #region Public Methods

    #endregion

    #region Private Methods

    #endregion

}
