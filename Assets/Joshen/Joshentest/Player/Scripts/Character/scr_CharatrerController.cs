using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static scr_Models;

public class scr_CharatrerController : MonoBehaviour
{
    private CharacterController characterController;
    private DefaultInput defaultInput;
    private Vector2 input_Movement;
    private Vector2 input_View;

    private Vector3 newCameraRotation;
    private Vector3 newCharacterRotation;

    


    [Header("Referemces")]
    public Transform cameraHolder;
    public Transform feetTransform;
    

    [Header("setting")]
    public PlayerSettingsModel playerSettings;
    //카메라 돌리는거 최대 
    public float viewClamYmin = -70;
    public float viewClamYmax = 80;
    public LayerMask playerMask;

    [Header("Gravity")]
    public float gravityAmount;
    public float gravityMin;
    private float PlayerGravity;

    public Vector3 jumpingForce;
    private Vector3 jumpingForceVelocity;

    [Header("stance")]
    public PlayerStance playerStance;
    public float playerStanceSmoothing;
    public CharacterStance playerStandStance;
    public CharacterStance playerCrouchStance;
    public CharacterStance playerProneStance;
    public float stanceCheckErrorMargin = 0.05f;

    private float cameraHeight;
    private float cameraHeightVelocity;

    private Vector3 stanceCapsuleCenterVelocity;
    private float stanceCapsuleHeightVelocity;

    private bool isSprinting;

    private Vector3 newMovementSpeed;
    private Vector3 newMovementSpeedVelocity;




    private void Awake()
    {
        //input 셋팅 키활당
        defaultInput = new DefaultInput();

        defaultInput.Character.Movement.performed += e => input_Movement = e.ReadValue<Vector2>();
        defaultInput.Character.View.performed += e => input_View = e.ReadValue<Vector2>();

        defaultInput.Character.Jump.performed += e => Jump();
        defaultInput.Character.Crouch.performed += e => Crouch();
        defaultInput.Character.Prone.performed += e => Prone();


        defaultInput.Character.Sprint.performed += e => ToggleSprint();
        defaultInput.Character.SprintReleased.performed += e => StopSprint();
        defaultInput.Enable();

        newCharacterRotation = transform.localRotation.eulerAngles;
        newCameraRotation = cameraHolder.localRotation.eulerAngles;

        characterController = GetComponent<CharacterController>();

        cameraHeight = cameraHolder.localPosition.y;


    }

    private void Update()
    {
        CalculateView();
        CalculateMovement();
        CalculateJump();
        CalculateStance();
        
    }


    private void CalculateView()
    {
        //카메라 좌우 뷰
        newCharacterRotation.y += playerSettings.ViewXSensitivity * (playerSettings.ViewXInverted ? input_View .x: input_View.x) * Time.deltaTime;
        transform.rotation = Quaternion.Euler(newCharacterRotation);


        //카메라 위 아래 뷰
        newCameraRotation.x += playerSettings.ViewYSensitivity * (playerSettings.ViewYInverted ? input_View.y : -input_View.y) * Time.deltaTime;
        //카메라 최대 위 아래 뷰
        newCameraRotation.x = Mathf.Clamp(newCameraRotation.x , viewClamYmin, viewClamYmax);

        cameraHolder.localRotation = Quaternion.Euler(newCameraRotation);

    }

    //움직이는것
    private void CalculateMovement()
    {
        // 여기에 스테미나 넣을수 있음
        if(input_Movement.y <= 0.2)
        {
            isSprinting = false;
        }

        //이동
        var verticalSpeed = playerSettings.WalkingForwardSpeed;
        var horizontalSpeed = playerSettings.WalkingStrafeSpeed;

        //달리기
        if (isSprinting)
        {
            verticalSpeed = playerSettings.RunningForwardSpeed;
            horizontalSpeed = playerSettings.RunningStrafeSpeed;
        }

        if(!characterController.isGrounded)
        //떨어질때 이동 느려지는것
        {
            playerSettings.SpeedEffector = playerSettings.FallingSpeedEffector;
        }
        else if (playerStance == PlayerStance.Crouching)
            //앉았을때 느려짐
        {
            playerSettings.SpeedEffector = playerSettings.CrouchSpeedEffector;
        }
        else if (playerStance == PlayerStance.Prone)
        {    //업드렸을때 느려짐
            playerSettings.SpeedEffector = playerSettings.ProneSpeedEffector;
        }
        else
        {
            playerSettings.SpeedEffector = 1;
        }
        //Effectors

        verticalSpeed *= playerSettings.SpeedEffector;
        horizontalSpeed *= playerSettings.SpeedEffector;

        //부드럽게 움직이는 기능 or falling speed
        newMovementSpeed = Vector3.SmoothDamp(newMovementSpeed, new Vector3(horizontalSpeed * input_Movement.x * Time.deltaTime, 0, verticalSpeed * input_Movement.y * Time.deltaTime), ref newMovementSpeedVelocity, characterController.isGrounded ? playerSettings.MovementSmoothing : playerSettings.fallingSmoothing);
        //newMovementSpeed = new Vector3(horizontalSpeed * input_Movement.x * Time.deltaTime, 0, verticalSpeed * input_Movement.y * Time.deltaTime);

        var movementSpeed = transform.TransformDirection(newMovementSpeed);


        //점프 중력 할당
        if (PlayerGravity > gravityMin)
        {
            PlayerGravity -= gravityAmount * Time.deltaTime;
        }


        if (PlayerGravity < -0.1f && characterController.isGrounded )
        {
            PlayerGravity = -0.1f;
        }


        movementSpeed.y += PlayerGravity;
        movementSpeed += jumpingForce * Time.deltaTime;

     //   defaultInput.Character.Movement.started += ctx => input_Movement = ctx.ReadValue<Vector2>(); defaultInput.Character.Movement.performed += ctx => input_Movement = ctx.ReadValue<Vector2>(); defaultInput.Character.Movement.canceled += ctx => input_Movement = ctx.ReadValue<Vector2>();

        characterController.Move(movementSpeed);

    }

    private void CalculateJump()
    {
        jumpingForce = Vector3.SmoothDamp(jumpingForce, Vector3.zero, ref jumpingForceVelocity, playerSettings.JumpingFalloff);
    }
    private void CalculateStance()
    {
        //웅크릴때 카메라 조정
        var CurrentStance = playerStandStance;

        if(playerStance == PlayerStance.Crouching)
        {
            CurrentStance = playerCrouchStance;
        }
        else if (playerStance == PlayerStance.Prone)
        {
            CurrentStance = playerProneStance;
        }

        cameraHeight = Mathf.SmoothDamp(cameraHolder.localPosition.y, CurrentStance.CamerHeight, ref cameraHeightVelocity, playerStanceSmoothing);

        cameraHolder.localPosition = new Vector3(cameraHolder.localPosition.x, cameraHeight, cameraHolder.localPosition.z);

        characterController.height = Mathf.SmoothDamp(characterController.height, CurrentStance.stanceCollider.height, ref stanceCapsuleHeightVelocity, playerStanceSmoothing);
        characterController.center = Vector3.SmoothDamp(characterController.center, CurrentStance.stanceCollider.center, ref stanceCapsuleCenterVelocity, playerStanceSmoothing);
     }

    private void Jump()
    {
        if (!characterController.isGrounded || playerStance == PlayerStance.Prone)
        {

            return;
        }

        if (playerStance == PlayerStance.Crouching)
        {
            if (StanceCheck(playerStandStance.stanceCollider.height))
            {
                return;
            }

            playerStance = PlayerStance.Standing;
            return;
        }

        //점프
        jumpingForce = Vector3.up * playerSettings.JumpingHeight;
        PlayerGravity = 0;

    }
    //앉기 키 활당
    private void Crouch()
    {
        if(playerStance == PlayerStance.Crouching)
        {
            if (StanceCheck(playerStandStance.stanceCollider.height))
            { 
                return;
            }
        playerStance = PlayerStance.Standing;
            return;
        }


        if (StanceCheck(playerCrouchStance.stanceCollider.height))
        {
            return;
        }
            playerStance = PlayerStance.Crouching;
        
    }

    //업드리기
    private void Prone()
    {
        if (playerStance == PlayerStance.Prone)
        {
            if (StanceCheck(playerStandStance.stanceCollider.height))
            {
                return;
            }
            playerStance = PlayerStance.Standing;
        }
        else if(playerStance == PlayerStance.Standing)
        {
            if (StanceCheck(playerStandStance.stanceCollider.height))
            {
                return;
            }
            playerStance = PlayerStance.Prone;
        }
    }

    private bool StanceCheck(float stanceCheckheight)
    {
       var start = new Vector3(feetTransform.position.x, feetTransform.position.y + characterController.radius + stanceCheckErrorMargin, feetTransform.position.z);
       var end = new Vector3(feetTransform.position.x, feetTransform.position.y - characterController.radius - stanceCheckErrorMargin + stanceCheckheight, feetTransform.position.z);


        return Physics.CheckCapsule(start, end, characterController.radius, playerMask);
    }

    private void ToggleSprint()
    {
        if (input_Movement.y <= 0.2)
        {
            isSprinting = false;
            return;
        }

        isSprinting = !isSprinting;
    }


    //쉬프트 때면 바로멈추기 
    private void StopSprint()
    {
        if(playerSettings.SprintingHold)
        {
            isSprinting = false;
        }

    }





}
    