using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BC_NPC_TALK : MonoBehaviour
{
        [SerializeField]
        private Transform sittingPosition; // 앉는 위치
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
            if (isOccupied == true)
            {
                time += Time.deltaTime;
                if (time >= sittime)
                {
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
                BC_NPC_TALKTWO npcScript = other.GetComponent<BC_NPC_TALKTWO>();
                if (npcScript != null)
                {


                    if (!npcScript.IsTalk()) // 다른 NPC가 앉아있지 않은 경우에만 앉게 함
                    {

                        npcScript.SitOnBench(sittingPosition);
                        isOccupied = true;
                    }

                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Npc"))
            {
                BC_NPC_TALKTWO npcScript = other.GetComponent<BC_NPC_TALKTWO>();
                if (npcScript != null)
                {
                    if (npcScript.IsTalk()) // 앉아있는 NPC인 경우에만 일어나게 함
                    {
                        npcScript.StandUpFromBench();
                        isOccupied = false;
                    }
                }
            }
        }
    }