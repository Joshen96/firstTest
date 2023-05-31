using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BC_NPC_Random_chairAnimation : MonoBehaviour
{
    public Animator animator;
    public string walkAnimationName = "Walk";
    public string sitAnimationName = "Sit";
    public string phoneAnimationName = "Phone";
    public float phoneAnimationProbability = 0.5f; // Phone �ִϸ��̼��� Ȯ�� (0���� 1 ����)
    public float phoneAnimationSpeed = 1.5f; // Phone �ִϸ��̼��� ��� �ӵ�
    public float minAnimationTime = 2f; // �ּ� �ִϸ��̼� ��� �ð�
    public float maxAnimationTime = 5f; // �ִ� �ִϸ��̼� ��� �ð�

    private bool isSitting = false; // NPC�� �ɾ� �ִ��� ����
    private float sitTimer = 0f; // NPC�� �ɾ� �ִ� �ð��� �����ϴ� Ÿ�̸� ����
    public float sitDuration = 5f; // �ɾ� �ִ� �ð�

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
                // �ɾ� �ִ� �ð��� ������ �Ͼ�� ������ �ִϸ��̼� ���
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
            // ���� Ʈ���ſ� ���� �� �ɴ� �ִϸ��̼� ���
            isSitting = true;
            animator.SetBool("isSitAnimation", true);
            sitTimer = 3f;
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
        Invoke("PlayRandomAnimation", randomTime);
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