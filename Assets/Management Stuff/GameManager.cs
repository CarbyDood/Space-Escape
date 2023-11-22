using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false; 
    }

    private void OnApplicationFocus(bool focusStatus) 
    {
        if(focusStatus)
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = false; 
        }
        
        else
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true; 
    }
}
