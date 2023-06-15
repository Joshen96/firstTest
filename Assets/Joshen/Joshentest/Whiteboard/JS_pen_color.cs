using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JS_pen_color : MonoBehaviour
{
    MeshRenderer tipRenderer;

    [SerializeField]
    Material[] colors;

    int number = 0;
    private void Awake()
    {
        tipRenderer = GetComponent<MeshRenderer>();

        //Debug.Log(colors.Length);
    }
    
   public void tset() //ÆæÃË ¹Ù²Ù´Â ÇÔ¼ö
    {
        if(number<colors.Length-1)
        {
            number++;
        }
        else
        {
            number = 0;
        }
        tipRenderer.material = colors[number];
       
       // Debug.Log("»§¾ß");
    }
}
