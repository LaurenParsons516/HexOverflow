using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerSceneChange : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(CheckDistance());
    }

    IEnumerator CheckDistance()
    {
        if (Vector3.Distance(Enemy.transform.position, Player.transform.position) < 25)
        {
            yield return new WaitForSeconds(2);
            SceneManager.LoadScene(2);
        }
    }
}
