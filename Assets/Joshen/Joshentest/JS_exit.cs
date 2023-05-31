using System.Collections;
using System.Collections.Generic;
using UnityEditor.EditorTools;
using UnityEngine;

public enum ExitDirection //씬이동시 앞에 생성할지 뒤에 생성할지 
{
    front_blue,
    back_red,
    left_yellow,
    right_green

}

public class JS_exit : MonoBehaviour
{
    public string sceneName = ""; // 이동할 씬이름
    public int doorNumber = 0;  // 어떤포탈으로갈것인지
    public ExitDirection direction = ExitDirection.front_blue; //앞뒤 선택



    private void OnTriggerEnter(Collider _other)
    {
        if(_other.gameObject.tag == "Player")
        {

            JS_RoomManager.ChangeScene(sceneName, doorNumber); //씬이동
        }
        
    }
}
