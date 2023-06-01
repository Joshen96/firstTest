using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    static Dictionary<int, Transform[]> lookData;
    Dictionary<int, string[]> animData;
    //public Camera Playercam;
    
    public Transform[] target;

    
    private void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        lookData = new Dictionary<int, Transform[]>();
        animData = new Dictionary<int, string[]>();
        GernerateData();
        

    }

    void GernerateData()
    {   
        //class 교수님
        talkData.Add(1000, new string[] { "거기 학생 신입생인가?","여기는 강의실인데","오늘은 수업이없는데?","저 문을 열고 들어가보게" });
        lookData.Add(1000, new Transform[] { target[0], target[1], target[0], target[2] });
        animData.Add(1000, new string[] { "greeting", "pointing", "lookingaround", "pointing" });


        talkData.Add(1001, new string[] { "이봐 학생 문제는 잘 풀었나?", "언어 실력이 형편없구만 ", "알파벳 부터 다시 배우게", "인문계쪽은 실력없으니 이공계 강의실로 가봐" });
        lookData.Add(1001, new Transform[] { target[0], target[0], target[0], target[2] });
        animData.Add(1001, new string[] { "greeting", "jokepose", "mmakick", "pointing" });

        /*
        talkData.Add(2000, new string[] { "안녕?","여기는 교실1이에요","문을 열어봐요" ,"춤추기하하","문열어","빨리!"});
        lookData.Add(2000, new Transform[] { target[], target[], target[] , target[], target[] });
        animData.Add(2000, new string[] {"greeting","pointing","pointing","dancing","pointing","pointing" });

        talkData.Add(2001, new string[] { "저문을 열어봣군","너!" ,"잘했어" });
        lookData.Add(2001, new Transform[] { target[], target[], target[(int)]});
        animData.Add(2001, new string[] { "pointing", "dancing", "greeting" });


        

        talkData.Add(3000, new string[] { "안녕?","여기는 교실1이에요","낄낄" });
        lookData.Add(3000, new Transform[] { target[0], target[1] });
        */
        talkData.Add(9999, new string[] { "대화오류", "입니다." });
        lookData.Add(9999, new Transform[] { target[0], target[0] });
        animData.Add(9999, new string[] { "greeting", "pointing" });
        
    }

    public string GetTalk(int _id, int _talkIdex)
    {

        if (!talkData.ContainsKey(_id))
        {
            _id = 9999;
        }

        if (_talkIdex == talkData[_id].Length)
            return null;
        else
            return talkData[_id][_talkIdex];
    }
    public Transform GetLook(int _id, int _lookIdex)
    {
        if (!lookData.ContainsKey(_id))
        {
            _id = 9999;
        }

        if (_lookIdex == lookData[_id].Length)
        {
            
            return null;
        }
        else
            return lookData[_id][_lookIdex];
    }
    public string GetAnim(int _id, int _animIdex)
    {
        if (!animData.ContainsKey(_id))
        {
            _id = 9999;
        }

        if (_animIdex == animData[_id].Length)
        {
            return "null";

        }
        else
            return animData[_id][_animIdex];
    }

}
