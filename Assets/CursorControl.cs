using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorControl : MonoBehaviour
{

    public static bool gameisactive;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameisactive)
        {
            Cursor.visible = false;
        }
        else
        {
            Cursor.visible = true;
        }

        

    }
}
