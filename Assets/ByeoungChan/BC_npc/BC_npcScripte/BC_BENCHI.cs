using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BC_BENCHI : MonoBehaviour
{
    [SerializeField]
    private Transform sittingPosition; // �ɴ� ��ġ
    [SerializeField]
    private bool isOccupied = false;

    public float sittime = 10f;
    public float time = 0f;

    public bool IsOccupied()
    {
        return isOccupied;
    }

    public void SetOccupied(bool occupied)
    {
        isOccupied = occupied;
        
    }

    private void Update()
    {
        if(isOccupied==true)
        {
            time += Time.deltaTime;
            if (time >= sittime)
            {
                this.gameObject.GetComponent<BoxCollider>().enabled = true;
                isOccupied = false;
                time = 0f;
            }
        }
    }

    public Transform GetSittingPosition()
    {
        return sittingPosition;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Npc") && !isOccupied)
        {
            BC_NPC_bench_or_chair npcScript = other.GetComponent<BC_NPC_bench_or_chair>();
            if (npcScript != null)
            {
                
                
                    if (!npcScript.IsSitting()) // �ٸ� NPC�� �ɾ����� ���� ��쿡�� �ɰ� ��
                    {

                        npcScript.SitOnBench(sittingPosition);
                        this.gameObject.GetComponent<BoxCollider>().enabled = false;
                        isOccupied = true;
                    }
                
            }
        }
    }
    /*
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Npc"))
        {
            BC_NPC_bench_or_chair npcScript = other.GetComponent<BC_NPC_bench_or_chair>();
            if (npcScript != null)
            {
                if (npcScript.IsSitting()) // �ɾ��ִ� NPC�� ��쿡�� �Ͼ�� ��
                {
                    npcScript.StandUpFromBench();
                    
                    isOccupied = false;
                }
            }
        }
    }
    */
}