using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{

    public void Enable()
    {
        Cursor.visible = true;
    }
    public void Disable()
    {
        Cursor.visible = false;
    }
}
