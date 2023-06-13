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

        //�ܺ� ���� �ȳ� ���� 

        talkData.Add(100, new string[] { "�ȳ� ���� �� �б� ����� �ݰ���", "����� �б� �Ա��ε� ����Ÿ�� �б��� ������", "���� �ٷ� �� ���������� ������? ", "�б� ��Ʋ���� Ÿ�� �б� �������� ����","���� ���� �ֵ��� ������ ���� ���� ��������" });
        lookData.Add(100, new Transform[] { target[0], target[0], target[1], target[0], target[0] });
        animData.Add(100, new string[] { "greeting", "lookingaround", "pointing", "talking1","idle" });

        talkData.Add(101, new string[] { "������ �����߱��� ���� �Ʊ� �Ա����� �� ������ �����̾�", "����� �б� �߽��̰� ���� �� �������̾�", "���� �������� ������ ������ ��� Ű�� ������ �ʰ� �ؾ��ϴ� ������ Ȯ���Ҽ��־�","�ֺ��� �ʷ� ��Ż�̳� �Ķ� ��Ż�� ���� ���Ƿ� �� �� �����ž�", "�ѹ� Ȯ���ϰ� ü�� �� ���� �غ�" });
        lookData.Add(101, new Transform[] { target[0], target[2], target[0], target[4], target[0] });
        animData.Add(101, new string[] { "greeting", "lookingaround", "pointing","talking1", "fight" });

        //���Ǿ� ���� ����
        talkData.Add(110, new string[] { "�ȳ� ������ �������� �������Ҵ�?", "���� ���ǽ� �� ������ ����� ���� �λ���", "�������� ���� ���ϸ� �Ǹ��Ͻ� �� ������ ������!", "������ ���� ���б� �ð�ǥ�� ������ �Խ��ǿ��� Ȯ���غ�", "�׷� �� ������ �Ƹ´� ���� ��Ʈ���� <color=#FF0000> ����! </color>������.... �����־�.." });
        lookData.Add(110, new Transform[] { target[0], target[4], target[0], target[0], target[0] });
        animData.Add(110, new string[] { "greeting", "pointing", "talking1", "lookingaround", "talking1"});



        //��Ʈ�� ���ۼ���

        talkData.Add(120, new string[] { "��� �� �Ϸοͺ� �� ó������? ��", "���� ģ���� �� ó�ٺ��� �װ�;�? ���� ", "���� ���Ѽ���ó�� ���̳�?", "���� �����ٴϴ� ����� �� ����� ��ƿͶ�", "�峭�̰� ���� ���� ���ǽǿ� ������ ���Ѻ��٤���" });
        lookData.Add(120, new Transform[] { target[0], target[0], target[0], target[0], target[0] });
        animData.Add(120, new string[] { "greeting", "killyou", "onetwopunch", "talking1", "pointing" });


        //�ܺ� ����
        talkData.Add(200, new string[] { "�б� ķ�۽� ���� �Ű� �����Ǿ��µ�", "Ȥ�� Į�� �� ������ �ڰ� ���̸� �˷��ְԳ�", "�ƴϸ� ��ƿ��� ���� ����", "�׷� �����ϰԳ�",});
        lookData.Add(200, new Transform[] { target[0], target[0], target[0], target[0] });
        animData.Add(200, new string[] { "talking1", "lookingaround", "fight", "greeting" });

        talkData.Add(201, new string[] { "������ �˰ű��� �ϴٴ� ��û������ ", "ķ�۽��� ������ ������ �־�����", "��� ���ҳ� ������ ǥâ���� ������ ������ ���ɼ� "});
        lookData.Add(201, new Transform[] { target[0], target[2],  target[0] });
        animData.Add(201, new string[] { "talking1", "lookingaround", "greeting" });


        //class ������
        talkData.Add(1000, new string[] { "�ű� �л� ���Ի��ΰ�? ","���Ⱑ �ι��� ���ǽ��̳�","������ �ϸ� ��¼�� ���� ","�� �� ���� ���� ������" });
        lookData.Add(1000, new Transform[] { target[0], target[1], target[0], target[2] });
        animData.Add(1000, new string[] { "greeting", "pointing", "lookingaround", "pointing" });

        talkData.Add(1001, new string[] { "������ �� ���� ĥ�ǿ� ������ Ǯ���", "�� Ǯ�� �� �� ������ ������" });
        lookData.Add(1001, new Transform[] { target[5], target[6]});
        animData.Add(1001, new string[] { "idle", "pointing" });


        talkData.Add(1002, new string[] { "�̺� �л� ������ �� Ǯ����?", "��� �Ƿ��� ��������� ", "���ĺ� ���� �ٽ� ����", "���⿡ �Խ��� ���̳�? ���⼭ �ð�ǥ�� Ȯ���ϰ����","�׷��� �� 2���ǽǿ� ���� ĥ�ǿ� ������ Ǯ���", "�� ���� ��������� �����ӿ� ���谡 �����ž� ���� ���Գ�" });
        lookData.Add(1002, new Transform[] { target[0], target[0], target[0], target[7] ,target[0],target[4]});
        animData.Add(1002, new string[] { "greeting", "jokepose", "mmakick", "pointing","talking1","pointing" });

        /*
        talkData.Add(2000, new string[] { "�ȳ�?","����� ����1�̿���","���� �������" ,"���߱�����","������","����!"});
        lookData.Add(2000, new Transform[] { target[], target[], target[] , target[], target[] });
        animData.Add(2000, new string[] {"greeting","pointing","pointing","dancing","pointing","pointing" });

        talkData.Add(2001, new string[] { "������ ����f��","��!" ,"���߾�" });
        lookData.Add(2001, new Transform[] { target[], target[], target[(int)]});
        animData.Add(2001, new string[] { "pointing", "dancing", "greeting" });


        

        talkData.Add(3000, new string[] { "�ȳ�?","����� ����1�̿���","����" });
        lookData.Add(3000, new Transform[] { target[0], target[1] });
        */
        talkData.Add(9999, new string[] { "��ȭ����", "�Դϴ�." });
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
