using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Carcamera : MonoBehaviour
{
    
    public GameObject camera;
    public GameObject player;
    // Start is called before the first frame update
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            camera.SetActive(true);
            Debug.Log("차 시점 인식");
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            camera.SetActive(false);
            player.SetActive(true);
            Debug.Log("차 시점 카메라 해제");

        }
    }
 
}
