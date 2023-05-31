using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class Button_sy : MonoBehaviour
{
    // ClassName과 questionNum에 따라 알맞은 버튼 셋팅
    // 특정 버튼 클릭 시 정답인지 아닌지 판단

    [SerializeField] private TextMeshProUGUI text_Btn1 = null;
    [SerializeField] private TextMeshProUGUI text_Btn2 = null;
    [SerializeField] private TextMeshProUGUI text_Btn3 = null;
    [SerializeField] private TextMeshProUGUI text_Btn4 = null;
    [SerializeField] private TextMeshProUGUI text_Btn5 = null;

    [SerializeField] private BlackBoardManager_sy blackboardManager = null;

    public void SetButtonText(string _className, int _questionNum) // ClassName과 questionNum에 따라 알맞은 버튼 셋팅
    {
        if (_className == "인문계강의실")
        {
            switch (_questionNum)
            {
                case 0:
                    text_Btn1.text = "뿡뿡 뿌직"; 
                    text_Btn2.text = "뿌웅 뿡웅 뿡뿡";
                    text_Btn3.text = "뿌지직 뿡뿡 뿌직";
                    text_Btn4.text = "뿌웅뿌지직뿡뿡뿌직";
                    text_Btn5.text = "뿡뿡 뿌직 뿌웅";
                    break;
                case 1:
                    text_Btn1.text = "I"; // 정답
                    text_Btn2.text = "N";
                    text_Btn3.text = "F";
                    text_Btn4.text = "P";
                    text_Btn5.text = "E";
                    break;
                case 2:
                    text_Btn1.text = "A";
                    text_Btn2.text = "H"; // 정답
                    text_Btn3.text = "P";
                    text_Btn4.text = "L";
                    text_Btn5.text = "U";
                    break;
            }

        }
        else if (_className == "이공계강의실")
        {
            switch (_questionNum)
            {
                case 0:
                    text_Btn1.text = "486";
                    text_Btn2.text = "99";
                    text_Btn3.text = "34"; // 정답
                    text_Btn4.text = "27";
                    text_Btn5.text = "1004";
                    break;
                case 1:
                    text_Btn1.text = "25";
                    text_Btn2.text = "10";
                    text_Btn3.text = "0";
                    text_Btn4.text = "50";
                    text_Btn5.text = "100"; // 정답
                    break;
                case 2:
                    text_Btn1.text = "10";
                    text_Btn2.text = "410"; // 정답
                    text_Btn3.text = "104";
                    text_Btn4.text = "210";
                    text_Btn5.text = "140";
                    break;
            }
        }
    }

    public void ClickButton() // 버튼 클릭 했을 때
    {
        GameObject clickObject = EventSystem.current.currentSelectedGameObject;                                     // 클릭한 버튼 가져오기
        string buttonText = clickObject.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text;      // 클릭한 버튼이 가지고있는 텍스트 가져오기

        blackboardManager.CheckTheAnswer(buttonText, blackboardManager.answerStr);
        // 선택한 버튼의 텍스트 값과 정답이 같은지 확인
    }

    public void ReplayButtonClick() // 다시 버튼 클릭 시
    {
        blackboardManager.ReplayButtonClick();
    }

    public void RestartButtonClick()
    {
        blackboardManager.RestartButtonClick();
    }
}
