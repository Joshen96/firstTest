using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// QuestionText�� ���� ��ũ��Ʈ

public class Question_sy : MonoBehaviour
{
    public string ClassName = null; 
    // ���ǽ� �̸��� ���� ������ ���� �ٸ��� ������ ����
    // �÷��̾ ���ǽǿ� ���� �� �ش� ���ǽ� �̸� �޾ƿ��� �ڵ� �ۼ� �ʿ�
    // ���ǽǸ��� �±׸� �ްŶ�� �±׷� �ڵ� ���� �ʿ�

    public int questionNum = 12345;
    [SerializeField] private TextMeshProUGUI tmp = null;

    void Start()
    {
        if (tmp == null)
        { Debug.LogError("QuestionText �ν����Ϳ� �ȳ־���!!!"); return; }
    }

    void Update()
    {
        if (ClassName == "�ι��谭�ǽ�")
        {
            if (questionNum == 12345) questionNum = Random.Range(0, 2);
            SetQuestion_Humanities();
        }

        else if (ClassName == "�̰��谭�ǽ�")
        {
            if (questionNum == 12345) questionNum = Random.Range(0, 2);
            SetQuestion_Engineering();
        }
        else // ��忡���� ��ũ���� �ʿ� �����Ƿ� ����
        {
            if (questionNum != 12345) questionNum = 12345;
            if (this.gameObject.activeSelf) this.gameObject.SetActive(false); 
        }
    }



    private void SetQuestion_Humanities() // �ι��� ���ǽ� ������ ���� ����
    {
        switch (questionNum) // ���� �ؽ�Ʈ ����
        {
            case 0:
                tmp.text = "���� ���ĺ��� �������ؼ� �� �ܾ ������.\n��, ���ĺ��� ��� ����ؾ��Ѵ�.\n";
                break;
                // ���� ���� (-)
            case 1:
                tmp.text = "������ �� ���ĺ��� �����ΰ�?\n";
                break;
                // ���� ���� (-)
            case 2:
                tmp.text = "���� ���ĺ� ���ڵ��� �������� �ִ�.\n���� ���� ���ĺ� ���ڴ� �����ΰ�?\n";
                break;
                // ���� ���� (-)
        }
    }

    private void SetQuestion_Engineering() // �̰��� ���ǽ� ������ ���� ����
    {
        switch (questionNum) // ���� �ؽ�Ʈ ����
        {
            case 0:
                tmp.text = "������ ���� [7 * 4]�� ���Ͻÿ�.\n";
                break;
                // ���� ���� (-)
            case 1:
                tmp.text = "100�� ���� 1/2�� ������\n������ ����϶�.\n";
                break;
            case 2:
                tmp.text = "���� ���⸦ ���� [ 7 + 3 = ??? ]�� ���Ͻÿ�.\n";
                break;
                // ���� ���� (-)
        }
    }
}
