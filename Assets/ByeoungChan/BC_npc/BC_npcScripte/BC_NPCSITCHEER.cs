using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BC_NPCSITCHEER : MonoBehaviour
{
    public Animator animator;
    public float randomAnimationDuration = 5f; // 랜덤 애니메이션 재생 시간

    private void Start()
    {
        StartCoroutine(PlayRandomAnimationCoroutine());
    }

    private IEnumerator PlayRandomAnimationCoroutine()
    {
        while (true) // 계속해서 반복하기 위해 무한 루프 사용
        {
            // 랜덤한 애니메이션 선택
            int randomAnimation = Random.Range(1, 14); // 1부터 13까지의 랜덤한 값을 선택

            // 애니메이션 파라미터 설정
            animator.SetInteger("RandomAnimation", randomAnimation);

            // 랜덤 애니메이션 실행
            animator.SetBool("IsSitting", true);

            // 랜덤 애니메이션 종료 대기
            yield return new WaitForSeconds(randomAnimationDuration);

            // 랜덤 애니메이션 종료
            animator.SetBool("IsSitting", false);

            // 다른 랜덤 애니메이션 선택을 위해 잠시 대기
            yield return new WaitForSeconds(0.3f);
        }
    }
}