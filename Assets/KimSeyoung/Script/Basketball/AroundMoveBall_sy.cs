using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[ExecuteInEditMode]
public class AroundMoveBall_sy : MonoBehaviour
{
        private enum ERotDir { CW, CCW }                                    // ȸ������ ����
        private enum ERotType { Pitch, Yaw, Roll }                          // ��ȸ�� ����

        #region Public Variables
        [Header("- Game Objects -")]
        [SerializeField] private GameObject ballPrefab = null;              // �꺼 ������
        [SerializeField] private Transform targetTr = null;                 // �÷��̾� ������ : ����� Ʈ���ſ� ���� ����� �� Ÿ���� ����� Ʈ������ �߽��� �ȴ�.(-)

        [Header("- Values -")]
        [SerializeField, Range(0f, 300f)] private float speed = 100f;       // ȸ�� �ӵ�
        [SerializeField, Range(0f, 10f)] private float distance = 1f;       // ������ Radius

        [Header("- Type -")]
        [SerializeField] private ERotDir rotDir = ERotDir.CCW;              // �⺻ ���� ���� 
        [SerializeField] private ERotType rotType = ERotType.Yaw;           // �⺻ ȸ���� ����
        #endregion


        private Transform ballTr = null;

        private float angle = 0f;

        private void Awake()
        {
            if (ballPrefab == null)
            {
                Debug.LogError("�� ������ ���� ���߾�, �Ӹ�~!!!");
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
