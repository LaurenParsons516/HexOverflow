using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunctionTracker
{
    private static ISet<string> unlockFunctions = new HashSet<string>();

    // Unlocks specialAttackType
    public static void Unlock(string attackType)
    {
        unlockFunctions.Add(attackType);
    }

    // Checks if specialAttackType is unlocked
    public static bool IsUnlocked(string attackType)
    {
        return unlockFunctions.Contains(attackType);
    }
}
