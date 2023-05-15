using System;
using System.Collections.Generic;
using UnityEngine;

public class scr_Models : MonoBehaviour
{
    #region - player -

    public enum PlayerStance
    {
        Standing,
        Crouching,
        Prone
    }

    [Serializable]
    public class PlayerSettingsModel
    {
        //카메라 마우스로 돌림?
        [Header("View setting")]
        public float ViewXSensitivity;
        public float ViewYSensitivity;

        public bool ViewXInverted;
        public bool ViewYInverted;

        [Header("Movement Settings")]
        public bool SprintingHold;
        public float MovementSmoothing;

        [Header("Stand Up Settings")]
        public bool BodyUp;

        [Header("Movement - Running")]
        public float RunningForwardSpeed;
        public float RunningStrafeSpeed;

        [Header("Movement - Walking")]
        public float WalkingForwardSpeed;
        public float WalkingBackwardSpeed;
        public float WalkingStrafeSpeed;

        [Header("Jumping")]
        public float JumpingHeight;
        public float JumpingFalloff;
        public float fallingSmoothing;

        [Header("Spped Effectors")]
        public float SpeedEffector = 1;
        public float CrouchSpeedEffector;
        public float ProneSpeedEffector;
        public float FallingSpeedEffector;

    }
    [Serializable]
    public class CharacterStance
    {
        public float CamerHeight;
        public CapsuleCollider stanceCollider;
    }
    #endregion

}
