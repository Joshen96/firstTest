using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BC_NPC_SIT_Random_Ainmation : MonoBehaviour
{
    public Animator animator;
    public string SitOneAnimationName = "Sitting";
    public string SitTwoAnimationName = "SittingTwo";
    public string SitThreeAnimationName = "SittingThree";
    public float SitAnimationProbability = 0.5f; // Phone �ִϸ��̼��� Ȯ�� (0���� 1 ����)
    public float SitAnimationSpeed = 1.5f; // Phone �ִϸ��̼��� ��� �ӵ�
    public float minAnimationTime = 2f; // �ּ� �ִϸ��̼� ��� �ð�
    public float maxAnimationTime = 5f; // �ִ� �ִϸ��̼� ��� �ð�

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
            SitPhoneAnimation();
            PlayWalkAnimation();
        }
        

        // ���� �ִϸ��̼� ��� �ð� ����
        float randomTime = Random.Range(minAnimationTime, maxAnimationTime);
        nextAnimationTime = Time.time + randomTime;
    }

    private void PlayWalkAnimation()
    {
        // "walk" �ִϸ��̼� ���
        animator.SetBool("isSitAnimation", false);
        animator.Play(SitOneAnimationName);
    }

    private void PlayPhoneAnimation()
    {
        // "phone" �ִϸ��̼� ���
        animator.SetBool("isSitTwoAnimation", true);
        animator.Play(SitTwoAnimationName); 
        animator.speed = SitAnimationSpeed;
    }
    private void SitPhoneAnimation()
    {
        // "phone" �ִϸ��̼� ���
        animator.SetBool("isSitThreeAnimation", true);
        animator.Play(SitTwoAnimationName);
        animator.speed = SitAnimationSpeed;
    }
}
