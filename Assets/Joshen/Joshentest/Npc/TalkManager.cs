using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    static Dictionary<int, Transform[]> lookData;

    
    public Transform[] target; 

    private void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        lookData = new Dictionary<int, Transform[]>();
        GernerateData();

    }

    void GernerateData()
    {
        talkData.Add(1000, new string[] { "안녕?","여기는 운동장이에요" });
        lookData.Add(1000, new Transform[] { target[0], target[1] });
        talkData.Add(2000, new string[] { "안녕?","여기는 교실1이에요","문을 열어봐요" });
        lookData.Add(2000, new Transform[] { target[2], target[3], target[4] });
        talkData.Add(3000, new string[] { "안녕?","여기는 교실1이에요","낄낄" });
        lookData.Add(3000, new Transform[] { target[0], target[1] });


    }

    public string GetTalk(int _id, int _talkIdex)
    {
        if (_talkIdex == talkData[_id].Length)
            return null;
        else
            return talkData[_id][_talkIdex];
    }
    public Transform GetLook(int _id, int _lookIdex)
    {
        if(_lookIdex == lookData[_id].Length)
        {
            return null;
        }
        else
            return lookData[_id][_lookIdex];
    }

}
