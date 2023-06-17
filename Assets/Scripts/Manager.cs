using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Manager
{
    public static float myScore = 0;
    public static int combo = 0;
    public static bool isFever = false;
    public static float hp = 3000;

    public static void InitializeManager()
    {
        myScore = 0;
        isFever = false;
        hp = 3000;
        combo = 0;
    }

}
