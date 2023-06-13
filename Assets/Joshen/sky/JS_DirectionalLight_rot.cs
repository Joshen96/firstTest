using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JS_DirectionalLight_rot : MonoBehaviour
{
    [SerializeField]
    float speed = 1f;

    float degree;
    private void Update()
    {
        {
            degree += Time.deltaTime*speed;

            if (degree >= 360)
                degree = 0;



            this.gameObject.transform.rotation =Quaternion.Euler(0, -degree, 0);
        }
    }
}
