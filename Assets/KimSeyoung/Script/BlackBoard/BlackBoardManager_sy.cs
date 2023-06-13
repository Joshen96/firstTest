using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackBoardManager_sy : MonoBehaviour
{

    // ���ǽ� �̸��� ���� ������ ���� �ٸ��� ������ ����
    // �÷��̾ ���ǽǿ� ���� �� �ش� ���ǽ� �̸� �޾ƿ��� �ڵ� �ۼ� �ʿ�
    // ���ǽǸ��� �±׸� �ްŶ�� �±׷� �ڵ� ���� �ʿ�
    // �÷��̾ Ư�� �Ÿ� �̻� ��������� �� ������ ���(-)

    [Header ("-- Question Option --")]          // �ʼ� ������
    public string className = "";               // ���ǽ� �̸�
    public int questionNum = 12345;             // ������ȣ 
    private int beforeQNum = 12345;             // ������ Ǯ���� ���� ��ȣ
    public string answerStr = "";               // �� ������ ����

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

        // �ӽ÷� "�ι��谭�ǽ�"�̶� ��������.
        if (className == "�ι��谭�ǽ�")
        {
            if (canversGO.activeSelf || paticleGO.activeSelf)
            {
                canversGO.SetActive(true);
            }
            SetHumanities();
        }
        else if (className == "�̰��谭�ǽ�")
        {
            canversGO.SetActive(true);
            Engineering();
        }
        else if (className != "�ι��谭�ǽ�" && className != "�̰��谭�ǽ�")
        {
            if (questionNum != 12345) questionNum = 12345;
            if (canversGO.activeSelf || paticleGO.activeSelf)
            {
                paticleGO.SetActive(false);
                canversGO.SetActive(false);
            }
        }
    }

    private void SetHumanities() // �ι���
    {
        // 1. ���� ���� + ���� ����
        questionScript.gameObject.SetActive(true);
        questionScript.SetQuestion_Humanities(questionNum, ref answerStr);

        // 2. ���� ���� + ���� ������ �´� ��Ʈ ��Ÿ�� ����
        exampleScript.gameObject.SetActive(true);
        exampleScript.SetExample_Humanities(questionNum);

        // 3. ������/�Է��� ���� + �������� �ƴ��� �Ǵ�
        buttonsScript.gameObject.SetActive(true);
        buttonsScript.SetButtonText(className,questionNum);

        // 4. RightAnswerClick() �Ǵ� WrongAnswerClick() �� �����.
    }

    private void Engineering() // �ڿ���
    {
        // 1. ���� ���� + ���� ����
        questionScript.gameObject.SetActive(true);
        questionScript.SetQuestion_Engineering(questionNum, ref answerStr);

        // 2. ���� ����
        exampleScript.gameObject.SetActive(true);
        exampleScript.SetExample_Engineering(questionNum);

        // 3. ������/�Է��� ����
        buttonsScript.gameObject.SetActive(true);
        buttonsScript.SetButtonText(className, questionNum);

        // 4. ����Ȯ�� �� RightAnswerClick() �Ǵ� WrongAnswerClick() �� �����.
    }

    public void CheckTheAnswer(string _input, string _answer) // ���� Ȯ��
    {
        if (!Mission_imfo.isSolvingProblem) Mission_imfo.isSolvingProblem = true;
        
        if (_input == _answer) RightAnswerClick();
        else  WrongAnswerClick();
    }

    private void RightAnswerClick() // ���� ���� Ŭ����
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

    private void WrongAnswerClick() // Ʋ�� ���� Ŭ����
    {
        failpageGO.SetActive(true);
    }

    public void ReplayButtonClick() // �ٽ� ��ư Ŭ�� ��
    {
        failpageGO.SetActive(false);
    }

    public void RestartButtonClick() // ����� ��ư Ŭ��
    {
        restartButtonGO.SetActive(false);
        paticleGO.SetActive(false);
        clearpageGO.SetActive(false);

        ChangeQNum();
    }

    private void ChangeQNum()       // ������ȣ ����(���� ������ȣ�� ��ġ�� �ʵ��� ����)
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
