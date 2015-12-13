﻿using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    private Vector2 velocity;
    public float smoothTimeY;
    public float smoothTimeX;

    public GameObject player;
   
    void Start()
    {
        //trouver le jouer
        player = GameObject.FindGameObjectWithTag("Player");

    }
    void FixedUpdate()
    {
        //pour changer la position de la camera 
        float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);
        float posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y, smoothTimeY);

        transform.position = new Vector3(posX, posY, transform.position.z);
    }
}
