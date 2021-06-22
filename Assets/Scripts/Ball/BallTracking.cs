using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class BallTracking : MonoBehaviour
{
    [SerializeField] private Vector3 _directionOffset;
    [SerializeField] private float _length = 0f;
    [SerializeField] private Player _ball;
    [SerializeField] private Beam _beam;

    [SerializeField] private Vector3 _cameraPosition;
    [SerializeField] private Vector3 _minimumBallPosition;
    
    public void Setup()
    {
        _ball = FindObjectOfType<Player>();
        _beam = FindObjectOfType<Beam>();

        _cameraPosition = _ball.transform.position;
        _minimumBallPosition = _ball.transform.position;

        Track();
    }
    
    private void FixedUpdate()
    {
        if (!_ball || !_beam)
        {
            return;
        }
        Track();
        _minimumBallPosition = _ball.transform.position;
    }
    
    private void Track()
    {
        Vector3 beamPosition = _beam.transform.position;
        beamPosition.y = _ball.transform.position.y;
        
        _cameraPosition = _ball.transform.position;

        Vector3 direction = (beamPosition - _ball.transform.position).normalized + _directionOffset;

        _cameraPosition -= direction * _length;
        
        transform.position = _cameraPosition;
        transform.LookAt(_ball.transform);
    }
}