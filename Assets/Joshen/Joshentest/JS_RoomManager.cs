using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JS_RoomManager : MonoBehaviour
{

    [SerializeField]
    public static int doorNumber = 0;

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
                
                

                if (exit.direction == ExitDirection.front)
                {
                    z += 3;
                }
                else if (exit.direction == ExitDirection.back)
                {
                    z -= 3;
                }
                
                GameObject player = GameObject.FindGameObjectWithTag("Player");
                player.transform.position = new Vector3(x, y, z);
                break;
            }

        }

    }

    public static void ChangeScene(string sceneName, int doorNum) //원하는 문의 위치로 가기위해 doorNum
    {
        doorNumber = doorNum;
        SceneManager.LoadScene(sceneName);
        Debug.Log(doorNumber);
    }

  
}
