using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BC_NPC_SIT_Random_Ainmation : MonoBehaviour
{
    public Animator animator;
    public string SitOneAnimationName = "Sitting";
    public string SitTwoAnimationName = "SittingTwo";
    public string SitThreeAnimationName = "SittingThree";
    public float SitAnimationProbability = 0.5f; // Phone 애니메이션의 확률 (0부터 1 사이)
    public float SitAnimationSpeed = 1.5f; // Phone 애니메이션의 재생 속도
    public float minAnimationTime = 2f; // 최소 애니메이션 재생 시간
    public float maxAnimationTime = 5f; // 최대 애니메이션 재생 시간

    private float nextAnimationTime;

    private void Start()
    {
        // 초기 애니메이션 재생
        PlayRandomAnimation();
    }

    private void Update()
    {
        // 다음 애니메이션 재생 시간이 되면 다음 애니메이션 재생
        if (Time.time >= nextAnimationTime)
        {
            PlayRandomAnimation();
        }
    }

    private void PlayRandomAnimation()
    {
        // 랜덤 값을 생성하여 애니메이션 결정
        float randomValue = Random.value;

        if (randomValue < SitAnimationProbability)
        {
            PlayPhoneAnimation();
        }
        else
        {
            SitPhoneAnimation();
            PlayWalkAnimation();
        }
        

        // 다음 애니메이션 재생 시간 설정
        float randomTime = Random.Range(minAnimationTime, maxAnimationTime);
        nextAnimationTime = Time.time + randomTime;
    }

    private void PlayWalkAnimation()
    {
        // "walk" 애니메이션 재생
        animator.SetBool("isSitAnimation", false);
        animator.Play(SitOneAnimationName);
    }

    private void PlayPhoneAnimation()
    {
        // "phone" 애니메이션 재생
        animator.SetBool("isSitTwoAnimation", true);
        animator.Play(SitTwoAnimationName); 
        animator.speed = SitAnimationSpeed;
    }
    private void SitPhoneAnimation()
    {
        // "phone" 애니메이션 재생
        animator.SetBool("isSitThreeAnimation", true);
        animator.Play(SitTwoAnimationName);
        animator.speed = SitAnimationSpeed;
    }
}
