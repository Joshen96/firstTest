using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// QuestionText에 들어가는 스크립트

public class Example_sy : MonoBehaviour
{
    [SerializeField] private Question_sy questionText = null;
    [SerializeField] private TextMeshProUGUI exampTMP = null;

    public string ClassName = null; 
    // 강의실 이름에 따라 나오는 문제 다르게 설정할 예정
    // 플레이어가 강의실에 들어갔을 때 해당 강의실 이름 받아오는 코드 작성 필요
    // 강의실마다 태그를 달거라면 태그로 코드 변경 필요

    public int questionNum = 12345;

    void Start()
    {
        ClassName = questionText.ClassName;
        questionNum = questionText.questionNum;

        if (exampTMP == null)
        { Debug.LogError("QuestionText 인스펙터에 안넣었어!!!"); return; }
    }

    void Update()
    {
        ClassName = questionText.ClassName;
        questionNum = questionText.questionNum;

        if (ClassName == "인문계강의실") SetExample_Humanities();
        else if (ClassName == "이공계강의실") SetExample_Engineering();
        else if (ClassName != "이공계강의실" && ClassName != "인문계강의실") this.gameObject.SetActive(false);
    }



    private void SetExample_Humanities() // 인문계 강의실 도착시 보기 세팅
    {
        this.gameObject.SetActive(true);
        exampTMP.fontSize = 7;
        exampTMP.color = Color.red;

        switch (questionNum) // 보기 텍스트 설정
        {
            case 0:
                exampTMP.text = "N E W   D O O R";
                break;
            case 1:
                exampTMP.text = "N  W  H  O  I  (?)";
                break;
            case 2:
                exampTMP.text = "B  C  D  E  I  K  O  X ";
                break;
        }
    }

    private void SetExample_Engineering() // 이공계 강의실 도착시 보기 세팅
    {
        switch (questionNum) // 문제 번호확인
        {
            case 0:
                exampTMP.text = "다음을 보고 [7 * 4]를 구하시오.\n";
                break;
                // 보기 띄우기 (-)
            case 1:
                exampTMP.text = "100의 반을 1/2로 나누면\n얼마인지 계산하라.\n";
                break;
            case 2:
                exampTMP.text = "다음 보기를 보고 [ 7 + 3 = ??? ]을 구하시오.\n";
                break;
                // 보기 띄우기 (-)
        }
    }
}
