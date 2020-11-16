using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

    [SerializeField] AudioClip destroySound;

    private Level level;
    private GameSession gameStatus;

    private void Start()
    {
        level = FindObjectOfType<Level>();
        gameStatus = FindObjectOfType<GameSession>();
        level.AddBlock();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        level.BlockDestroyed();
        gameStatus.AddToScore(1);
        AudioSource.PlayClipAtPoint(destroySound, Camera.main.transform.position, 1.0f);
        Destroy(gameObject);
    }
}
