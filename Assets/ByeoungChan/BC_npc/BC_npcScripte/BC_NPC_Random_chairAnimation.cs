using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BC_NPC_Random_chairAnimation : MonoBehaviour
{
    public Animator animator;
    public string walkAnimationName = "Walk";
    public string sitAnimationName = "Sit";
    public string phoneAnimationName = "Phone";
    public float phoneAnimationProbability = 0.5f; // Phone 애니메이션의 확률 (0부터 1 사이)
    public float phoneAnimationSpeed = 1.5f; // Phone 애니메이션의 재생 속도
    public float minAnimationTime = 2f; // 최소 애니메이션 재생 시간
    public float maxAnimationTime = 5f; // 최대 애니메이션 재생 시간

    private bool isSitting = false; // NPC가 앉아 있는지 여부
    private float sitTimer = 0f; // NPC가 앉아 있는 시간을 측정하는 타이머 변수
    public float sitDuration = 5f; // 앉아 있는 시간

    private void Start()
    {
        PlayRandomAnimation();
    }

    private void Update()
    {
        if (isSitting)
        {
            sitTimer += Time.deltaTime;
            if (sitTimer >= sitDuration)
            {
                // 앉아 있던 시간이 지나면 일어나고 랜덤한 애니메이션 재생
                isSitting = false;
                animator.SetBool("isSitting", false);
                PlayRandomAnimation();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Chair"))
        {
            // 의자 트리거에 들어갔을 때 앉는 애니메이션 재생
            isSitting = true;
            animator.SetBool("isSitAnimation", true);
            sitTimer = 3f;
        }
    }

    private void PlayRandomAnimation()
    {
        // 랜덤 값을 생성하여 애니메이션 결정
        float randomValue = Random.value;

        if (randomValue < phoneAnimationProbability)
        {
            PlayPhoneAnimation();
        }
        else
        {
            PlayWalkAnimation();
        }

        // 다음 애니메이션 재생 시간 설정
        float randomTime = Random.Range(minAnimationTime, maxAnimationTime);
        Invoke("PlayRandomAnimation", randomTime);
    }

    private void PlayWalkAnimation()
    {
        // "walk" 애니메이션 재생
        animator.SetBool("isPhoneAnimation", false);
        animator.Play(walkAnimationName);
    }

    private void PlayPhoneAnimation()
    {
        // "phone" 애니메이션 재생
        animator.SetBool("isPhoneAnimation", true);
        animator.Play(phoneAnimationName);
        animator.speed = phoneAnimationSpeed;
    }
}