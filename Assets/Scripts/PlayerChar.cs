using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChar : MonoBehaviour
{
    public float speed = 750.0f;
    public float jumpForce = 12.0f;
    private bool facingRight = true;
    private Rigidbody2D _body;
    private CapsuleCollider2D _collider;
    private Animator _animator;

    void Start()
    {
        _body = GetComponent<Rigidbody2D>();
        _collider = GetComponent<CapsuleCollider2D>();
        _animator = GetComponent<Animator>();
        gameObject.tag = "Player";
    }

    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        Vector2 movement = new Vector2(deltaX, _body.velocity.y);
        _body.velocity = movement;
        if ((Input.GetAxis("Horizontal") > 0)&& (!facingRight)) //sprite flipping based on direction
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            facingRight = true;
        }
        else if ((Input.GetAxis("Horizontal")<0) && (facingRight))
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            facingRight = false;
        }
        _animator.SetFloat("velocity", Mathf.Abs(_body.velocity.x));

        if ((Input.GetKeyDown(KeyCode.UpArrow)) || (Input.GetKeyDown(KeyCode.W))) TryJump();
    }

    void TryJump()
    {
        Vector3 max = _collider.bounds.max;  //ground collision check code
        Vector3 min = _collider.bounds.min;
        Vector2 corner1 = new Vector2(max.x, min.y - .1f);
        Vector2 corner2 = new Vector2(min.x, min.y - .2f);
        Collider2D hit = Physics2D.OverlapArea(corner1, corner2);   //
        bool grounded = false;
        if (hit != null)    //ground collision check
        {
            grounded = true;
        }
        if (grounded) _body.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);  //jump
    }
}
