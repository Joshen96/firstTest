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


    // 랜덤으로 질문 설정
    public void SetQuestionNum()
    {
        questionNum = Random.Range(0, 3);
    }

    // 질문에 들어갈 텍스트
    public override string questionText()
    {
        //switch (questionNum)
        //{
        //    //case 0:
        //    //    return "다음 알파벳을 재조합해서 한 단어를 만들어라.\n단, 알파벳은 모두 사용해야한다.\n";
        //    //    break;
        //    //case 1:
        //    //    return "빈칸에 알맞은 알파벳은 무엇인가?\nN W H O I (?)\n";
        //    //    break;
        //    //case 2:
        //    //    return "다음 알파벳 문자들은 공통점이 있다.\n이중 빠진 알파벳 문자는 무엇인가?\n";
        //    //    break;
        //}

        if (questionNum == 0)
        { return "다음 알파벳을 재조합해서 한 단어를 만들어라.\n단, 알파벳은 모두 사용해야한다.\n"; }
        // 선택지 버튼 비활성화(+)
        // 

        else if (questionNum == 1)
        { return "빈칸에 알맞은 알파벳은 무엇인가?\nN W H O I (?)\n"; }

        else if (questionNum == 2) { return "다음 알파벳 문자들은 공통점이 있다.\n이중 빠진 알파벳 문자는 무엇인가?\n"; }

        else { Debug.LogWarning("QuestionNumber 선택 에러!!!"); return "QuestionNumber 선택 에러!!!"; }
    }

    // 선택지에 들어갈 텍스트
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
        else { Debug.LogWarning("QuestionNumber 선택 에러!!!"); return "QuestionNumber 선택 에러!!!"; }
    }
    public override string optionText2()
    {
        if (questionNum == 0) return "";
        else if (questionNum == 1)
        { return ""; }
        else if (questionNum == 2) { return ""; }
        else { Debug.LogWarning("QuestionNumber 선택 에러!!!"); return "QuestionNumber 선택 에러!!!"; }
    }
    public override string optionText3()
    {
        if (questionNum == 0) return "";
        else if (questionNum == 1)
        { return ""; }
        else if (questionNum == 2) { return ""; }
        else { Debug.LogWarning("QuestionNumber 선택 에러!!!"); return "QuestionNumber 선택 에러!!!"; }
    }
    public override string optionText4()
    {
        if (questionNum == 0) return "";
        else if (questionNum == 1)
        { return ""; }
        else if (questionNum == 2) { return ""; }
        else { Debug.LogWarning("QuestionNumber 선택 에러!!!"); return "QuestionNumber 선택 에러!!!"; }
    }
    public override string optionText5()
    {
        if (questionNum == 0) return "";
        else if (questionNum == 1)
        { return ""; }
        else if (questionNum == 2) { return ""; }
        else { Debug.LogWarning("QuestionNumber 선택 에러!!!"); return "QuestionNumber 선택 에러!!!"; }
    }
}
