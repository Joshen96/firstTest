using System.Collections;
using System.Collections.Generic;
using UnityEditor.EditorTools;
using UnityEngine;

public enum ExitDirection
{
    front,
    back,

}

public class JS_exit : MonoBehaviour
{
    public string sceneName = "";
    public int doorNumber = 0;
    public ExitDirection direction = ExitDirection.front;



    private void OnTriggerEnter(Collider _other)
    {
        if(_other.gameObject.tag == "Player")
        {

            JS_RoomManager.ChangeScene(sceneName, doorNumber);
        }
        
    }
}
