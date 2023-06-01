using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BC_NPC_Random_Animation : MonoBehaviour
{  
    public Animator animator;
    public string walkAnimationName = "Walk";
    public string phoneAnimationName = "Phone";
    public float phoneAnimationProbability = 0.5f; // Phone �ִϸ��̼��� Ȯ�� (0���� 1 ����)
    public float phoneAnimationSpeed = 1.5f; // Phone �ִϸ��̼��� ��� �ӵ�
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

        if (randomValue < phoneAnimationProbability)
        {
            PlayPhoneAnimation();
        }
        else
        {
            PlayWalkAnimation();
        }

        // ���� �ִϸ��̼� ��� �ð� ����
        float randomTime = Random.Range(minAnimationTime, maxAnimationTime);
        nextAnimationTime = Time.time + randomTime;
    }

    private void PlayWalkAnimation()
    {
        // "walk" �ִϸ��̼� ���
        animator.SetBool("isPhoneAnimation", false);
        animator.Play(walkAnimationName);
    }

    private void PlayPhoneAnimation()
    {
        // "phone" �ִϸ��̼� ���
        animator.SetBool("isPhoneAnimation", true);
        animator.Play(phoneAnimationName);
        animator.speed = phoneAnimationSpeed;
    }
}