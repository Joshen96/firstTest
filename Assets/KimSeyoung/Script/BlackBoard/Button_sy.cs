using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class Button_sy : MonoBehaviour
{
    // ClassName�� questionNum�� ���� �˸��� ��ư ����
    // Ư�� ��ư Ŭ�� �� �������� �ƴ��� �Ǵ�

    [SerializeField] private TextMeshProUGUI text_Btn1 = null;
    [SerializeField] private TextMeshProUGUI text_Btn2 = null;
    [SerializeField] private TextMeshProUGUI text_Btn3 = null;
    [SerializeField] private TextMeshProUGUI text_Btn4 = null;
    [SerializeField] private TextMeshProUGUI text_Btn5 = null;

    [SerializeField] private BlackBoardManager_sy blackboardManager = null;

    public void SetButtonText(string _className, int _questionNum) // ClassName�� questionNum�� ���� �˸��� ��ư ����
    {
        if (_className == "�ι��谭�ǽ�")
        {
            switch (_questionNum)
            {
                case 0:
                    text_Btn1.text = "�׻� ����"; 
                    text_Btn2.text = "�ѿ� �׿� �׻�";
                    text_Btn3.text = "������ �׻� ����";
                    text_Btn4.text = "�ѿ��������׻׻���";
                    text_Btn5.text = "�׻� ���� �ѿ�";
                    break;
                case 1:
                    text_Btn1.text = "I"; // ����
                    text_Btn2.text = "N";
                    text_Btn3.text = "F";
                    text_Btn4.text = "P";
                    text_Btn5.text = "E";
                    break;
                case 2:
                    text_Btn1.text = "A";
                    text_Btn2.text = "H"; // ����
                    text_Btn3.text = "P";
                    text_Btn4.text = "L";
                    text_Btn5.text = "U";
                    break;
            }

        }
        else if (_className == "�̰��谭�ǽ�")
        {
            switch (_questionNum)
            {
                case 0:
                    text_Btn1.text = "486";
                    text_Btn2.text = "99";
                    text_Btn3.text = "34"; // ����
                    text_Btn4.text = "27";
                    text_Btn5.text = "1004";
                    break;
                case 1:
                    text_Btn1.text = "25";
                    text_Btn2.text = "10";
                    text_Btn3.text = "0";
                    text_Btn4.text = "50";
                    text_Btn5.text = "100"; // ����
                    break;
                case 2:
                    text_Btn1.text = "10";
                    text_Btn2.text = "410"; // ����
                    text_Btn3.text = "104";
                    text_Btn4.text = "210";
                    text_Btn5.text = "140";
                    break;
            }
        }
    }

    public void ClickButton() // ��ư Ŭ�� ���� ��
    {
        GameObject clickObject = EventSystem.current.currentSelectedGameObject;                                     // Ŭ���� ��ư ��������
        string buttonText = clickObject.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text;      // Ŭ���� ��ư�� �������ִ� �ؽ�Ʈ ��������

        blackboardManager.CheckTheAnswer(buttonText, blackboardManager.answerStr);
        // ������ ��ư�� �ؽ�Ʈ ���� ������ ������ Ȯ��
    }

    public void ReplayButtonClick() // �ٽ� ��ư Ŭ�� ��
    {
        blackboardManager.ReplayButtonClick();
    }

    public void RestartButtonClick()
    {
        blackboardManager.RestartButtonClick();
    }
}
