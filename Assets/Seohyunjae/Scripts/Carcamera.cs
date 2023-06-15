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
    
       
        if (Input.GetKeyDown(KeyCode.D) && Caruiclick.carin_bool)
        {
            Caruiclick.carin_bool = false;
            camera.SetActive(false);
           
            player.transform.position = this.gameObject.transform.position + new Vector3(-2f, 1f, 0);
            player.SetActive(true);
           // Debug.Log("차 시점 카메라 해제");

        }
    }
 
}
