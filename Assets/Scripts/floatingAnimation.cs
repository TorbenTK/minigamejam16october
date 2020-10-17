﻿using UnityEngine;

// Floater v0.0.2
// by Donovan Keith
//
// [MIT License](https://opensource.org/licenses/MIT)
public class floatingAnimation : MonoBehaviour
{
    // User Inputs
    public float degreesPerSecond = 15.0f;

    public float amplitude = 0.5f;
    public float frequency = 1f;

    // Position Storage Variables
    private Vector3 posOffset;

    private Vector3 tempPos;

    // Use this for initialization
    private void Start()
    {
        // Store the starting position & rotation of the object
        posOffset = transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        // Float up/down with a Sin()
        tempPos = posOffset;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;

        transform.position = tempPos;
    }
}