using System.Collections;
using System.Collections.Generic;
using UnityEditor.EditorTools;
using UnityEngine;

public enum ExitDirection //���̵��� �տ� �������� �ڿ� �������� 
{
    front,
    back,

}

public class JS_exit : MonoBehaviour
{
    public string sceneName = ""; // �̵��� ���̸�
    public int doorNumber = 0;  // ���Ż���ΰ�������
    public ExitDirection direction = ExitDirection.front; //�յ� ����



    private void OnTriggerEnter(Collider _other)
    {
        if(_other.gameObject.tag == "Player")
        {

            JS_RoomManager.ChangeScene(sceneName, doorNumber); //���̵�
        }
        
    }
}
