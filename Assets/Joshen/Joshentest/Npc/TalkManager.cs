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

    enum Targetname
    {
        player = 0,
        class1,
        door,
        busstop,
        playground

    };
    Targetname name = Targetname.player;

    private void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        lookData = new Dictionary<int, Transform[]>();
        animData = new Dictionary<int, string[]>();
        GernerateData();
        

    }

    void GernerateData()
    {
        talkData.Add(1000, new string[] { "�ȳ�?","����� ����̿���" });
        lookData.Add(1000, new Transform[] { target[(int)Targetname.player], target[(int)Targetname.playground] });
        animData.Add(1000, new string[] { "greeting", "pointing", "pointing", "dancing", "pointing", "idle" });


        talkData.Add(2000, new string[] { "�ȳ�?","����� ����1�̿���","���� �������" ,"���߱�����","������","����!"});
        lookData.Add(2000, new Transform[] { target[(int)Targetname.player], target[(int)Targetname.class1], target[(int)Targetname.door] , target[(int)Targetname.player], target[(int)Targetname.door] });
        animData.Add(2000, new string[] {"greeting","pointing","pointing","dancing","pointing","pointing" });

        talkData.Add(2001, new string[] { "������ ����f��","��!" ,"���߾�" });
        lookData.Add(2001, new Transform[] { target[(int)Targetname.door], target[(int)Targetname.player], target[(int)Targetname.player]});
        animData.Add(2001, new string[] { "pointing", "dancing", "greeting" });




        talkData.Add(3000, new string[] { "�ȳ�?","����� ����1�̿���","����" });
        lookData.Add(3000, new Transform[] { target[0], target[1] });

        talkData.Add(9999, new string[] { "��ȭ����", "�Դϴ�." });
        lookData.Add(9999, new Transform[] { target[(int)Targetname.player], target[(int)Targetname.player] });
        animData.Add(9999, new string[] { "greeting", "pointing" });

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

        
        if (_lookIdex == lookData[_id].Length)
        {
            
            return null;
        }
        else
            return lookData[_id][_lookIdex];
    }
    public string GetAnim(int _id, int _animIdex)
    {

        if (_animIdex == animData[_id].Length)
        {
            return "null";

        }
        else
            return animData[_id][_animIdex];
    }

}
