using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BC_NPC_TALKTWO : MonoBehaviour
{
    public float sittingDuration = 30f;
    public Animator animator;
    public BC_NPC_Traffic_WaypointNavigator waypointNavigator;
    public BC_NPC_Traffic_NavigationController npcController;
    public BC_NPC_Random_Animation ranDomAni;
    //public BC_NPC_BENCHI_RANDOM_ANI benchiRandom;
    public int randomAnimation;

    private bool isSitting = false;

    private void Start()
    {
        ranDomAni = GetComponent<BC_NPC_Random_Animation>();
    }

    public bool IsTalk()
    {
        return isSitting;
    }

    public void SitOnBench(Transform sittingPosition)
    {
        if (!isSitting)
        {
            StartCoroutine(SitOnBenchCoroutine(sittingPosition));
        }
    }

    private IEnumerator SitOnBenchCoroutine(Transform sittingPosition)
    {
        animator.Rebind(); // 애니메이터 초기화

        isSitting = true;

        switch (randomAnimation)
        {
            case 2:
                animator.SetBool("IsTalking", true);
                break;
            case 3:
                animator.SetBool("IsSittingThree", true);
                break;
            case 4:
                animator.SetBool("IsSitting4", true);
                break;
            case 5:
                animator.SetBool("IsSitting5", true);
                break;
            case 6:
                animator.SetBool("IsSitting6", true);
                break;
            default:
                animator.SetBool("IsSittingTwo", true); // 기본값으로 설정
                break;
        }

        // 앉는 애니메이션 실행
        animator.SetBool("IsSitting", true);

        //benchiRandom.enabled = true;

        // 걷는 애니메이션 중지


        // NPC 이동 및 제어 스크립트 비활성화
        waypointNavigator.enabled = false;
        npcController.enabled = false;
        ranDomAni.enabled = false;

        // NPC를 앉을 위치로 이동
        transform.position = sittingPosition.position;
        transform.rotation = sittingPosition.rotation;

        randomAnimation = Random.Range(1, 6);
        animator.SetInteger("RandomAnimation", randomAnimation);
        // 일정 시간 동안 앉은 상태 유지
        yield return new WaitForSeconds(sittingDuration);

        StandUpFromBench();

        isSitting = false;

        // 걷는 애니메이션 재개

    }

    public void StandUpFromBench()
    {
        // 일어나는 애니메이션 실행
        animator.SetBool("IsSitting", false);

        // NPC 이동 및 제어 스크립트 다시 활성화
        waypointNavigator.enabled = true;
        npcController.enabled = true;
        ranDomAni.enabled = true;
        /*benchiRandom.enabled = false*/
        ;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TalkNpc"))
        {
            BC_BENCHI benchScript = other.GetComponentInChildren<BC_BENCHI>();

            if (benchScript != null && !benchScript.IsOccupied())
            {
                //Debug.Log("여기는 앉은지 검사하는곳" + benchScript.IsOccupied());
                SitOnBench(benchScript.GetSittingPosition());
                benchScript.SetOccupied(true);




            }
            //Debug.Log("검사안한곳" + benchScript.IsOccupied());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("TalkNpc"))
        {
            BC_BENCHI benchScript = other.GetComponentInChildren<BC_BENCHI>();
            if (benchScript != null)
            {
                //benchScript.SetOccupied(false);
            }
        }
    }

}

