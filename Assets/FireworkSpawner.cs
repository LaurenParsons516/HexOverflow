using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireworkSpawner : MonoBehaviour
{

    public GameObject fireworkPrefab;
    public Sprite[] sprites;
    private

    void Start()
    {
        StartCoroutine(startFireworks());
    }
    
    IEnumerator startFireworks()
    {
        while (gameObject.activeSelf)
        {
            GameObject firework = Instantiate(fireworkPrefab) as GameObject;
            Vector3 position = firework.transform.position;
            position.x += Random.Range(1, 23);
            firework.transform.position = position;
            yield return new WaitForSeconds(0.5f);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
