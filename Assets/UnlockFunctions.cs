using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockFunctions : MonoBehaviour
{
    // Start is called before the first frame update
    // This sets the functions to unlocked when the green "U" button is pressed
    // This was purely used for testing... I wouldn't include this for a player to have
    void Start()
    {
        Button button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(() =>
        {
            FunctionTracker.Unlock("Fireball");
            FunctionTracker.Unlock("Bullet");
            FunctionTracker.Unlock("Wrench");
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
