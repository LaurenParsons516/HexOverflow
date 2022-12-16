using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunctionTracker
{
    private static ISet<string> unlockFunctions = new HashSet<string>();

    public static void Unlock(string attackType)
    {
        unlockFunctions.Add(attackType);
    }

    public static bool IsUnlocked(string attackType)
    {
        return unlockFunctions.Contains(attackType);
    }
}
