using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingItem : MonoBehaviour
{
    public float speed = 1.0f;
    public float lifetime = 10;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") return;
        if (collision.GetComponent<ShootingAction>())
        {
            collision.GetComponent<ShootingAction>().Action();
        }
        Destroy(gameObject);
    }

    void Update()
    {
        //Debug.Log(lifetime);
        transform.Translate(transform.right * transform.localScale.x * speed * Time.deltaTime);
        lifetime=lifetime-1.0f*Time.deltaTime;
        if (lifetime <= 0) Destroy(gameObject);
    }
}
