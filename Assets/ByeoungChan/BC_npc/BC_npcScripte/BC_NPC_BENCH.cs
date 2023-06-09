using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BC_NPC_BENCH : MonoBehaviour
{
    public float sittingDuration = 30f;
    public Animator animator;
    public BC_NPC_Traffic_WaypointNavigator waypointNavigator;
    public BC_NPC_Traffic_NavigationController npcController;

    private bool isSitting = false;
    public GameObject sittingPosition; // 앉을 위치 정보
    private Transform sittingPosition1;
    private Transform sittingPosition2;

    private void Start()
    {
        // 벤치의 자식 객체 중 하나를 앉을 위치로 설정
        sittingPosition1 = sittingPosition.transform.GetChild(0);
        sittingPosition2 = sittingPosition.transform.GetChild(1);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bench") && !isSitting)
            Debug.Log("Trigger entered");
        {
            StartCoroutine(SitOnBench());
        }
    }

    private IEnumerator SitOnBench()
    {
        isSitting = true;

        // NPC 이동 및 제어 스크립트 비활성화
        waypointNavigator.enabled = false;
        npcController.enabled = false;

        // 앉는 애니메이션 실행
        animator.SetBool("IsSitting", true);


        // NPC를 앉을 위치로 이동
       transform.position = sittingPosition1.position;
        transform.rotation = sittingPosition1.localRotation;

        // 일정 시간 동안 앉은 상태 유지
        float timer = 0f;
        while (timer < sittingDuration)
        {
            timer += Time.deltaTime;

            transform.position = sittingPosition1.position;
            transform.rotation = sittingPosition1.localRotation; //TEST

            // 앉아있는 애니메이션 실행
            animator.SetFloat("SittingAnimationSpeed", 1f); // 앉아있는 애니메이션 재생 속도 설정

            yield return null;
        }

        // 일어나는 애니메이션 실행
        animator.SetFloat("SittingAnimationSpeed", 0f); // 앉아있는 애니메이션 재생 속도 정지
        animator.SetBool("IsSitting", false);

        // NPC 이동 및 제어 스크립트 다시 활성화
        waypointNavigator.enabled = true;
        npcController.enabled = true;

        isSitting = false;
    }
}