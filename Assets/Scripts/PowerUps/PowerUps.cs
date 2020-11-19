using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    [SerializeField] PowerUp powerUp;

    [SerializeField] PowerUp BlowUp;
    [SerializeField] PowerUp Comet;
    [SerializeField] PowerUp BallGraber;
    [SerializeField] PowerUp ExpandExplosion;
    [SerializeField] PowerUp ExtraLife;
    [SerializeField] PowerUp Falling;
    [SerializeField] DoubleSpeed Faster;
    [SerializeField] PowerUp FinishLevel;
    [SerializeField] PowerUp Kill;
    [SerializeField] PowerUp Lasers;
    [SerializeField] PowerUp SlowBall;
    [SerializeField] PowerUp SmallBall;
    [SerializeField] PowerUp SmallerPaddle;
    [SerializeField] PowerUp WiderPaddle;
    [SerializeField] PowerUp SuperSmallPaddle;
    [SerializeField] PowerUp Thru;
    [SerializeField] PowerUp Zap;
    [SerializeField] PowerUp Split;

    [SerializeField] private int chance = 0;

    public void Launch(Vector2 position, Vector2 velocity)
    {
        chance++;
        if (Random.Range(0, 100) < chance)
        {
            DoubleSpeed powerup = Instantiate(Faster, new Vector3(position.x, position.y, 0f), Quaternion.identity);
            powerup.GetComponent<Rigidbody2D>().velocity = velocity / 2;
            chance = 0;
        }
    }

    public void TriggerEffect(string effect)
    {
        Debug.Log(effect);
    }
}
