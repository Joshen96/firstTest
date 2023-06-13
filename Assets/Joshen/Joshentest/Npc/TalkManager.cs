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

        //외부 버스 안내 선배 

        talkData.Add(100, new string[] { "안녕 나는 이 학교 선배야 반갑다", "여기는 학교 입구인데 버스타고 학교로 들어가야해", "여기 바로 앞 버스정류장 보이지? ", "학교 셔틀버스 타고 학교 농구장으로 가봐","나랑 닮은 쌍둥이 동생이 마중 나가 있을꺼야" });
        lookData.Add(100, new Transform[] { target[0], target[0], target[1], target[0], target[0] });
        animData.Add(100, new string[] { "greeting", "lookingaround", "pointing", "talking1","idle" });

        talkData.Add(101, new string[] { "무사히 도착했구나 나는 아까 입구에서 본 선배의 동생이야", "여기는 학교 중심이고 농구장 앞 정류장이야", "너의 오른손을 밑으로 내리고 잡기 키를 누르면 너가 해야하는 일정을 확인할수있어","주변에 초록 포탈이나 파랑 포탈을 보면 교실로 들어갈 수 있을거야", "한번 확인하고 체험 할 것을 해봐" });
        lookData.Add(101, new Transform[] { target[0], target[2], target[0], target[4], target[0] });
        animData.Add(101, new string[] { "greeting", "lookingaround", "pointing","talking1", "fight" });

        //교실앞 착한 선배
        talkData.Add(110, new string[] { "안녕 동엽아 교수님은 만나보았니?", "저기 강의실 문 보이지 저기로 들어가서 인사드려", "교수님은 영어 못하면 실망하실 수 있으니 조심해!", "앞으로 너의 한학기 시간표도 있으니 게시판에서 확인해봐", "그럼 몸 조심해 아맞다 옆에 아트실은 <color=#FF0000> 절대! </color>들어가지마.... 뭔가있어.." });
        lookData.Add(110, new Transform[] { target[0], target[4], target[0], target[0], target[0] });
        animData.Add(110, new string[] { "greeting", "pointing", "talking1", "lookingaround", "talking1"});



        //아트실 나쁜선배

        talkData.Add(120, new string[] { "어어 너 일로와봐 너 처음보네? ㅋ", "야이 친구야 뭘 처다보니 죽고싶어? ㅎㅎ ", "내가 착한선배처럼 보이냐?", "옆에 지나다니는 고양이 랑 쥐새끼 잡아와라", "장난이고 ㅋㅋ 옆에 강의실에 꼭들어가라 지켜본다ㅋㅋ" });
        lookData.Add(120, new Transform[] { target[0], target[0], target[0], target[0], target[0] });
        animData.Add(120, new string[] { "greeting", "killyou", "onetwopunch", "talking1", "pointing" });


        //외부 경찰
        talkData.Add(200, new string[] { "학교 캠퍼스 내에 신고가 접수되었는데", "혹시 칼을 든 수상한 자가 보이면 알려주게나", "아니면 잡아오면 더욱 좋고", "그럼 수고하게나",});
        lookData.Add(200, new Transform[] { target[0], target[0], target[0], target[0] });
        animData.Add(200, new string[] { "talking1", "lookingaround", "fight", "greeting" });

        talkData.Add(201, new string[] { "범인을 검거까지 하다니 엄청나구만 ", "캠퍼스의 안전에 도움을 주었구나", "고생 많았네 조만간 표창장을 받으러 연락이 갈걸세 "});
        lookData.Add(201, new Transform[] { target[0], target[2],  target[0] });
        animData.Add(201, new string[] { "talking1", "lookingaround", "greeting" });


        //class 교수님
        talkData.Add(1000, new string[] { "거기 학생 신입생인가? ","여기가 인문계 강의실이네","지각을 하면 어쩌나 허허 ","얼른 저 문을 열고 들어가보게" });
        lookData.Add(1000, new Transform[] { target[0], target[1], target[0], target[2] });
        animData.Add(1000, new string[] { "greeting", "pointing", "lookingaround", "pointing" });

        talkData.Add(1001, new string[] { "지각을 한 벌로 칠판에 문제를 풀어보게", "다 풀면 저 앞 문으로 나오게" });
        lookData.Add(1001, new Transform[] { target[5], target[6]});
        animData.Add(1001, new string[] { "idle", "pointing" });


        talkData.Add(1002, new string[] { "이봐 학생 문제는 잘 풀었나?", "언어 실력이 형편없구만 ", "알파벳 부터 다시 배우게", "저기에 게시판 보이나? 저기서 시간표를 확인하고오게","그러고 제 2강의실에 가서 칠판에 문제도 풀어보게", "앞 문이 잠겨있으면 서랍속에 열쇠가 있을거야 열고 들어가게나" });
        lookData.Add(1002, new Transform[] { target[0], target[0], target[0], target[7] ,target[0],target[4]});
        animData.Add(1002, new string[] { "greeting", "jokepose", "mmakick", "pointing","talking1","pointing" });

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
