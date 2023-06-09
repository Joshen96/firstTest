using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BC_NPC_BENCH : MonoBehaviour
{
    public float sittingDuration = 30f;
    public Animator animator;
    public BC_NPC_Traffic_WaypointNavigator waypointNavigator;
    public BC_NPC_Traffic_NavigationController npcController;

    private bool isSitting = false;
    public GameObject sittingPosition; // ���� ��ġ ����
    private Transform sittingPosition1;
    private Transform sittingPosition2;

    private void Start()
    {
        // ��ġ�� �ڽ� ��ü �� �ϳ��� ���� ��ġ�� ����
        sittingPosition1 = sittingPosition.transform.GetChild(0);
        sittingPosition2 = sittingPosition.transform.GetChild(1);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bench") && !isSitting)
            Debug.Log("Trigger entered");
        {
            StartCoroutine(SitOnBench());
        }
    }

    private IEnumerator SitOnBench()
    {
        isSitting = true;

        // NPC �̵� �� ���� ��ũ��Ʈ ��Ȱ��ȭ
        waypointNavigator.enabled = false;
        npcController.enabled = false;

        // �ɴ� �ִϸ��̼� ����
        animator.SetBool("IsSitting", true);


        // NPC�� ���� ��ġ�� �̵�
       transform.position = sittingPosition1.position;
        transform.rotation = sittingPosition1.localRotation;

        // ���� �ð� ���� ���� ���� ����
        float timer = 0f;
        while (timer < sittingDuration)
        {
            timer += Time.deltaTime;

            transform.position = sittingPosition1.position;
            transform.rotation = sittingPosition1.localRotation; //TEST

            // �ɾ��ִ� �ִϸ��̼� ����
            animator.SetFloat("SittingAnimationSpeed", 1f); // �ɾ��ִ� �ִϸ��̼� ��� �ӵ� ����

            yield return null;
        }

        // �Ͼ�� �ִϸ��̼� ����
        animator.SetFloat("SittingAnimationSpeed", 0f); // �ɾ��ִ� �ִϸ��̼� ��� �ӵ� ����
        animator.SetBool("IsSitting", false);

        // NPC �̵� �� ���� ��ũ��Ʈ �ٽ� Ȱ��ȭ
        waypointNavigator.enabled = true;
        npcController.enabled = true;

        isSitting = false;
    }
}