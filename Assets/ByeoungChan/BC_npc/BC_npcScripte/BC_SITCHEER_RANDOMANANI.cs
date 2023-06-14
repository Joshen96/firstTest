using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BC_SITCHEER_RANDOMANANI : MonoBehaviour
{
    public Animator animator;
    public string SitAnimationName = "Sitting";
    public string CheeringWhileSittingAnimationName = "Cheering While Sitting";
    public string CheeringWhileSittingOneAnimationName = "Cheering While Sitting1";
    public string CheeringWhileSittingTwoAnimationName = "Cheering While Sitting2";
    public string CheeringWhileSittingThreeAnimationName = "Cheering While Sitting3";
    public string SittingClapAnimationName = "Sitting Clap";
    public string SittingClapOneAnimationName = "Sitting Clap (1)";
    public string SittingClapTwoAnimationName = "Sitting Clap (2)";
    public string SittingClapThreeAnimationName = "Sitting Clap (3)";
    //public string SittingClapFourAnimationName = "";
    public string StandingCheeringAnimationName = "Standing Cheering";
    public string StandingClapAnimationName = "Standing Clap";
    public string StandingFistPumpAnimationName = "Standing Fist Pump";
    public string FistPumpAnimationName = "Fist Pump";
    public string FistPumpOneAnimationName = "Fist Pump (1)";
    //public string AnimationName = "";


    public float SitAnimationProbability = 0.1f; // Phone �ִϸ��̼��� Ȯ�� (0���� 1 ����)
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
            PlaySittingAnimation();
        }
        else
        {
            PlayCheeringWhileSittingAnimation();
            PlayCheeringOneWhileSittingAnimation();
            PlayCheeringTwoWhileSittingAnimation();
            PlayCheeringThreeWhileSittingAnimation();
            SittingClapAnimation();
            SittingClapOneAnimation();
            SittingTwoClapAnimation();
            SittingThreeClapAnimation();
            StandingCheerAnimation();
            StandingClapAnimation();
            StandingFistPumpAnimation();
            FistPumpAnimation();
            FistPumpOneAnimation();
            StopTypingAnimation();



        }


        // ���� �ִϸ��̼� ��� �ð� ����
        float randomTime = Random.Range(minAnimationTime, maxAnimationTime);
        nextAnimationTime = Time.time + randomTime;
    }

    private void PlaySittingAnimation()
    {
        
        animator.SetBool("isSitting", false);
        animator.Play(SitAnimationName);
    }

    private void PlayCheeringWhileSittingAnimation()
    {
        
        animator.SetBool("isCheeringWhileSitting", true);
        animator.Play(CheeringWhileSittingAnimationName);

    }
    private void PlayCheeringOneWhileSittingAnimation()
    {
        
        animator.SetBool("isCheeringOneWhileSitting", true);
        animator.Play(CheeringWhileSittingOneAnimationName);

    }
    private void PlayCheeringTwoWhileSittingAnimation()
    {
       
        animator.SetBool("isCheeringTwoWhileSitting", true);
        animator.Play(CheeringWhileSittingTwoAnimationName);

    }
    private void PlayCheeringThreeWhileSittingAnimation()
    {
        
        animator.SetBool("isCheeringThreeWhileSitting", true);
        animator.Play(CheeringWhileSittingThreeAnimationName);

    }
    private void SittingClapAnimation()
    {
        
        animator.SetBool("isSittingClap", true);
        animator.Play(SittingClapAnimationName);

    }
    private void SittingClapOneAnimation()
    {
        
        animator.SetBool("isSittingClapOne", true);
        animator.Play(SittingClapOneAnimationName);

    }
    private void SittingTwoClapAnimation()
    {
       
        animator.SetBool("isSittingClapTwo", true);
        animator.Play(SittingClapTwoAnimationName);

    }
    private void SittingThreeClapAnimation()
    {
        
        animator.SetBool("isSittingClapThree", true);
        animator.Play(SittingClapThreeAnimationName);

    }
    private void StandingCheerAnimation()
    {
        
        animator.SetBool("isStandingCheer", true);
        animator.Play(StandingCheeringAnimationName);

    }
    private void StandingClapAnimation()
    {
        
        animator.SetBool("isStandingClap", true);
        animator.Play(StandingClapAnimationName);

    }
    private void StandingFistPumpAnimation()
    {
        
        animator.SetBool("isStandingFistPump", true);
        animator.Play(StandingFistPumpAnimationName);
        //Invoke(nameof(StopTypingAnimation), Random.Range(minAnimationTime, maxAnimationTime));

    }

    private void FistPumpAnimation()
    {
        
        animator.SetBool("isFistPump", true);
        animator.Play(FistPumpAnimationName);

    }
    private void FistPumpOneAnimation()
    {
        
        animator.SetBool("isFistPumpOne", true);
        animator.Play(FistPumpOneAnimationName);

    }

    private void StopTypingAnimation()
    {
        animator.SetBool("isVictoryIdle", false);
    }
}
