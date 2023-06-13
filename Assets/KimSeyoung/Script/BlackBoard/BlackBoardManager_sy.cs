using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackBoardManager_sy : MonoBehaviour
{

    // 강의실 이름에 따라 나오는 문제 다르게 설정할 예정
    // 플레이어가 강의실에 들어갔을 때 해당 강의실 이름 받아오는 코드 작성 필요
    // 강의실마다 태그를 달거라면 태그로 코드 변경 필요
    // 플레이어가 특정 거리 이상 가까워졌을 때 켜지는 기능(-)

    [Header ("-- Question Option --")]          // 필수 선택지
    public string className = "";               // 강의실 이름
    public int questionNum = 12345;             // 질문번호 
    private int beforeQNum = 12345;             // 이전에 풀었던 질문 번호
    public string answerStr = "";               // 현 질문의 정답

    [SerializeField] private Question_sy questionScript = null;
    [SerializeField] private Example_sy exampleScript = null;
    [SerializeField] private Button_sy buttonsScript = null;

    [SerializeField] private GameObject clearpageGO = null;
    [SerializeField] private GameObject failpageGO = null;
    [SerializeField] private GameObject canversGO = null;
    [SerializeField] private GameObject paticleGO = null;
    [SerializeField] private GameObject restartButtonGO = null;

    private void Start()
    {
        questionScript.gameObject.SetActive(false);
        exampleScript.gameObject.SetActive(false);
        buttonsScript.gameObject.SetActive(false);
        restartButtonGO.SetActive(false);
        clearpageGO.SetActive(false);
        failpageGO.SetActive(false);
        paticleGO.SetActive(false);
    }

    private void Update()
    {
        if (questionNum == 12345) questionNum = Random.Range(0, 3);

        if (clearpageGO.gameObject.activeSelf || failpageGO.gameObject.activeSelf)
        {
            questionScript.gameObject.SetActive(false);
            exampleScript.gameObject.SetActive(false);
            buttonsScript.gameObject.SetActive(false);
            return;
        }

        // 임시로 "인문계강의실"이라 지정했음.
        if (className == "인문계강의실")
        {
            if (canversGO.activeSelf || paticleGO.activeSelf)
            {
                canversGO.SetActive(true);
            }
            SetHumanities();
        }
        else if (className == "이공계강의실")
        {
            canversGO.SetActive(true);
            Engineering();
        }
        else if (className != "인문계강의실" && className != "이공계강의실")
        {
            if (questionNum != 12345) questionNum = 12345;
            if (canversGO.activeSelf || paticleGO.activeSelf)
            {
                paticleGO.SetActive(false);
                canversGO.SetActive(false);
            }
        }
    }

    private void SetHumanities() // 인문계
    {
        // 1. 문제 셋팅 + 정답 셋팅
        questionScript.gameObject.SetActive(true);
        questionScript.SetQuestion_Humanities(questionNum, ref answerStr);

        // 2. 보기 셋팅 + 보기 범위에 맞는 폰트 스타일 설정
        exampleScript.gameObject.SetActive(true);
        exampleScript.SetExample_Humanities(questionNum);

        // 3. 선택지/입력지 셋팅 + 정답인지 아닌지 판단
        buttonsScript.gameObject.SetActive(true);
        buttonsScript.SetButtonText(className,questionNum);

        // 4. RightAnswerClick() 또는 WrongAnswerClick() 가 시행됨.
    }

    private void Engineering() // 자연계
    {
        // 1. 문제 셋팅 + 정답 셋팅
        questionScript.gameObject.SetActive(true);
        questionScript.SetQuestion_Engineering(questionNum, ref answerStr);

        // 2. 보기 셋팅
        exampleScript.gameObject.SetActive(true);
        exampleScript.SetExample_Engineering(questionNum);

        // 3. 선택지/입력지 셋팅
        buttonsScript.gameObject.SetActive(true);
        buttonsScript.SetButtonText(className, questionNum);

        // 4. 정답확인 후 RightAnswerClick() 또는 WrongAnswerClick() 가 시행됨.
    }

    public void CheckTheAnswer(string _input, string _answer) // 정답 확인
    {
        if (!Mission_imfo.isSolvingProblem) Mission_imfo.isSolvingProblem = true;
        
        if (_input == _answer) RightAnswerClick();
        else  WrongAnswerClick();
    }

    private void RightAnswerClick() // 옳은 정답 클릭시
    {
        clearpageGO.gameObject.SetActive(true);
        paticleGO.SetActive(true);
        StartCoroutine("RestartButtonActivation");
    }

    private IEnumerator RestartButtonActivation() 
    {
        yield return new WaitForSeconds(3f);
        restartButtonGO.SetActive(true);
    }

    private void WrongAnswerClick() // 틀린 정답 클릭시
    {
        failpageGO.SetActive(true);
    }

    public void ReplayButtonClick() // 다시 버튼 클릭 시
    {
        failpageGO.SetActive(false);
    }

    public void RestartButtonClick() // 재시작 버튼 클릭
    {
        restartButtonGO.SetActive(false);
        paticleGO.SetActive(false);
        clearpageGO.SetActive(false);

        ChangeQNum();
    }

    private void ChangeQNum()       // 질문번호 변경(이전 질문번호와 겹치지 않도록 변경)
    {
        switch (questionNum)
        {
            case 0:
                beforeQNum = 0;
                while (beforeQNum == questionNum) questionNum = Random.Range(0, 3);
                break;
            case 1:
                beforeQNum = 1;
                while (beforeQNum == questionNum) questionNum = Random.Range(0, 3);
                break;
            case 2:
                beforeQNum = 2;
                while (beforeQNum == questionNum) questionNum = Random.Range(0, 3);
                break;
            case 12345:
                beforeQNum = 2;
                while (beforeQNum == questionNum) questionNum = Random.Range(0, 3);
                break;
        }
    }
}
