using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Question_sy : MonoBehaviour
{
    // 특정 교실과 질문번호에 따라 질문지 셋팅

    void Start()
    {
        this.gameObject.SetActive(false);
    }

    public void SetQuestion_Humanities(int _questionNum, ref string _answerStr) // 인문계 강의실 도착시 문제 세팅
    {
        switch (_questionNum)
        {
            case 0:
                this.gameObject.GetComponent<TextMeshProUGUI>().fontSize = 3;
                this.gameObject.GetComponent<TextMeshProUGUI>().text = "피라미드를 지키는 스핑크스는 피라미드를 지나가는 사람에게 퀴즈를 낸 뒤\n맞히지 못하면 잡아먹는다.\n마침 피라미드를 지나가던 세영이에게 스핑크스가 퀴즈를 냈다.\n답은 무엇일까?\n";
                _answerStr = "뿌웅뿌지직뿡뿡뿌직";
                break;
            case 1:
                this.gameObject.GetComponent<TextMeshProUGUI>().fontSize = 5;
                this.gameObject.GetComponent<TextMeshProUGUI>().text = "다음에 올 알파벳은 무엇인가?\n";
                _answerStr = "I";
                break;
            case 2:
                this.gameObject.GetComponent<TextMeshProUGUI>().fontSize = 5;
                this.gameObject.GetComponent<TextMeshProUGUI>().text = "다음 알파벳 문자들은 공통점이 있다.\n이중 빠진 알파벳 문자는 무엇인가?\n";
                _answerStr = "H";
                break;
        }
    }

    public void SetQuestion_Engineering(int _questionNum, ref string _answerStr) // 이공계 강의실 도착시 문제 세팅
    {
        switch (_questionNum)
        {
            case 0:
                this.gameObject.GetComponent<TextMeshProUGUI>().fontSize = 4;
                this.gameObject.GetComponent<TextMeshProUGUI>().text = "다음을 보고 [7 * 4]를 구하시오.\n";
                _answerStr = "34";
                break;
            case 1:
                this.gameObject.GetComponent<TextMeshProUGUI>().fontSize = 6;
                this.gameObject.GetComponent<TextMeshProUGUI>().text = "아래의 조건을 계산하라.\n";
                _answerStr = "100";
                break;
            case 2:
                this.gameObject.GetComponent<TextMeshProUGUI>().fontSize = 4;
                this.gameObject.GetComponent<TextMeshProUGUI>().text = "다음 보기를 보고 [ 7 + 3 = ??? ]을 구하시오.\n";
                _answerStr = "410";
                break;
        }
    }
}
