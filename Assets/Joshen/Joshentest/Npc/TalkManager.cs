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

        //외부 선배 

        talkData.Add(100, new string[] { "안녕 나는 이 학교 선배야 반갑다", "여기는 학교 입구인데 버스타고 학교로 들어가야해", "저기 버스정류장 보이지?", "학교 셔틀버스 타고 학교 농구장으로 가봐","나랑 닮은 쌍둥이 동생이 마중 나가 있을꺼야" });
        lookData.Add(100, new Transform[] { target[0], target[0], target[1], target[0], target[0] });
        animData.Add(100, new string[] { "greeting", "lookingaround", "pointing", "talking1","idle" });

        talkData.Add(101, new string[] { "무사히 도착했구나 나는 아까 입구에서 본 선배의 동생이야", "여기는 학교 중심이고 농구장 앞 정류장이야", "저쪽 방면에는 강의실 이야 ", "농구장에 여러가지 체험할것을 해봐!" });
        lookData.Add(101, new Transform[] { target[0], target[2], target[4], target[2] });
        animData.Add(101, new string[] { "greeting", "lookingaround", "pointing", "fight" });



        //class 교수님
        talkData.Add(1000, new string[] { "거기 학생 신입생인가?","여기는 강의실인데","오늘은 수업이없는데?","저 문을 열고 들어가보게" });
        lookData.Add(1000, new Transform[] { target[0], target[1], target[0], target[2] });
        animData.Add(1000, new string[] { "greeting", "pointing", "lookingaround", "pointing" });

        talkData.Add(1001, new string[] { "온김에 칠판에 문제를 풀어보게나", "다 풀면 저 앞 문으로 나오게" });
        lookData.Add(1001, new Transform[] { target[5], target[6]});
        animData.Add(1001, new string[] { "idle", "pointing" });


        talkData.Add(1002, new string[] { "이봐 학생 문제는 잘 풀었나?", "언어 실력이 형편없구만 ", "알파벳 부터 다시 배우게", "인문계쪽은 실력없으니 이공계 강의실로 가봐" });
        lookData.Add(1002, new Transform[] { target[0], target[3], target[4], target[3] });
        animData.Add(1002, new string[] { "greeting", "jokepose", "mmakick", "pointing" });

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
