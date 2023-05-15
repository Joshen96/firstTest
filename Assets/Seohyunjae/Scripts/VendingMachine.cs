using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendingMachine : MonoBehaviour
{
    public enum EVMProduct
    {
        Coke, Tissue, Bread, Letsbe,
        Vita500, OronaminC, Sprite,
        SSOrange
    }

    [System.Serializable]
    public struct SProductInfo
    {
        public EVMProduct product;
        public int price;
        public int stock;

        public bool CheckStock() { return stock > 0; }
        public void Sell() {
            if (CheckStock()) --stock;
        }
    }

    [SerializeField]
    private UIMenu uiMenu = null;

    // Template
    [SerializeField]
    private List<SProductInfo> productInfoList
        = new List<SProductInfo>();

    private Player player = null;


    private void Awake()
    {
        if (uiMenu == null)
        {
            Debug.LogError("UIMenu is missing!");
            return;
        }
    }

    // ��ǰ �Ǹ�, ����

    // UI ��ȣ�ۿ�
    private void OnTriggerEnter(Collider _other)
    {
        if (_other.CompareTag("Player"))
        {
            if (uiMenu)
            {
                uiMenu.gameObject.SetActive(true);
                uiMenu.BuildButtons(
                    productInfoList,
                    OnClickMenu);

                // ���� ��ȣ�ۿ� �� �÷��̾�
                player = _other.GetComponent<Player>();
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

                player = null;
            }
        }
    }

    public static string VMProductToName(EVMProduct _product)
    {
        switch (_product)
        {
            case EVMProduct.Coke: return "�ݶ�";
            case EVMProduct.Tissue: return "����";
            case EVMProduct.Bread: return "��";
            case EVMProduct.Letsbe: return "������";
            case EVMProduct.Vita500: return "��Ÿ500";
            case EVMProduct.OronaminC: return "���γ���C";
            case EVMProduct.Sprite: return "��������Ʈ";
            case EVMProduct.SSOrange: return "�ٽ� ������";
            default: return "��?��";
        }
    }

    public void OnClickMenu(
        int _btnNum,
        UIMenuButton _menuBtn)
    {
        //Debug.Log(
        //    productInfoList[_btnNum].product.ToString() +
        //    "(" +
        //    productInfoList[_btnNum].price +
        //    "): " +
        //    productInfoList[_btnNum].stock
        //    );
        if (player == null) return;

        if (!productInfoList[_btnNum].CheckStock())
            return;

        // if (�÷��̾�.��������Ѱ�(�ݾ�))
        if (productInfoList[_btnNum].price >
            player.Money)
        {
            Debug.Log("�ܾ��� �����մϴ�.");
            return;
        }

        //--productInfoList[_btnNum].stock;
        //productInfoList[_btnNum].Sell();
        SProductInfo changeInfo =
            productInfoList[_btnNum];
        changeInfo.Sell();
        productInfoList[_btnNum] = changeInfo;

        // ��ǰ �����
        GameObject prefab =
            ProductSpawnManager.GetPrefab(
                productInfoList[_btnNum].product);
        if (prefab != null)
        {
            // ���Ǳ� �ֺ��� ����
            Instantiate(
                prefab,
                GetValidSpawnPosition(),
                Quaternion.identity);
        }

        // ������ �� ����
        player.Buy(productInfoList[_btnNum].price);

        // ��ư ���� ����
        //uiMenu.UpdateButtonInfo(
        //    _btnNum,
        //    changeInfo);
        _menuBtn.UpdateInfo(changeInfo);
    }

    private Vector3 GetValidSpawnPosition()
    {
        const float SPAWN_DIST = 3f;            // ���� �Ÿ�
        const float PI2 = Mathf.PI * 2f;        // 360���� ��ġ�ϱ� ����
        const float POS_Y = 0.5f;               // �ٴڿ��� �˻��ϸ� ��Ȯ���� ��������� ���� ���, ���߿� 0���� ����

        Vector3 startPos = transform.position;  // ���̽�� ������ ��ġ
        startPos.y = POS_Y;
        bool isValidPos = false;                // ��ȿ�� ��ġ����
        float angle = 0f;                       // ���� ���� ��������
        RaycastHit hitInfo;                     // ���� ��Ʈ ����

        Vector3 spawnPos = Vector3.zero;        // ������ ��ġ
        while (!isValidPos)
        {
            // ���� ���� ���
            angle = Random.Range(0f, PI2);
            spawnPos = transform.position +
                new Vector3(
                    Mathf.Cos(angle) * SPAWN_DIST,
                    POS_Y,
                    Mathf.Sin(angle) * SPAWN_DIST
                );

            Vector3 dir = (spawnPos - startPos).normalized;
            //dir.Normalize();
            // ������ ��ġ �ĺ��� ���� ���� �浹�˻�
            if (Physics.Raycast(startPos, dir, out hitInfo, SPAWN_DIST))
            {
                // �浹�� ������Ʈ�� �ִٸ� �ٸ� ��ġ�� ã�ƾ� ��
                Debug.Log("Raycast Hit: " + hitInfo.transform.name);
                continue;
            }

            isValidPos = true;
        }

        // ���̸� �ٽ� 0����
        spawnPos.y = 0f;
        return spawnPos;
    }
}