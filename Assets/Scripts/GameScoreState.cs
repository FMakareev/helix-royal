using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScoreState : MonoBehaviour
{
    public int score = 0;
    public static GameScoreState instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = new GameScoreState();
        } else if(instance == this){ 
            Destroy(gameObject);
        }
    }
    
    public void IncrementCount()
    {
        score += 1;
    }
    public void Reset()
    {
        score = 0;
    }
}
