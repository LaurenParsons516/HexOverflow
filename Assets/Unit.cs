using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public System.Action<int> healthChange;

    public string unitName;
    public int unitLevel;

    public int damage;

    public int maxHP;
    public int currentHP;

    // Lowers HP to take damage
    public bool TakeDamage(int damage)
    {
        currentHP -= damage;
        if (healthChange != null)
        {
            healthChange.Invoke(currentHP);
        }

        if (currentHP <= 0)
        {
            return true;
        } else
        {
            return false;
        }
    }

    // Raises HP to heal
    public void Heal(int amount)
    {
        currentHP += amount;
        if (healthChange != null)
        {
            healthChange.Invoke(currentHP);
        }

        if (currentHP > maxHP)
        {
            currentHP = maxHP;
        }
    }

    public virtual void onDamage()
    {

    }
}
