using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckVisibility : MonoBehaviour
{
    public string specialAttackType;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    // Checks to see if specialAttackType is unlocked... if it is... show icon
    void Update()
    {
        if (!FunctionTracker.IsUnlocked(specialAttackType))
        {
            transform.localScale = new Vector3(0, 0, 0);
        } else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

}
