﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //determines how fast the camera moves back to the player
    public float resetSpeed=0.5f;

    //speed of the camera
    public float cameraSpeed=0.3f;

    public Bounds cameraBounds;

    //will be the player- will use the player's transform to follow the player
    //because transform will give us the position of where the players currently is
    private Transform target;


    private float offsetZ;
    private Vector3 lastTargetPosition;
    private Vector3 currentVelocity;

    private bool followsPlayer;


    void Awake()
    {
     //make sure size of bounds are correct
     BoxCollider2D myCol= GetComponent<BoxCollider2D>();
        myCol.size= new Vector2(Camera.main.aspect * 2f * Camera.main.orthographicSize, 15f);
        cameraBounds = myCol.bounds;

    }

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;


        lastTargetPosition= target.position;
        offsetZ= (transform.position - target.position).z;
        followsPlayer=true;
            
    }

    void FixedUpdate()
    {
       // if(target.position.x >=8f)
           // {
        if(followsPlayer && target.position.x >= 8) 
            {
            Vector3 aheadTargetPos= target.position + Vector3.forward * offsetZ;

            if(aheadTargetPos.x >= transform.position.x)
                {
                Vector3 newCameraPosition = Vector3.SmoothDamp (transform.position, aheadTargetPos, ref currentVelocity, cameraSpeed);

                //transform.position = new Vector3(newCameraPosition.x, newCameraPosition.y, transform.position.z);

                transform.position = new Vector3(newCameraPosition.x, newCameraPosition.y, newCameraPosition.z);

                //transform.position = new Vector3(newCameraPosition.x, transform.position.y, newCameraPosition.z);

                lastTargetPosition= target.position;
                //    }
            }

            if((aheadTargetPos.x <= transform.position.x)&& target.position.x >17)
            {
                Vector3 newCameraPosition= Vector3.SmoothDamp(transform.position, aheadTargetPos, ref currentVelocity, cameraSpeed);
                transform.position = new Vector3(newCameraPosition.x, newCameraPosition.y, newCameraPosition.z);
                lastTargetPosition = target.position;
            }
        }
    }




}//ends class
