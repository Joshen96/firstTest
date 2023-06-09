using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoard_sy : MonoBehaviour
{
    [SerializeField] private GameObject[] NumberGO = null;

    public int score = 0;

    private Vector3 firstNumPosition = Vector3.zero;
    private Vector3 secondNumPosition = Vector3.zero;
    private Vector3 thirdNumPosition = Vector3.zero;

    private void Awake()
    {
        NumberGO = new GameObject[10];

        for (int i = 0; i < 10; i++)
        {
            NumberGO[i] = Resources.Load<GameObject>("ScoreNumbers/" + i.ToString());
        }
        ScoreboardChange(0, 0, 0);

        firstNumPosition = transform.GetChild(2).gameObject.transform.position;
        secondNumPosition = transform.GetChild(3).gameObject.transform.position;
        thirdNumPosition = transform.GetChild(4).gameObject.transform.position;
    }

    public void InputScoreToScoreboard(int _score) // ���ԵǴ� ���ھ ���� ������ ����
    {
        score = _score;

        if (score <= 0) ScoreboardChange(0, 0, 0);

        if (score < 10 && score > 0) // ���ڸ� �� �� ��
            ScoreboardChange(0, 0, score);
        
        if (score < 100 && score >= 10) // ���ڸ� �� �� ��
        {
            int secondNum = score / 10;
            int thirdNum = score % 10;
            ScoreboardChange(0, secondNum, thirdNum);
        }
        if (score >= 100) // ���ڸ� �� �� ��
        {
            int firstNum = score / 100;
            int secondNum = (score % 100) / 10;
            int thirdNum = score % 10;
            ScoreboardChange(firstNum, secondNum, thirdNum);
        }
    }

    private void ScoreboardChange(int _FirstNum, int _SecondNum, int _ThirdNum)
    {
        GameObject FirstNumGO = Instantiate(NumberGO[_FirstNum]);
        FirstNumGO.transform.SetParent(this.transform, false);
        FirstNumGO.transform.localPosition += new Vector3(0.3f, 0.5f, 0f);

        GameObject SecondNumGO = Instantiate(NumberGO[_SecondNum]);
        SecondNumGO.transform.SetParent(this.transform, false);
        SecondNumGO.transform.localPosition += Vector3.up * 0.5f;

        GameObject ThirdNumGO = Instantiate(NumberGO[_ThirdNum]);
        ThirdNumGO.transform.SetParent(this.transform, false);
        ThirdNumGO.transform.localPosition += new Vector3(-0.3f, 0.5f, 0f);

        // �ڽ����� �ֱ� (-)

        Destroy(transform.GetChild(4).gameObject);
        Destroy(transform.GetChild(3).gameObject);
        Destroy(transform.GetChild(2).gameObject);
    }

    public void ScoreReset()
    {
        ScoreboardChange(0, 0, 0);
    }
}
