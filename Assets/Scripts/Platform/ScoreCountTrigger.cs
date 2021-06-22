using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCountTrigger : MonoBehaviour
{
    [SerializeField] private GameViewUI _gameViewUI;


    private void Start()
    {
        _gameViewUI = FindObjectOfType<GameViewUI>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Player>())
        {
            GameScoreState.instance.IncrementCount();
            _gameViewUI.SetCount(GameScoreState.instance.score);
        }
    }
}
