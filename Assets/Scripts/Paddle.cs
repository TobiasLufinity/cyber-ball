using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{

    [SerializeField] float sceneWidthInUnits = 16f;
    [SerializeField] bool selfPlay = false;

    private Ball ball;

    // Start is called before the first frame update
    void Start()
    {
        ball = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!selfPlay)
        {
            float mousePosX = Input.mousePosition.x / Screen.width * sceneWidthInUnits;
            mousePosX = Mathf.Clamp(mousePosX, 1, 15);
            Vector2 paddlePos = new Vector2(mousePosX, transform.position.y);

            transform.position = paddlePos;
        } else if (ball.IsInPlay())
        {
            float newXPos = Random.Range(ball.transform.position.x - 0.5f, ball.transform.position.x + 0.5f);
            transform.position = new Vector2(newXPos, transform.position.y);
        }
    }
}
