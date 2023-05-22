using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[ExecuteInEditMode]
public class AroundMoveBall_sy : MonoBehaviour
{
        private enum ERotDir { CW, CCW }                                    // 회전방향 종류
        private enum ERotType { Pitch, Yaw, Roll }                          // 축회전 종류

        #region Public Variables
        [Header("- Game Objects -")]
        [SerializeField] private GameObject ballPrefab = null;              // 펫볼 프리펩
        [SerializeField] private Transform targetTr = null;                 // 플레이어 프리펩 : 골라인 트리거에 공이 닿았을 때 타겟은 골라인 트리거의 중심이 된다.(-)

        [Header("- Values -")]
        [SerializeField, Range(0f, 300f)] private float speed = 100f;       // 회전 속도
        [SerializeField, Range(0f, 10f)] private float distance = 1f;       // 반지름 Radius

        [Header("- Type -")]
        [SerializeField] private ERotDir rotDir = ERotDir.CCW;              // 기본 방향 설정 
        [SerializeField] private ERotType rotType = ERotType.Yaw;           // 기본 회전축 설정
        #endregion


        private Transform ballTr = null;

        private float angle = 0f;

        private void Awake()
        {
            if (ballPrefab == null)
            {
                Debug.LogError("볼 프리펩 설정 안했어, 임뫄~!!!");
                return;
            }

            GameObject go = Instantiate(ballPrefab);
            //go.transform.parent = transform;
            go.transform.SetParent(transform);
            ballTr = go.transform;
        }

        private void Update()
        {
            if (targetTr == null) return;

            // Clamp
            switch (rotDir)
            {
                case ERotDir.CW:
                    angle -= Time.deltaTime * speed;
                    if (angle < 0f) angle = 360f;
                    break;
                case ERotDir.CCW:
                    angle += Time.deltaTime * speed;
                    if (angle > 360f) angle = 0f;
                    break;
            }


            Vector3 anglePos = new Vector3();
            CalcAnglePosWithRotType(
                rotType, angle, ref anglePos);

            Vector3 targetPos = targetTr.position;
            ballTr.position =
                targetPos + (anglePos * distance);
        }

        private void CalcAnglePosWithRotType(
            ERotType _rotType,
            float _angle,
            ref Vector3 _pos)
        {
            float angle2Rad = _angle * Mathf.Deg2Rad;
            switch (_rotType)
            {
                case ERotType.Pitch:
                    _pos.x = 0f;
                    _pos.y = Mathf.Sin(angle2Rad);
                    _pos.z = Mathf.Cos(angle2Rad);
                    break;
                case ERotType.Yaw:
                    _pos.x = Mathf.Cos(angle2Rad);
                    _pos.y = 0f;
                    _pos.z = Mathf.Sin(angle2Rad);
                    break;
                case ERotType.Roll:
                    _pos.x = Mathf.Cos(angle2Rad);
                    _pos.y = Mathf.Sin(angle2Rad);
                    _pos.z = 0f;
                    break;
            }
        }
    
}
