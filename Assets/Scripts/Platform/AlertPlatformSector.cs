using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertPlatformSector : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<Player>())
        {
            StartGameState.instance.SetEndGame();
            FindObjectOfType<GameViewUI>().Hide();
            FindObjectOfType<EndGameViewUI>().Show();
            FindObjectOfType<EndGameViewUI>().SetCount(GameScoreState.instance.score);
        }
    }
}
