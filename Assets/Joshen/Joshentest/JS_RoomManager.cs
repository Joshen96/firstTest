using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JS_RoomManager : MonoBehaviour
{
     // 각 씬마다 있어야함!!
    [SerializeField]
    public static int doorNumber = 0; //내가들어왔던 넘버를 받아오는곳
    GameObject player;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player"); 
       
        
    }

    void Start()
    {
        GameObject[] enters = GameObject.FindGameObjectsWithTag("Spawn_zone");  //exit 태그 오브젝트

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
                
                player.transform.position = new Vector3(x, y, z); //이때 이동후 플레이어 위치 정해짐
                break;
            }

        }

    }

    public static void ChangeScene(string sceneName, int doorNum) //원하는 문의 위치로 가기위해 doorNum
    {
        doorNumber = doorNum;
        // SceneManager.LoadScene(sceneName);
        LodingSceneController.LoadScene(sceneName); //로딩창 + 함수와 다음씬 이름을 가져감
        //Debug.Log(doorNumber);
    }

  
}
