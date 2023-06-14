using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BC_NPC_CHERR_RANDOMANI : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;
    public string SitOneAnimationName = "Cheer1";
    public string SitTwoAnimationName = "Cheer2";
    public string SitThreeAnimationName = "Cheer3";
    public string SitTypingAnimationName = "Victory Idle";
    public string SitBoringAnimationName = "Victory Idle2";
    public string SitBoringTwoAnimationName = "Standing Clap";

    public float SitAnimationProbability = 0.3f; // Phone 애니메이션의 확률 (0부터 1 사이)
    /*public float SitAnimationSpeed = 1.5f;*/ // Phone 애니메이션의 재생 속도
    public float minAnimationTime = 5f; // 최소 애니메이션 재생 시간
    public float maxAnimationTime = 10f; // 최대 애니메이션 재생 시간

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
            SleepAnimation();
            SitPhoneAnimation();
            PlayWalkAnimation();
            BoringAnimation();
            TypingAnimation();
        }


        // 다음 애니메이션 재생 시간 설정
        float randomTime = Random.Range(minAnimationTime, maxAnimationTime);
        nextAnimationTime = Time.time + randomTime;
    }

    private void PlayWalkAnimation()
    {
        // "walk" 애니메이션 재생
        animator.SetBool("isCheer", false);
        animator.Play(SitOneAnimationName);
    }

    private void PlayPhoneAnimation()
    {
        // "phone" 애니메이션 재생
        animator.SetBool("isCheerTwo", true);
        animator.Play(SitTwoAnimationName);

    }
    private void SitPhoneAnimation()
    {
        // "phone" 애니메이션 재생
        animator.SetBool("isCheerThree", true);
        animator.Play(SitTwoAnimationName);

    }
    private void SleepAnimation()
    {
        // "phone" 애니메이션 재생
        animator.SetBool("isStandingClap", true);
        animator.Play(SitBoringTwoAnimationName);

    }
    private void BoringAnimation()
    {
        // "phone" 애니메이션 재생
        animator.SetBool("isVictoryIdleTwo", true);
        animator.Play(SitBoringAnimationName);

    }
    private void TypingAnimation()
    {
        // "phone" 애니메이션 재생
        animator.SetBool("isVictoryIdle", true);
        animator.Play(SitTypingAnimationName);
        Invoke(nameof(StopTypingAnimation), Random.Range(minAnimationTime, maxAnimationTime));

    }

    private void StopTypingAnimation()
    {
        animator.SetBool("isVictoryIdle", false);
    }
}
