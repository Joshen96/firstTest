using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BC_NPCSITCHEER : MonoBehaviour
{
    public Animator animator;
    public float randomAnimationDuration = 5f; // ���� �ִϸ��̼� ��� �ð�

    private void Start()
    {
        StartCoroutine(PlayRandomAnimationCoroutine());
    }

    private IEnumerator PlayRandomAnimationCoroutine()
    {
        while (true) // ����ؼ� �ݺ��ϱ� ���� ���� ���� ���
        {
            // ������ �ִϸ��̼� ����
            int randomAnimation = Random.Range(1, 14); // 1���� 13������ ������ ���� ����

            // �ִϸ��̼� �Ķ���� ����
            animator.SetInteger("RandomAnimation", randomAnimation);

            // ���� �ִϸ��̼� ����
            animator.SetBool("IsSitting", true);

            // ���� �ִϸ��̼� ���� ���
            yield return new WaitForSeconds(randomAnimationDuration);

            // ���� �ִϸ��̼� ����
            animator.SetBool("IsSitting", false);

            // �ٸ� ���� �ִϸ��̼� ������ ���� ��� ���
            yield return new WaitForSeconds(0.3f);
        }
    }
}