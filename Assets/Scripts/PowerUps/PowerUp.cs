using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{

    protected Rigidbody2D rb2D;
    protected BoxCollider2D boxCollider;
    protected SpriteRenderer spriteRenderer;

    private void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        boxCollider = gameObject.GetComponent<BoxCollider2D>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        //rb2D.velocity = new Vector2(3f, 5f);
    }

    public void SetSprite(Sprite sprite)
    {
        spriteRenderer.sprite = sprite;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        boxCollider.isTrigger = true;
    }
}
