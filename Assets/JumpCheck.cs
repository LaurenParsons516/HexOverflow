using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCheck : MonoBehaviour
{
    public Movement playerMove;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    // Checks if player is jumping... if so... play fire animation
    void Update()
    {
        if (playerMove.onGround)
        {
            transform.localScale = new Vector3(0, 0, 0);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
