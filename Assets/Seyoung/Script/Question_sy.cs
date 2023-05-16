using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// QuestionText에 들어가는 스크립트

public class Question_sy : MonoBehaviour
{
    public string ClassName = null; 
    // 강의실 이름에 따라 나오는 문제 다르게 설정할 예정
    // 플레이어가 강의실에 들어갔을 때 해당 강의실 이름 받아오는 코드 작성 필요
    // 강의실마다 태그를 달거라면 태그로 코드 변경 필요

    public int questionNum = 12345;
    [SerializeField] private TextMeshProUGUI tmp = null;

    void Start()
    {
        if (tmp == null)
        { Debug.LogError("QuestionText 인스펙터에 안넣었어!!!"); return; }
    }

    void Update()
    {
        if (ClassName == "인문계강의실")
        {
            if (questionNum == 12345) questionNum = Random.Range(0, 2);
            SetQuestion_Humanities();
        }

        else if (ClassName == "이공계강의실")
        {
            if (questionNum == 12345) questionNum = Random.Range(0, 2);
            SetQuestion_Engineering();
        }
        else // 운동장에서도 스크린이 필요 없으므로 끄기
        {
            if (questionNum != 12345) questionNum = 12345;
            if (this.gameObject.activeSelf) this.gameObject.SetActive(false); 
        }
    }



    private void SetQuestion_Humanities() // 인문계 강의실 도착시 문제 세팅
    {
        switch (questionNum) // 문제 텍스트 설정
        {
            case 0:
                tmp.text = "다음 알파벳을 재조합해서 한 단어를 만들어라.\n단, 알파벳은 모두 사용해야한다.\n";
                break;
                // 보기 띄우기 (-)
            case 1:
                tmp.text = "다음에 올 알파벳은 무엇인가?\n";
                break;
                // 보기 띄우기 (-)
            case 2:
                tmp.text = "다음 알파벳 문자들은 공통점이 있다.\n이중 빠진 알파벳 문자는 무엇인가?\n";
                break;
                // 보기 띄우기 (-)
        }
    }

    private void SetQuestion_Engineering() // 이공계 강의실 도착시 문제 세팅
    {
        switch (questionNum) // 문제 텍스트 설정
        {
            case 0:
                tmp.text = "다음을 보고 [7 * 4]를 구하시오.\n";
                break;
                // 보기 띄우기 (-)
            case 1:
                tmp.text = "100의 반을 1/2로 나누면\n얼마인지 계산하라.\n";
                break;
            case 2:
                tmp.text = "다음 보기를 보고 [ 7 + 3 = ??? ]을 구하시오.\n";
                break;
                // 보기 띄우기 (-)
        }
    }
}
