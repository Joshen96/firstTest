using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BC_NPC_HIT : MonoBehaviour
{
    public float stunDuration = 3f;
    public XRGrabInteractable grabInteractable;
    public BC_NPC_Traffic_WaypointNavigator waypointNavigator;
    public BC_NPC_Traffic_NavigationController npccont;
    public const string Strangled = "Strangled";
    public Animator animatorP;
    public Animator animatorC;


    private bool isStunned = false;
    private bool isGrab = false;
    private float stunTimer = 2f;
    private Transform playerTransform;

    public Rigidbody rigidbody;

    private void Awake()
    {
        
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (isStunned)
        {
            if (!isGrab)
            {
                stunTimer += Time.deltaTime;
            }
            if (stunTimer >= stunDuration)
            {
                isStunned = false;
                stunTimer = 0f;
                Release();
                // 기절 상태에서 회복한 후 다시 이동하거나 다른 동작을 수행할 수 있도록 처리
                waypointNavigator.enabled = true;
                npccont.enabled = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log($"충돌: {gameObject.name}와 {other.gameObject.name}");
            GetHit();
        }
        
    }


    public void GetHit()
    {
        if (!isStunned)
        {
            isStunned = true;
            stunTimer = 2f;
            

            // 기절 상태에서의 동작 처리
            waypointNavigator.enabled = false;
            npccont.enabled = false;
            animatorP.enabled = false;
            

            // XR Grab Interactable을 활성화하여 NPC를 데려갈 수 있도록 설정
            grabInteractable.enabled = true;
            //animator.Play(Strangled);
            //animator.SetBool(Strangled, false);

            rigidbody.isKinematic = false; // 물리 시뮬레이션 적용
            rigidbody.useGravity = true; // 중력 적용
            rigidbody.constraints = RigidbodyConstraints.None;


        }
    }

    public void Release()
    {
        // NPC를 놓아주고 XR Grab Interactable을 비활성화
        
        grabInteractable.enabled = false;
        animatorP.enabled = true;
        animatorC.enabled = false;
        rigidbody.isKinematic = true;
        animatorP.StopPlayback();

    }

    public void grab_npc()
    {
        animatorC.enabled = true;
        isGrab = true;
        animatorC.SetBool(Strangled, true);

        rigidbody.isKinematic = true; // 물리 시뮬레이션 적용
        rigidbody.useGravity = false;
    }
    public void detach_npc()
    {
        isGrab = false;
        animatorC.SetBool(Strangled, false);
        animatorC.enabled = false;
    }

}
