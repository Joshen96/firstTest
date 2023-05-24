using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Question_sy : MonoBehaviour
{
    // Ư�� ���ǰ� ������ȣ�� ���� ������ ����

    void Start()
    {
        this.gameObject.SetActive(false);
    }

    public void SetQuestion_Humanities(int _questionNum, ref string _answerStr) // �ι��� ���ǽ� ������ ���� ����
    {
        switch (_questionNum)
        {
            case 0:
                this.gameObject.GetComponent<TextMeshProUGUI>().fontSize = 3;
                this.gameObject.GetComponent<TextMeshProUGUI>().text = "�Ƕ�̵带 ��Ű�� ����ũ���� �Ƕ�̵带 �������� ������� ��� �� ��\n������ ���ϸ� ��ƸԴ´�.\n��ħ �Ƕ�̵带 �������� �����̿��� ����ũ���� ��� �´�.\n���� �����ϱ�?\n";
                _answerStr = "�ѿ��������׻׻���";
                break;
            case 1:
                this.gameObject.GetComponent<TextMeshProUGUI>().fontSize = 5;
                this.gameObject.GetComponent<TextMeshProUGUI>().text = "������ �� ���ĺ��� �����ΰ�?\n";
                _answerStr = "I";
                break;
            case 2:
                this.gameObject.GetComponent<TextMeshProUGUI>().fontSize = 5;
                this.gameObject.GetComponent<TextMeshProUGUI>().text = "���� ���ĺ� ���ڵ��� �������� �ִ�.\n���� ���� ���ĺ� ���ڴ� �����ΰ�?\n";
                _answerStr = "H";
                break;
        }
    }

    public void SetQuestion_Engineering(int _questionNum, ref string _answerStr) // �̰��� ���ǽ� ������ ���� ����
    {
        switch (_questionNum)
        {
            case 0:
                this.gameObject.GetComponent<TextMeshProUGUI>().fontSize = 4;
                this.gameObject.GetComponent<TextMeshProUGUI>().text = "������ ���� [7 * 4]�� ���Ͻÿ�.\n";
                _answerStr = "34";
                break;
            case 1:
                this.gameObject.GetComponent<TextMeshProUGUI>().fontSize = 6;
                this.gameObject.GetComponent<TextMeshProUGUI>().text = "�Ʒ��� ������ ����϶�.\n";
                _answerStr = "100";
                break;
            case 2:
                this.gameObject.GetComponent<TextMeshProUGUI>().fontSize = 4;
                this.gameObject.GetComponent<TextMeshProUGUI>().text = "���� ���⸦ ���� [ 7 + 3 = ??? ]�� ���Ͻÿ�.\n";
                _answerStr = "410";
                break;
        }
    }
}
