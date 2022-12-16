using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialAttack : MonoBehaviour
{

    public GameObject caster;
    public GameObject target;
    public Unit victim;

    public int damageAmount;

    float t;
    public float timeToReachTarget = 2.5f;

    void Start()
    {
    }

    void Update()
    {
        t += Time.deltaTime / timeToReachTarget;
        transform.position = Vector3.Lerp(transform.position, target.transform.position, t);

        if (Vector3.Distance(transform.position, target.transform.position) == 0)
        {
            victim.TakeDamage(damageAmount);

            gameObject.SetActive(false);
        }
    }
}
