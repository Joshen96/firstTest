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
        talkData.Add(1000, new string[] { "�ȳ�?","����� ����̿���" });
        talkData.Add(2000, new string[] { "�ȳ�?","����� ����1�̿���","����" });
        talkData.Add(3000, new string[] { "�ȳ�?","����� ����1�̿���","����" });
        
        
    }

    public string GetTalk(int _id, int _talkIdex)
    {
        if (_talkIdex == talkData[_id].Length)
            return null;
        else
            return talkData[_id][_talkIdex];
    }
}
