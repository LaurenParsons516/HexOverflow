using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MakePref : MonoBehaviour
{
    public string specialAttackType;
    public GameObject player;
    public Text notif;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Unlocks specialAttackType to allow player to use it later in battle
    private void OnTriggerEnter2D(Collider2D other)
    {
        StartCoroutine(TriggerText());
        gameObject.transform.localScale = new Vector3(0, 0, 0);
        gameObject.transform.GetChild(0).gameObject.transform.localScale = new Vector3(0, 0, 0);
        FunctionTracker.Unlock(specialAttackType);
        Debug.Log("Pref set " + specialAttackType);
        
    }

    // Notifies player which function they collected and that they can use it later in battle
    IEnumerator TriggerText()
    {
        notif.text = "You've collected the " + specialAttackType + " function!\nYou can use this function later in battle.";
        yield return new WaitForSeconds(3);
        notif.text = "";
    }
}
