using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screen_sy : ScreenManager_sy
{
    private int questionNum = 12345;
    [SerializeField] private GameObject buttons = null;

    private void Start()
    {
        buttons.SetActive(true);

    }


    // �������� ���� ����
    public void SetQuestionNum()
    {
        questionNum = Random.Range(0, 3);
    }

    // ������ �� �ؽ�Ʈ
    public override string questionText()
    {
        //switch (questionNum)
        //{
        //    //case 0:
        //    //    return "���� ���ĺ��� �������ؼ� �� �ܾ ������.\n��, ���ĺ��� ��� ����ؾ��Ѵ�.\n";
        //    //    break;
        //    //case 1:
        //    //    return "��ĭ�� �˸��� ���ĺ��� �����ΰ�?\nN W H O I (?)\n";
        //    //    break;
        //    //case 2:
        //    //    return "���� ���ĺ� ���ڵ��� �������� �ִ�.\n���� ���� ���ĺ� ���ڴ� �����ΰ�?\n";
        //    //    break;
        //}

        if (questionNum == 0)
        { return "���� ���ĺ��� �������ؼ� �� �ܾ ������.\n��, ���ĺ��� ��� ����ؾ��Ѵ�.\n"; }
        // ������ ��ư ��Ȱ��ȭ(+)
        // 

        else if (questionNum == 1)
        { return "��ĭ�� �˸��� ���ĺ��� �����ΰ�?\nN W H O I (?)\n"; }

        else if (questionNum == 2) { return "���� ���ĺ� ���ڵ��� �������� �ִ�.\n���� ���� ���ĺ� ���ڴ� �����ΰ�?\n"; }

        else { Debug.LogWarning("QuestionNumber ���� ����!!!"); return "QuestionNumber ���� ����!!!"; }
    }

    // �������� �� �ؽ�Ʈ
    public override string optionText1()
    {
        if (questionNum == 0)
        {
            if (buttons.activeSelf) buttons.SetActive(false);
            return ""; 
        }
        else if (questionNum == 1)
        {return ""; }
        else if (questionNum == 2) { return ""; }
        else { Debug.LogWarning("QuestionNumber ���� ����!!!"); return "QuestionNumber ���� ����!!!"; }
    }
    public override string optionText2()
    {
        if (questionNum == 0) return "";
        else if (questionNum == 1)
        { return ""; }
        else if (questionNum == 2) { return ""; }
        else { Debug.LogWarning("QuestionNumber ���� ����!!!"); return "QuestionNumber ���� ����!!!"; }
    }
    public override string optionText3()
    {
        if (questionNum == 0) return "";
        else if (questionNum == 1)
        { return ""; }
        else if (questionNum == 2) { return ""; }
        else { Debug.LogWarning("QuestionNumber ���� ����!!!"); return "QuestionNumber ���� ����!!!"; }
    }
    public override string optionText4()
    {
        if (questionNum == 0) return "";
        else if (questionNum == 1)
        { return ""; }
        else if (questionNum == 2) { return ""; }
        else { Debug.LogWarning("QuestionNumber ���� ����!!!"); return "QuestionNumber ���� ����!!!"; }
    }
    public override string optionText5()
    {
        if (questionNum == 0) return "";
        else if (questionNum == 1)
        { return ""; }
        else if (questionNum == 2) { return ""; }
        else { Debug.LogWarning("QuestionNumber ���� ����!!!"); return "QuestionNumber ���� ����!!!"; }
    }
}
