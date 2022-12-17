using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerFall : MonoBehaviour
{
    public GameObject player;
    public Camera camera1;

        // Start is called before the first frame update
        void Start()
    {
        
    }

    void Update()
    {
        // Checks to see if player is 50 units away from camera... if so load gameover scene
        if (camera1.transform.position.y > player.transform.position.y + 50)
        {
            SceneManager.LoadScene(3);
        }
    }
}

