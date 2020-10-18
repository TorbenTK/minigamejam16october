using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReleaseMouse : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }
}