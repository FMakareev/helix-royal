using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishPlatformTrigger : MonoBehaviour
{

    [SerializeField]
    private bool _isFinished = false;
    private void OnDisable()
    {
        _isFinished = false;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (_isFinished)
        {
            return;
        }
        if (other.gameObject.GetComponent<Player>())
        {
            _isFinished = true;
            StartGameState.instance.SetEndGame();
            FindObjectOfType<GameViewUI>().Hide();
            FindObjectOfType<EndGameViewUI>().Show();
            FindObjectOfType<EndGameViewUI>().SetCount(GameScoreState.instance.score);
        }
    }
}