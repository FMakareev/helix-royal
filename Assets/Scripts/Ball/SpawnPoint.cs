using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private Player _ball;
    [SerializeField] private Player _instantiateBall;


    private void Awake()
    {
        SpawnBall();
    }

    public void SpawnBall()
    {
        _instantiateBall = Instantiate(_ball, transform.position, Quaternion.identity);
    }

    public void DestroyBall()
    {
        if (!_instantiateBall)
        {
            return;
        }
        GameObject.Destroy(_instantiateBall.gameObject);
    }

    private void OnDestroy()
    {
        DestroyBall();
    }
}
