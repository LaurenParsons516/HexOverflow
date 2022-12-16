using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireworks : MonoBehaviour
{

    public GameObject fireworkPrefab;
    public Sprite[] sprites;
    private 

    // Start is called before the first frame update
    void Start()
    {
        // StartCoroutine(startFireworks());
    }
    /*
    IEnumerator startFireworks()
    {
        while (true)
        {
            StartCoroutine(spawnFirework());
            yield return new WaitForSeconds(0.5f);
        }
    }

    IEnumerator spawnFirework()
    {
        GameObject firework = Instantiate(fireworkPrefab) as GameObject;
        Vector3 position = firework.transform.position;
    }*/

    // Update is called once per frame
    void Update()
    {
        
    }
}
