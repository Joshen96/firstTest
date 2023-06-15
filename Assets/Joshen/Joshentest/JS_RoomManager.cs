using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JS_RoomManager : MonoBehaviour
{
     // �� ������ �־����!!
    [SerializeField]
    public static int doorNumber = 0; //�������Դ� �ѹ��� �޾ƿ��°�
    GameObject player;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player"); 
       
        
    }

    void Start()
    {
        GameObject[] enters = GameObject.FindGameObjectsWithTag("Spawn_zone");  //exit �±� ������Ʈ

        for (int i = 0; i < enters.Length; i++)
        {
            GameObject doorObj = enters[i];
            JS_exit exit = doorObj.GetComponent<JS_exit>();
            if (doorNumber == exit.doorNumber)
            {
                float x = doorObj.transform.position.x;
                float y = doorObj.transform.position.y; 
                float z = doorObj.transform.position.z;
                
                

                if (exit.direction == ExitDirection.front_blue)
                {
                    z += 3;
                }
                else if (exit.direction == ExitDirection.back_red)
                {
                    z -= 3;
                }
                if (exit.direction == ExitDirection.left_yellow)
                {
                    x -= 3;
                }
                else if (exit.direction == ExitDirection.right_green)
                {
                    x += 3;
                }


                y -=0.4f;
                
                player.transform.position = new Vector3(x, y, z); //�̶� �̵��� �÷��̾� ��ġ ������
                break;
            }

        }

    }

    public static void ChangeScene(string sceneName, int doorNum) //���ϴ� ���� ��ġ�� �������� doorNum
    {
        doorNumber = doorNum;
        // SceneManager.LoadScene(sceneName);
        LodingSceneController.LoadScene(sceneName); //�ε�â + �Լ��� ������ �̸��� ������
        //Debug.Log(doorNumber);
    }

  
}
