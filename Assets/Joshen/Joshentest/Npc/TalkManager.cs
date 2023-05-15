using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;

    private void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        GernerateData();
    }

    void GernerateData()
    {
        talkData.Add(1000, new string[] { "�ȳ�? ����� ����̿���" });
    }

    public string GetTalk(int _id, int _talkIdex)
    {
        return talkData[_id][_talkIdex];
    }
}
