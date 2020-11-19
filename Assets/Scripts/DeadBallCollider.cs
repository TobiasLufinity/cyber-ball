﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadBallCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            SceneManager.LoadScene("Game Over");
        } 
        else if (collision.gameObject.CompareTag("PowerUp"))
        {
            Destroy(collision.gameObject);
        }
    }
}
