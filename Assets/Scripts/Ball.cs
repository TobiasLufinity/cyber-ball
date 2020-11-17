using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    [SerializeField] Paddle paddle;
    [SerializeField] float launchForce = 10.0f;
    [SerializeField] AudioClip bounceAudioClip;
    [SerializeField] AudioClip hitAudioClip;

    private AudioSource soundSource;
    private Vector2 ballToPaddleDifference;
    private Rigidbody2D rb2D;
    private bool inPlay = false;

    // Start is called before the first frame update
    void Start()
    {
        ballToPaddleDifference = transform.position - paddle.transform.position;
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        soundSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!inPlay)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        transform.position = paddlePos + ballToPaddleDifference;
    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            inPlay = true;
            rb2D.AddForce(transform.up * launchForce, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (inPlay)
        {
            if (collision.gameObject.name.Contains("Block"))
            {
                soundSource.volume = 0.5f;
                soundSource.PlayOneShot(hitAudioClip);
            } else
            {
                soundSource.volume = 1.0f;
                soundSource.PlayOneShot(bounceAudioClip);
            }
            if (collision.gameObject.name == "Paddle")
            {
                ContactPoint2D contact = collision.contacts[0];
                Quaternion rotation = Quaternion.FromToRotation(Vector3.up, contact.normal);
                Vector3 position = contact.point;
                float impact = position.x;
                float paddlePosX = paddle.transform.position.x;
                // Impact Paddle is a range from -1 to 1
                float impactOnPaddle = Mathf.Clamp(impact - paddlePosX, -1f, 1f);
                // Force x and y is between -10 and 10
                float newXVelocity = Mathf.Clamp(10 * impactOnPaddle, -10f, 10f);
                rb2D.velocity = new Vector2(newXVelocity, rb2D.velocity.y);
                rb2D.velocity = rb2D.velocity.normalized * 10;

            }
        }
    }
}
