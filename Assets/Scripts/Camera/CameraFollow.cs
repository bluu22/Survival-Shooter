﻿using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public Transform target;
    public float smoothing = 5f;

    Vector3 offset;
    PlayerHealth playerHealth;

    void Start()
    {
        playerHealth = target.GetComponent<PlayerHealth>();
        offset = transform.position - target.position;
    }

    void FixedUpdate()
    {
        if (playerHealth.currentHealth > 0)
        {
            Vector3 targetCamPos = target.position + offset;
            transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
        }
    }



}
