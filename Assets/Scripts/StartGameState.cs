using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameState : MonoBehaviour
{
    public bool IsStartGame = false;

    public static StartGameState instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = new StartGameState();
        } else if(instance == this){ 
            Destroy(gameObject);
        }
    }

    public void SetStartGame()
    {
        this.IsStartGame = true;
    }
    public void SetEndGame()
    {
        this.IsStartGame = false;
    }
}
