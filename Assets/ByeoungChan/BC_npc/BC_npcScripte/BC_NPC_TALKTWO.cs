using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BC_NPC_TALKTWO : MonoBehaviour
{
    public float sittingDuration = 30f;
    public Animator animator;
    public BC_NPC_Traffic_WaypointNavigator waypointNavigator;
    public BC_NPC_Traffic_NavigationController npcController;
    public BC_NPC_Random_Animation ranDomAni;
    //public BC_NPC_BENCHI_RANDOM_ANI benchiRandom;
    public int randomAnimation;

    private bool isSitting = false;

    private void Start()
    {
        ranDomAni = GetComponent<BC_NPC_Random_Animation>();
    }

    public bool IsTalk()
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

        switch (randomAnimation)
        {
            case 2:
                animator.SetBool("IsTalking", true);
                break;
            case 3:
                animator.SetBool("IsSittingThree", true);
                break;
            case 4:
                animator.SetBool("IsSitting4", true);
                break;
            case 5:
                animator.SetBool("IsSitting5", true);
                break;
            case 6:
                animator.SetBool("IsSitting6", true);
                break;
            default:
                animator.SetBool("IsSittingTwo", true); // �⺻������ ����
                break;
        }

        // �ɴ� �ִϸ��̼� ����
        animator.SetBool("IsSitting", true);

        //benchiRandom.enabled = true;

        // �ȴ� �ִϸ��̼� ����


        // NPC �̵� �� ���� ��ũ��Ʈ ��Ȱ��ȭ
        waypointNavigator.enabled = false;
        npcController.enabled = false;
        ranDomAni.enabled = false;

        // NPC�� ���� ��ġ�� �̵�
        transform.position = sittingPosition.position;
        transform.rotation = sittingPosition.rotation;

        randomAnimation = Random.Range(1, 6);
        animator.SetInteger("RandomAnimation", randomAnimation);
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
        /*benchiRandom.enabled = false*/
        ;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TalkNpc"))
        {
            BC_BENCHI benchScript = other.GetComponentInChildren<BC_BENCHI>();

            if (benchScript != null && !benchScript.IsOccupied())
            {
                //Debug.Log("����� ������ �˻��ϴ°�" + benchScript.IsOccupied());
                SitOnBench(benchScript.GetSittingPosition());
                benchScript.SetOccupied(true);




            }
            //Debug.Log("�˻���Ѱ�" + benchScript.IsOccupied());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("TalkNpc"))
        {
            BC_BENCHI benchScript = other.GetComponentInChildren<BC_BENCHI>();
            if (benchScript != null)
            {
                //benchScript.SetOccupied(false);
            }
        }
    }

}

