using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public AnimationCurve myCurve;

    // Update is called once per frame
    // Currently not in use
    void Update()
    {
        transform.position = new Vector3(transform.position.x, myCurve.Evaluate((Time.time % myCurve.length)), transform.position.z);
        
    }
}
