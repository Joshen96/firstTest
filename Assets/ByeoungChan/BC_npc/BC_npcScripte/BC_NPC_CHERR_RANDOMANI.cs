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

    public float SitAnimationProbability = 0.3f; // Phone �ִϸ��̼��� Ȯ�� (0���� 1 ����)
    /*public float SitAnimationSpeed = 1.5f;*/ // Phone �ִϸ��̼��� ��� �ӵ�
    public float minAnimationTime = 5f; // �ּ� �ִϸ��̼� ��� �ð�
    public float maxAnimationTime = 10f; // �ִ� �ִϸ��̼� ��� �ð�

    private float nextAnimationTime;

    private void Start()
    {
        // �ʱ� �ִϸ��̼� ���
        PlayRandomAnimation();
    }

    private void Update()
    {
        // ���� �ִϸ��̼� ��� �ð��� �Ǹ� ���� �ִϸ��̼� ���
        if (Time.time >= nextAnimationTime)
        {
            PlayRandomAnimation();
        }
    }

    private void PlayRandomAnimation()
    {
        // ���� ���� �����Ͽ� �ִϸ��̼� ����
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


        // ���� �ִϸ��̼� ��� �ð� ����
        float randomTime = Random.Range(minAnimationTime, maxAnimationTime);
        nextAnimationTime = Time.time + randomTime;
    }

    private void PlayWalkAnimation()
    {
        // "walk" �ִϸ��̼� ���
        animator.SetBool("isCheer", false);
        animator.Play(SitOneAnimationName);
    }

    private void PlayPhoneAnimation()
    {
        // "phone" �ִϸ��̼� ���
        animator.SetBool("isCheerTwo", true);
        animator.Play(SitTwoAnimationName);

    }
    private void SitPhoneAnimation()
    {
        // "phone" �ִϸ��̼� ���
        animator.SetBool("isCheerThree", true);
        animator.Play(SitTwoAnimationName);

    }
    private void SleepAnimation()
    {
        // "phone" �ִϸ��̼� ���
        animator.SetBool("isStandingClap", true);
        animator.Play(SitBoringTwoAnimationName);

    }
    private void BoringAnimation()
    {
        // "phone" �ִϸ��̼� ���
        animator.SetBool("isVictoryIdleTwo", true);
        animator.Play(SitBoringAnimationName);

    }
    private void TypingAnimation()
    {
        // "phone" �ִϸ��̼� ���
        animator.SetBool("isVictoryIdle", true);
        animator.Play(SitTypingAnimationName);
        Invoke(nameof(StopTypingAnimation), Random.Range(minAnimationTime, maxAnimationTime));

    }

    private void StopTypingAnimation()
    {
        animator.SetBool("isVictoryIdle", false);
    }
}
