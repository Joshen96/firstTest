using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// Ư�� ���ǰ� ���� ��ȣ�� ���� ���� ����

public class Example_sy : MonoBehaviour
{
    public void SetExample_Humanities(int _questionNum) // �ι���
    {
        // ��Ʈ ũ��, ����, ���� ����
        this.gameObject.GetComponent<TextMeshProUGUI>().color = Color.red;
        this.gameObject.GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Bold;

        switch (_questionNum)
        {
            case 0:
                this.gameObject.GetComponent<TextMeshProUGUI>().fontSize = 3;
                this.gameObject.GetComponent<TextMeshProUGUI>().text = "[ 1 + 1 = ���� ]\t[ 1 + 3 = ������ ]\n" +
                    "[ 3 + 5 = �ѿ� ]\t[ 21 + 9 = �����׻� ]\t[ 13 + 35 = �������ѿ� ]\n" +
                    "[ 25 + 25 = �����׻� ]\t[ 113 + 121 = �������������� ]\n[ 4807 + 4100 = ??? ]";

                break;
            case 1:
                this.gameObject.GetComponent<TextMeshProUGUI>().fontSize = 7;
                this.gameObject.GetComponent<TextMeshProUGUI>().text = "N  W  H  O  I (?)";
                break;
            case 2:
                this.gameObject.GetComponent<TextMeshProUGUI>().fontSize = 7;
                this.gameObject.GetComponent<TextMeshProUGUI>().text = "B  C  D  E  I  K  O  X ";
                break;
        }
    }

    public void SetExample_Engineering(int _questionNum) // �̰���
    {
        // ��Ʈ ũ��, ����, ���� ����
        this.gameObject.GetComponent<TextMeshProUGUI>().color = Color.red;
        this.gameObject.GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Normal;

        switch (_questionNum) 
        {
            case 0:
                {
                    this.gameObject.GetComponent<TextMeshProUGUI>().fontSize = 5;
                    this.gameObject.GetComponent<TextMeshProUGUI>().text 
                        = "[ 2 * 3 = 9 ]\t[5 * 4 = 26]\n" +
                        "[6 * 2 = 13]\t[7 * 4 = (?) ]";}
                break;
            case 1:
                {
                    this.gameObject.GetComponent<TextMeshProUGUI>().fontSize = 6;
                    this.gameObject.GetComponent<TextMeshProUGUI>().text  = "100�� ���� 1/2�� ���� ����?"; 
                }
                break;
            case 2:
                {
                    this.gameObject.GetComponent<TextMeshProUGUI>().fontSize = 5;
                    this.gameObject.GetComponent<TextMeshProUGUI>().text 
                        = "[ 5 + 3 = 28 ]\t[9 + 1 + 810]\n" +
                        "[8 + 6 = 214]\t[5 + 4 + = 19]\n[7 + 3 = ??? ]";}
                break;
        }
    }
}
