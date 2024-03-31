using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform targetPlayer;

    private Vector3 offset;

    

 

    void Start()
    {
        targetPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        //offset = targetPlayer.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = targetPlayer.position + new Vector3(0,1,-5);
    }
}
