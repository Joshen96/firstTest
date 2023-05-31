using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendingMachine_sy : MonoBehaviour
{
    public enum EVMProduct
    {
        Firecracker, ElectricToothbrush, Gun
    }

    [System.Serializable] public struct SProductInfo
    {
        public EVMProduct product;
        public int stock;

        public bool CheckStock() { return stock > 0; }
        public void Sell() { if (CheckStock()) --stock; }
        public void ReturnStock() { if (!CheckStock()) ++stock;  } // (-)
    }

    [SerializeField] private UIMenu_sy uiMenu = null;
    [SerializeField] private List<SProductInfo> productInfoList = new List<SProductInfo>();

    private void Awake()
    {
        if (uiMenu == null)
        {
            Debug.LogError("UIMenu is missing!");
            return;
        }
    }

    private void OnTriggerEnter(Collider _other)
    {
        if (_other.CompareTag("Player"))
        {
            if (uiMenu)
            {
                uiMenu.gameObject.SetActive(true);
                uiMenu.BuildButtons(productInfoList, OnClickMenu);
            }
        }
    }

    private void OnTriggerExit(Collider _other)
    {
        if (_other.CompareTag("Player"))
        {
            if (uiMenu != null)
            {
                uiMenu.gameObject.SetActive(false);
            }
        }
    }

    public static string VMProductToName(EVMProduct _product)
    {
        switch (_product)
        {
            case EVMProduct.Firecracker: return "������";
            case EVMProduct.ElectricToothbrush: return "�Ŀ�ĩ��";
            case EVMProduct.Gun: return "��";
            default: return "��???";
        }
    }

    public void OnClickMenu( int _btnNum, UIMenuButton_sy _menuBtn)
    {
        if (!productInfoList[_btnNum].CheckStock()) return;

        SProductInfo changeInfo = productInfoList[_btnNum];
        changeInfo.Sell();
        productInfoList[_btnNum] = changeInfo;

        // ��ǰ �����
        GameObject prefab = ProductSpawnManager_sy.GetPrefab( productInfoList[_btnNum].product);
        if (prefab != null)
        {
            // ���Ǳ� �տ� ����
            Instantiate(prefab, transform.position + new Vector3 (0f, 0.5f, -1f), Quaternion.identity);
        }

        // ��� ����� ��ư ���� �ʱ�ȭ
        _menuBtn.UpdateInfo(changeInfo);
    }
}        











    //private Vector3 GetValidSpawnPosition()
    //{
    //    const float SPAWN_DIST = 3f;            // ���� �Ÿ�
    //    const float PI2 = Mathf.PI * 2f;        // 360���� ��ġ�ϱ� ����
    //    const float POS_Y = 0.5f;               // �ٴڿ��� �˻��ϸ� ��Ȯ���� ��������� ���� ���, ���߿� 0���� ����

    //    Vector3 startPos = transform.position;  // ���̽�� ������ ��ġ
    //    startPos.y += POS_Y;
    //    bool isValidPos = false;                // ��ȿ�� ��ġ����
    //    float angle = 0f;                       // ���� ���� ��������
    //    RaycastHit hitInfo;                     // ���� ��Ʈ ����
    //    Vector3 spawnPos = Vector3.zero;        // ������ ��ġ

    //    while (!isValidPos)
    //    {
    //        // ���� ���� ���
    //        angle = Random.Range(0f, PI2);
    //        spawnPos = transform.position + new Vector3( Mathf.Cos(angle) * SPAWN_DIST, POS_Y, Mathf.Sin(angle) * SPAWN_DIST);
    //        Vector3 dir = (spawnPos - startPos).normalized;

    //        // ������ ��ġ �ĺ��� ���� ���� �浹�˻�
    //        if (Physics.Raycast(startPos, dir, out hitInfo, SPAWN_DIST))
    //        {
    //            // �浹�� ������Ʈ�� �ִٸ� �ٸ� ��ġ�� ã�ƾ� ��
    //            Debug.Log("Raycast Hit: " + hitInfo.transform.name);
    //            continue;
    //        }
    //        isValidPos = true;
    //    }
    //    spawnPos.y -= POS_Y;// ���̸� �ٽ� ������� 

    //    return spawnPos;
    //}