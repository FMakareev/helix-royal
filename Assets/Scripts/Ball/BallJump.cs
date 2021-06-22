using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BallJump : MonoBehaviour
{
    [SerializeField] private float _speed = 70f;
    [SerializeField] private float _jumpForce = 1f;
    [SerializeField] private Beam _beam;

    [SerializeField] private float _moveVelocity = 1f;

    [SerializeField] private bool _bot = false;

    private Rigidbody _rigidBody;


    private void Awake()
    {
        if (!_beam)
        {
            _beam = FindObjectOfType<Beam>();
        }
    }

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {

        if (_bot)
        {
            return;
        }
        if (!StartGameState.instance.IsStartGame)
        {
            return;
        }

        float dir = _moveVelocity;

        if (Input.GetAxis("Horizontal") != 0)
        {
            dir = Input.GetAxis("Horizontal");
        }

        if (!_beam)
        {
            return;
        }

        Move(dir);

    }

    public void Move(float dir)
    {
        _moveVelocity = dir;
        transform.RotateAround(_beam.transform.position, Vector3.up, dir * _speed * Time.deltaTime);
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        _rigidBody.velocity = Vector3.zero;
        _rigidBody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
    }
}