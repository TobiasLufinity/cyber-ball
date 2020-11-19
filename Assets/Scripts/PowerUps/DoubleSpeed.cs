using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleSpeed: PowerUp
{
    
    public void TriggerEffect()
    {
        GameSession gameSession = FindObjectOfType<GameSession>();
        gameSession.SetGameSpeed(gameSession.GetGameSpeed() * 2);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            boxCollider.isTrigger = false;
        }
        else if (collision.gameObject.name == "Paddle")
        {
            TriggerEffect();
            Destroy(gameObject);
        }
    }

}
