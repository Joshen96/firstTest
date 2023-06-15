using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BC_NPC_BENCH : MonoBehaviour
{
    public float sittingDuration = 30f;
    public Animator animator;
    public BC_NPC_Traffic_WaypointNavigator waypointNavigator;
    public BC_NPC_Traffic_NavigationController npcController;
    public BC_NPC_Random_Animation ranDomAni;

    private bool isSitting = false;
    private Transform sittingPosition;
    

    private static int numSittingNPCs = 0; // �ɾ��ִ� NPC ��
    private static bool isSeatAvailable = true;// ���� �� �ִ� �������� ����

    private void Start()
    {
        ranDomAni = GetComponent<BC_NPC_Random_Animation>();
        GameObject[] benchSeats = GameObject.FindGameObjectsWithTag("BenchSeat");

        if (benchSeats.Length == 2)
        {
            if (numSittingNPCs == 0)
            {
                // ù ��° NPC�� ���ʿ� ����
                sittingPosition = benchSeats[0].transform;
            }
            else if (numSittingNPCs == 1)
            {
                // �� ��° NPC�� �����ʿ� ����
                if (sittingPosition == benchSeats[0].transform)
                {
                    // �̹� ���ʿ� ���� ���, �����ʿ� ���� �ʵ��� ��Ȱ��ȭ
                    gameObject.SetActive(false);
                }
                else
                {
                    sittingPosition = benchSeats[1].transform;
                }
            }
            else
            {
                // �̹� NPC 2���� �ɾ������� �ش� NPC�� ��ġ�� ���� �ʵ��� ��Ȱ��ȭ
                gameObject.SetActive(false);
            }
        }
        else
        {
            //Debug.LogError("Two BenchSeat objects with the 'BenchSeat' tag are required.");
        }
        isSeatAvailable = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bench") && !isSitting && numSittingNPCs < 2)
        {
            isSeatAvailable = false;
            StartCoroutine(SitOnBench());
        }
    }

    private IEnumerator SitOnBench()
    {
        isSitting = true;

        // �ɴ� �ִϸ��̼� ����
        animator.SetBool("IsSitting", true);

        // NPC �̵� �� ���� ��ũ��Ʈ ��Ȱ��ȭ
        waypointNavigator.enabled = false;
        npcController.enabled = false;
        ranDomAni.enabled = false;

        // NPC�� ���� ��ġ�� �̵�
        transform.position = sittingPosition.position;
        transform.rotation = sittingPosition.rotation;

        // ���� NPC �� ����
        numSittingNPCs++;

        // ���� �ð� ���� ���� ���� ����
        yield return new WaitForSeconds(sittingDuration);

        // �Ͼ�� �ִϸ��̼� ����
        animator.SetBool("IsSitting", false);

        // NPC �̵� �� ���� ��ũ��Ʈ �ٽ� Ȱ��ȭ
        waypointNavigator.enabled = true;
        npcController.enabled = true;
        ranDomAni.enabled = true;

        // ���� NPC �� ����
        numSittingNPCs--;

        isSitting = false;
    }
}