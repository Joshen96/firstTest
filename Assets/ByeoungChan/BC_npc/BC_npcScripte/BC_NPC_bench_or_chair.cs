using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BC_NPC_bench_or_chair : MonoBehaviour
{
    public float sittingDuration = 30f;
    public Animator animator;
    public BC_NPC_Traffic_WaypointNavigator waypointNavigator;
    public BC_NPC_Traffic_NavigationController npcController;
    public BC_NPC_Random_Animation ranDomAni;

    private bool isSitting = false;

    private void Start()
    {
        ranDomAni = GetComponent<BC_NPC_Random_Animation>();
    }

    public bool IsSitting()
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

        // 앉는 애니메이션 실행
        animator.SetBool("IsSitting", true);

        // 걷는 애니메이션 중지
        

        // NPC 이동 및 제어 스크립트 비활성화
        waypointNavigator.enabled = false;
        npcController.enabled = false;
        ranDomAni.enabled = false;

        // NPC를 앉을 위치로 이동
        transform.position = sittingPosition.position;
        transform.rotation = sittingPosition.rotation;

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
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bench"))
        {
            BC_BENCHI benchScript = other.GetComponentInChildren<BC_BENCHI>();
            
            if (benchScript != null && !benchScript.IsOccupied())
            {
                Debug.Log("여기는 앉은지 검사하는곳"+benchScript.IsOccupied());
                SitOnBench(benchScript.GetSittingPosition());
                benchScript.SetOccupied(true);




            }
            Debug.Log("검사안한곳" + benchScript.IsOccupied());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Bench"))
        {
            BC_BENCHI benchScript = other.GetComponentInChildren<BC_BENCHI>();
            if (benchScript != null)
            {
                //benchScript.SetOccupied(false);
            }
        }
    }
}






