using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JS_WhiteBoard : MonoBehaviour
{
    public Texture2D texture;

    public Vector2 textureSize = new Vector2(2048, 2048);
    Renderer r;
    void Start()
    {
        r = GetComponent<Renderer>();
        texture = new Texture2D((int)textureSize.x, (int)textureSize.y);
        r.material.mainTexture = texture;
    }


    public void ResetDrawing()
    {
        texture = new Texture2D((int)textureSize.x, (int)textureSize.y);
        r.material.mainTexture = texture;
    }
}
