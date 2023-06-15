using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BC_NPC_BENCH : MonoBehaviour
{
    public float sittingDuration = 30f;
    public Animator animator;
    public BC_NPC_Traffic_WaypointNavigator waypointNavigator;
    public BC_NPC_Traffic_NavigationController npcController;
    public BC_NPC_Random_Animation ranDomAni;

    private bool isSitting = false;
    private Transform sittingPosition;
    

    private static int numSittingNPCs = 0; // 앉아있는 NPC 수
    private static bool isSeatAvailable = true;// 앉을 수 있는 상태인지 여부

    private void Start()
    {
        ranDomAni = GetComponent<BC_NPC_Random_Animation>();
        GameObject[] benchSeats = GameObject.FindGameObjectsWithTag("BenchSeat");

        if (benchSeats.Length == 2)
        {
            if (numSittingNPCs == 0)
            {
                // 첫 번째 NPC는 왼쪽에 앉음
                sittingPosition = benchSeats[0].transform;
            }
            else if (numSittingNPCs == 1)
            {
                // 두 번째 NPC는 오른쪽에 앉음
                if (sittingPosition == benchSeats[0].transform)
                {
                    // 이미 왼쪽에 앉은 경우, 오른쪽에 앉지 않도록 비활성화
                    gameObject.SetActive(false);
                }
                else
                {
                    sittingPosition = benchSeats[1].transform;
                }
            }
            else
            {
                // 이미 NPC 2명이 앉아있으면 해당 NPC는 벤치에 앉지 않도록 비활성화
                gameObject.SetActive(false);
            }
        }
        else
        {
            //Debug.LogError("Two BenchSeat objects with the 'BenchSeat' tag are required.");
        }
        isSeatAvailable = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bench") && !isSitting && numSittingNPCs < 2)
        {
            isSeatAvailable = false;
            StartCoroutine(SitOnBench());
        }
    }

    private IEnumerator SitOnBench()
    {
        isSitting = true;

        // 앉는 애니메이션 실행
        animator.SetBool("IsSitting", true);

        // NPC 이동 및 제어 스크립트 비활성화
        waypointNavigator.enabled = false;
        npcController.enabled = false;
        ranDomAni.enabled = false;

        // NPC를 앉을 위치로 이동
        transform.position = sittingPosition.position;
        transform.rotation = sittingPosition.rotation;

        // 앉은 NPC 수 증가
        numSittingNPCs++;

        // 일정 시간 동안 앉은 상태 유지
        yield return new WaitForSeconds(sittingDuration);

        // 일어나는 애니메이션 실행
        animator.SetBool("IsSitting", false);

        // NPC 이동 및 제어 스크립트 다시 활성화
        waypointNavigator.enabled = true;
        npcController.enabled = true;
        ranDomAni.enabled = true;

        // 앉은 NPC 수 감소
        numSittingNPCs--;

        isSitting = false;
    }
}