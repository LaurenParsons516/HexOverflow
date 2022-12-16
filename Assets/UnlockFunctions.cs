using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockFunctions : MonoBehaviour
{
    // Start is called before the first frame update
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
