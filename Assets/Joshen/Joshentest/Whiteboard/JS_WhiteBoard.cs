using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JS_WhiteBoard : MonoBehaviour
{
    public Texture2D texture; //그림그릴 텍스쳐 

    public Vector2 textureSize = new Vector2(2048, 2048);  //텍스쳐 사이즈
    Renderer r;
    void Start()
    {
        r = GetComponent<Renderer>(); 
        texture = new Texture2D((int)textureSize.x, (int)textureSize.y);
        r.material.mainTexture = texture;
    }


    public void ResetDrawing() //그림초기화 함수
    {
        texture = new Texture2D((int)textureSize.x, (int)textureSize.y);
        r.material.mainTexture = texture;
    }
}
