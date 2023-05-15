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
        talkData.Add(1000, new string[] { "안녕?","여기는 운동장이에요" });
        talkData.Add(2000, new string[] { "안녕?","여기는 교실1이에요","낄낄" });
        talkData.Add(3000, new string[] { "안녕?","여기는 교실1이에요","낄낄" });
        
        
    }

    public string GetTalk(int _id, int _talkIdex)
    {
        if (_talkIdex == talkData[_id].Length)
            return null;
        else
            return talkData[_id][_talkIdex];
    }
}
