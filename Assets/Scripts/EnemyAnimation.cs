using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    private Rigidbody2D _body;
    private Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        _animator.SetFloat("velocity", 1.0f);
    }
}
