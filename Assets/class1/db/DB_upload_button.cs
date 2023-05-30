using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DB_upload_button : MonoBehaviour
{
    [SerializeField]
    GameObject Content = null;
    [SerializeField]
    database database = null;
    [SerializeField]
    GameObject imageobj = null;
    [SerializeField]
    Sprite time1;
    [SerializeField]
    Sprite timetemp;

    Image canvasimage;

    public void DB_Up_load()
    {

        canvasimage = imageobj.GetComponent<Image>();
        canvasimage.sprite = time1;
        Transform[] childList = Content.GetComponentsInChildren<Transform>();
        if (childList != null)
        {
            for (int i = 1; i < childList.Length; i++)
            {
                if (childList[i] != transform)
                    Destroy(childList[i].gameObject);
            }
        }

        database.uploadDB();

    }
    public void DB_delete()
    {
        canvasimage = imageobj.GetComponent<Image>();
        canvasimage.sprite = timetemp;
        Transform[] childList = Content.GetComponentsInChildren<Transform>();
        if (childList != null)
        {
            for (int i = 1; i < childList.Length; i++)
            {
                if (childList[i] != transform)
                    Destroy(childList[i].gameObject);
            }
        }
    }
}
