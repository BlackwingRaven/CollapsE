using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]

public class EnemyAI : MonoBehaviour
{
    public List<Transform> points;
    public int nextPoint = 0;
    public float moveSpeed = 200.0f;
    private int pointStep = 1;
    public bool facingRight=false;

    void Start()
    {
        gameObject.tag = "Enemy";
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        Transform goalPoint = points[nextPoint];
        if (goalPoint.transform.position.x > transform.position.x && !facingRight)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            facingRight = !facingRight;
        }
        else if (goalPoint.transform.position.x <= transform.position.x && facingRight)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            facingRight = !facingRight;
        }
        transform.position = Vector2.MoveTowards(transform.position, goalPoint.position, moveSpeed * Time.deltaTime);
        if (Vector2.Distance(transform.position, goalPoint.position) < 1f)
        {
            nextPoint = nextPoint + pointStep;
            if (nextPoint == 0 || nextPoint == points.Count - 1)
            {
                pointStep = pointStep * -1;
            }
        }
    }

    private void Reset()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
        GameObject root = new GameObject(name + "_Root");
        root.transform.position = transform.position;
        transform.SetParent(root.transform);
        transform.position = root.transform.position;
        GameObject waypoits = new GameObject("Waypoints");
        waypoits.transform.SetParent(root.transform);
        waypoits.transform.position = root.transform.position;
        GameObject p1 = new GameObject("Point1");
        p1.transform.SetParent(waypoits.transform);
        p1.transform.position = root.transform.position;
        GameObject p2 = new GameObject("Point2");
        p2.transform.SetParent(waypoits.transform);
        p2.transform.position = root.transform.position;
        points = new List<Transform>();
        points.Add(p1.transform);
        points.Add(p2.transform);
    }
}
