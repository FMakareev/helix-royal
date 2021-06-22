using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBallJump : MonoBehaviour
{
    [SerializeField]
    private BallJump ballJump;
    
    
    void Start()
    {
        ballJump = GetComponent<BallJump>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
