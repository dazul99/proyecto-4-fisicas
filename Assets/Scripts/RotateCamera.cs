using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    private float rotationSpeed = 30f;
    private float horizontalInput;
    private bool started = false;
    private bool gameover = false;

    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if (!started)
        {
            started = gameManager.Hasgamestarted();
        }
        else if (!gameover)
        {
            horizontalInput = Input.GetAxis("Horizontal");
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime * horizontalInput);
        }
        
    }

    public void Over()
    {
        gameover = true;
    }

    public void Restart()
    {
        gameover = false;
    }

}
