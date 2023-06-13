using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JS_startMain_scene : MonoBehaviour
{
   public void StartScene()
    {
        LodingSceneController.LoadScene("JS_outside");
        
    }
}
