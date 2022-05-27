using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPointer : MonoBehaviour
{
    public Transform player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
   

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, player.position)<= 1.3f)
        {
            Destroy(gameObject);
        }
    }
}
