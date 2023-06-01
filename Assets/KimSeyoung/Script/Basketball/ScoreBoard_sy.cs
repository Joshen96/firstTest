using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoard_sy : MonoBehaviour
{
    [SerializeField] private string scoreStr = "";

    private GameObject[] NumberGO = null;

    private void Awake()
    {
        for (int i = 0; i < 10; i++)
        {
            NumberGO[i] = Resources.Load<GameObject>("ScoreNumbers/" + i.ToString());
            // meshs[i] = Resources.Load<Mesh>("ScoreNumbers/"+ i.ToString());
        }
    }

    public void ScoreMeshChange()
    {
        char[] scoreChar = scoreStr.ToCharArray();          // string score >> char score array

        for (int i = 0; i < scoreChar.Length; i++)          // meshº¯°æ
        {
            int num = (int)scoreChar[i];
            transform.GetChild(2+i).gameObject.GetComponent<MeshFilter>().mesh = NumberGO[num].GetComponent<MeshFilter>().mesh;
        }
    }
}
