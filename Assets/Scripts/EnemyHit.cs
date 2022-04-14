using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    public float cooldown = 1.0f;
    private float currCooldown;
    private bool cooldownCountdown = false;

    private void Start()
    {
        currCooldown = cooldown;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player"&&!cooldownCountdown)
        {
            cooldownCountdown = true;
            FindObjectOfType<LivesCounter>().LoseLife();
        }
    }
    private void Update()
    {
        if (cooldownCountdown)
        {
            currCooldown = currCooldown - 1.0f * Time.deltaTime;
            if (currCooldown <= 0)
            {
                cooldownCountdown = false;
                currCooldown = cooldown;
            }
        }
    }
}
