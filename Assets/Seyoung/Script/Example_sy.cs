using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// QuestionText�� ���� ��ũ��Ʈ

public class Example_sy : MonoBehaviour
{
    [SerializeField] private Question_sy questionText = null;
    [SerializeField] private TextMeshProUGUI exampTMP = null;

    public string ClassName = null; 
    // ���ǽ� �̸��� ���� ������ ���� �ٸ��� ������ ����
    // �÷��̾ ���ǽǿ� ���� �� �ش� ���ǽ� �̸� �޾ƿ��� �ڵ� �ۼ� �ʿ�
    // ���ǽǸ��� �±׸� �ްŶ�� �±׷� �ڵ� ���� �ʿ�

    public int questionNum = 12345;

    void Start()
    {
        ClassName = questionText.ClassName;
        questionNum = questionText.questionNum;

        if (exampTMP == null)
        { Debug.LogError("QuestionText �ν����Ϳ� �ȳ־���!!!"); return; }
    }

    void Update()
    {
        ClassName = questionText.ClassName;
        questionNum = questionText.questionNum;

        if (ClassName == "�ι��谭�ǽ�") SetExample_Humanities();
        else if (ClassName == "�̰��谭�ǽ�") SetExample_Engineering();
        else if (ClassName != "�̰��谭�ǽ�" && ClassName != "�ι��谭�ǽ�") this.gameObject.SetActive(false);
    }



    private void SetExample_Humanities() // �ι��� ���ǽ� ������ ���� ����
    {
        this.gameObject.SetActive(true);
        exampTMP.fontSize = 7;
        exampTMP.color = Color.red;

        switch (questionNum) // ���� �ؽ�Ʈ ����
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

    private void SetExample_Engineering() // �̰��� ���ǽ� ������ ���� ����
    {
        switch (questionNum) // ���� ��ȣȮ��
        {
            case 0:
                exampTMP.text = "������ ���� [7 * 4]�� ���Ͻÿ�.\n";
                break;
                // ���� ���� (-)
            case 1:
                exampTMP.text = "100�� ���� 1/2�� ������\n������ ����϶�.\n";
                break;
            case 2:
                exampTMP.text = "���� ���⸦ ���� [ 7 + 3 = ??? ]�� ���Ͻÿ�.\n";
                break;
                // ���� ���� (-)
        }
    }
}
