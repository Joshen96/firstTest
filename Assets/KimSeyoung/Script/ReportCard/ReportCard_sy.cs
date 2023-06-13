using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReportCard_sy : MonoBehaviour
{


    public GameObject[] checkPoints = new GameObject[8];

    public void Awake()
    {
        

        for (int i = 0; i < checkPoints.Length; i++) checkPoints[i].SetActive(false);



    }

    public void ShowReportCard() // 플레이어가 특정 키 눌리면 (-)
    {
        transform.GetChild(0).gameObject.SetActive(true);
        checkPoints[0].SetActive(true);

        if (Mission_imfo.isSolvingProblem)
        {
            checkPoints[1].SetActive(true);
        }
        if (Mission_imfo.isFindingCat)
        {
            checkPoints[2].SetActive(true);
        }
        if (Mission_imfo.isShootingFirecraker)
        {
            checkPoints[3].SetActive(true);
        }
        if (Mission_imfo.isPlayingBasketball)
        {
            checkPoints[4].SetActive(true);
        }
        if (Mission_imfo.isCatchingThief)
        {
            checkPoints[5].SetActive(true);
        }
        if (Mission_imfo.isFindingEasteregg)
        {
            checkPoints[6].SetActive(true);
        }
        if (Mission_imfo.isSolvingProblem && Mission_imfo.isFindingCat && Mission_imfo.isShootingFirecraker && Mission_imfo.isPlayingBasketball && Mission_imfo.isCatchingThief && Mission_imfo.isFindingEasteregg)
        {
            checkPoints[7].SetActive(true);
        }
    }

    public void CoverReportCard() //플레이어가 특정키에서 손을 때면(-)
    { transform.GetChild(0).gameObject.SetActive(false); }
}
