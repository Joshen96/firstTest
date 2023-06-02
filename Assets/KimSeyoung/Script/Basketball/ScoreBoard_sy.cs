using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoard_sy : MonoBehaviour
{
    [SerializeField] private GameObject[] NumberGO = null;
    public int score = 0;

    private void Start()
    {
        NumberGO = new GameObject[10];

        for (int i = 0; i < 10; i++)
        {
            NumberGO[i] = Resources.Load<GameObject>("ScoreNumbers/" + i.ToString());
        }

        ScoreboardChange(0, 0, 0);
    }

    public void InputScoreToScoreboard() // 스코어에 따라 점수 변경
    {
        // 전광판 변경
        if (score < 10) // 한자리 수 일 때
        {
            ScoreboardChange(0, 0, score);
        }
        if (score < 100 && score >= 10) // 두자리 수 일 때
        {
            int secondNum = score / 10;
            int thirdNum = score & 10;
            ScoreboardChange(0, secondNum, thirdNum);
        }
        if (score >= 100) // 세자리 수 일 때
        {
            int firstNum = score / 100;
            int secondNum = score / 10;
            int thirdNum = score & 10;
            ScoreboardChange(firstNum, secondNum, thirdNum);
        }
    }

    public void ScoreboardChange(int _FirstNum, int _SecondNum, int _ThirdNum)
    {
        Vector3 instantiatePosition = transform.GetChild(2).gameObject.transform.position;
        GameObject FirstNumGO = Instantiate(NumberGO[_FirstNum], instantiatePosition, Quaternion.identity);
        transform.GetChild(2).gameObject.GetComponent<MeshFilter>().mesh = FirstNumGO.GetComponent<MeshFilter>().mesh;
        Destroy(FirstNumGO);

        instantiatePosition = transform.GetChild(3).gameObject.transform.position;
        GameObject SecondNumGO = Instantiate(NumberGO[_SecondNum], instantiatePosition, Quaternion.identity);
        transform.GetChild(3).gameObject.GetComponent<MeshFilter>().mesh = SecondNumGO.GetComponent<MeshFilter>().mesh;
        Destroy(SecondNumGO);

        instantiatePosition = transform.GetChild(4).gameObject.transform.position;
        GameObject ThirdNumGO = Instantiate(NumberGO[_ThirdNum], instantiatePosition, Quaternion.identity);
        transform.GetChild(4).gameObject.GetComponent<MeshFilter>().mesh = ThirdNumGO.GetComponent<MeshFilter>().mesh;
        Destroy(ThirdNumGO);
    }

    public void ScoreReset()
    {
        ScoreboardChange(0, 0, 0);
    }
}
