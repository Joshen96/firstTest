using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BC_NPC_bench_or_chair : MonoBehaviour
{
    public float sittingDuration = 30f;
    public Animator animator;
    public BC_NPC_Traffic_WaypointNavigator waypointNavigator;
    public BC_NPC_Traffic_NavigationController npcController;
    public BC_NPC_Random_Animation ranDomAni;

    private bool isSitting = false;

    private void Start()
    {
        ranDomAni = GetComponent<BC_NPC_Random_Animation>();
    }

    public bool IsSitting()
    {
        return isSitting;
    }

    public void SitOnBench(Transform sittingPosition)
    {
        if (!isSitting)
        {
            StartCoroutine(SitOnBenchCoroutine(sittingPosition));
        }
    }

    private IEnumerator SitOnBenchCoroutine(Transform sittingPosition)
    {
        animator.Rebind(); // �ִϸ����� �ʱ�ȭ

        isSitting = true;

        // �ɴ� �ִϸ��̼� ����
        animator.SetBool("IsSitting", true);

        // �ȴ� �ִϸ��̼� ����
        

        // NPC �̵� �� ���� ��ũ��Ʈ ��Ȱ��ȭ
        waypointNavigator.enabled = false;
        npcController.enabled = false;
        ranDomAni.enabled = false;

        // NPC�� ���� ��ġ�� �̵�
        transform.position = sittingPosition.position;
        transform.rotation = sittingPosition.rotation;

        // ���� �ð� ���� ���� ���� ����
        yield return new WaitForSeconds(sittingDuration);

        StandUpFromBench();

        isSitting = false;

        // �ȴ� �ִϸ��̼� �簳
       
    }

    public void StandUpFromBench()
    {
        // �Ͼ�� �ִϸ��̼� ����
        animator.SetBool("IsSitting", false);

        // NPC �̵� �� ���� ��ũ��Ʈ �ٽ� Ȱ��ȭ
        waypointNavigator.enabled = true;
        npcController.enabled = true;
        ranDomAni.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bench"))
        {
            BC_BENCHI benchScript = other.GetComponentInChildren<BC_BENCHI>();
            
            if (benchScript != null && !benchScript.IsOccupied())
            {
                Debug.Log("����� ������ �˻��ϴ°�"+benchScript.IsOccupied());
                SitOnBench(benchScript.GetSittingPosition());
                benchScript.SetOccupied(true);




            }
            Debug.Log("�˻���Ѱ�" + benchScript.IsOccupied());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Bench"))
        {
            BC_BENCHI benchScript = other.GetComponentInChildren<BC_BENCHI>();
            if (benchScript != null)
            {
                //benchScript.SetOccupied(false);
            }
        }
    }
}






