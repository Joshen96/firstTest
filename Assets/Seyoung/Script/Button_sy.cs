using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Button_sy : MonoBehaviour
{
    
    [SerializeField] private Question_sy questionText = null;

    [SerializeField] private string ClassName = null;
    [SerializeField] private int questionNum = 12345; // ���� ��ȣ�� ���� ��ư�� text�� ����ȴ�.

    [SerializeField] private TextMeshProUGUI text_Btn1 = null;
    [SerializeField] private TextMeshProUGUI text_Btn2 = null;
    [SerializeField] private TextMeshProUGUI text_Btn3 = null;
    [SerializeField] private TextMeshProUGUI text_Btn4 = null;
    [SerializeField] private TextMeshProUGUI text_Btn5 = null;


    private void Start()
    {
        if (text_Btn1 == null || text_Btn2 == null || text_Btn3 == null || text_Btn4 == null || text_Btn5 == null)
            Debug.LogError("text_Btn �ȹٷ� �ȵ���!!!");
    }
    private void Update()
    {
        ClassName = questionText.ClassName;
        questionNum = questionText.questionNum;

        if (ClassName != null && questionNum != 12345) SetButtonText();
    }
    private void SetButtonText() // ClassName�� questionNum�� �ش��ϴ� ��ư ����
    {
        if (ClassName == "�ι��谭�ǽ�")
        {
            switch (questionNum)
            {
                case 0:
                    this.gameObject.SetActive(false);
                    // inputfield �� ����� (-)
                    // ���� NEW DOOR
                    break;
                case 1:
                    this.gameObject.SetActive(true);
                    text_Btn1.text = "I"; // ����
                    text_Btn2.text = "N";
                    text_Btn3.text = "F";
                    text_Btn4.text = "P";
                    text_Btn5.text = "E";
                    break;
                case 2:
                    this.gameObject.SetActive(true);
                    text_Btn1.text = "A";
                    text_Btn2.text = "H"; // ����
                    text_Btn3.text = "P";
                    text_Btn4.text = "L";
                    text_Btn5.text = "U";
                    break;
            }

        }
        else if (ClassName == "�̰��谭�ǽ�")
        {
            switch (questionNum)
            {
                case 0:
                    this.gameObject.SetActive(true);
                    text_Btn1.text = "486";
                    text_Btn2.text = "99";
                    text_Btn3.text = "34"; // ����
                    text_Btn4.text = "27";
                    text_Btn5.text = "1004";
                    break;
                case 1:
                    this.gameObject.SetActive(true);
                    text_Btn1.text = "25";
                    text_Btn2.text = "10";
                    text_Btn3.text = "0";
                    text_Btn4.text = "50";
                    text_Btn5.text = "100"; // ����
                    break;
                case 2:
                    this.gameObject.SetActive(true);
                    text_Btn1.text = "10";
                    text_Btn2.text = "410"; // ����
                    text_Btn3.text = "104";
                    text_Btn4.text = "210";
                    text_Btn5.text = "140";
                    break;
            }
        }
        else if (ClassName != "�̰��谭�ǽ�" && ClassName != "�ι��谭�ǽ�")
        {
            if (this.gameObject.activeSelf) this.gameObject.SetActive(false);
        }
    }
}
