using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RememberUserData
{
    private static string name;

    public static void SetName(string value)
    {
        name = value;
    }

    public static string Name
    {
        get { return name; }
    }
}
