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

    // 상품 판매, 생성

    // UI 상호작용
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

                // 현재 상호작용 할 플레이어
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
            case EVMProduct.Coke: return "콜라";
            case EVMProduct.Tissue: return "휴지";
            case EVMProduct.Bread: return "빵";
            case EVMProduct.Letsbe: return "레쓰비";
            case EVMProduct.Vita500: return "비타500";
            case EVMProduct.OronaminC: return "오로나민C";
            case EVMProduct.Sprite: return "스프라이트";
            case EVMProduct.SSOrange: return "쌕쌕 오렌지";
            default: return "몰?루";
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

        // if (플레이어.돈이충분한가(금액))
        if (productInfoList[_btnNum].price >
            player.Money)
        {
            Debug.Log("잔액이 부족합니다.");
            return;
        }

        //--productInfoList[_btnNum].stock;
        //productInfoList[_btnNum].Sell();
        SProductInfo changeInfo =
            productInfoList[_btnNum];
        changeInfo.Sell();
        productInfoList[_btnNum] = changeInfo;

        // 상품 만들기
        GameObject prefab =
            ProductSpawnManager.GetPrefab(
                productInfoList[_btnNum].product);
        if (prefab != null)
        {
            // 자판기 주변에 생성
            Instantiate(
                prefab,
                GetValidSpawnPosition(),
                Quaternion.identity);
        }

        // 보유한 돈 차감
        player.Buy(productInfoList[_btnNum].price);

        // 버튼 정보 갱신
        //uiMenu.UpdateButtonInfo(
        //    _btnNum,
        //    changeInfo);
        _menuBtn.UpdateInfo(changeInfo);
    }

    private Vector3 GetValidSpawnPosition()
    {
        const float SPAWN_DIST = 3f;            // 생성 거리
        const float PI2 = Mathf.PI * 2f;        // 360도로 배치하기 위해
        const float POS_Y = 0.5f;               // 바닥에서 검사하면 정확도가 떨어질까봐 위로 띄움, 나중에 0으로 복구

        Vector3 startPos = transform.position;  // 레이쏘기 시작할 위치
        startPos.y = POS_Y;
        bool isValidPos = false;                // 유효한 위치인지
        float angle = 0f;                       // 랜덤 각도 임의저장
        RaycastHit hitInfo;                     // 레이 히트 정보

        Vector3 spawnPos = Vector3.zero;        // 생성할 위치
        while (!isValidPos)
        {
            // 랜덤 각도 얻기
            angle = Random.Range(0f, PI2);
            spawnPos = transform.position +
                new Vector3(
                    Mathf.Cos(angle) * SPAWN_DIST,
                    POS_Y,
                    Mathf.Sin(angle) * SPAWN_DIST
                );

            Vector3 dir = (spawnPos - startPos).normalized;
            //dir.Normalize();
            // 생성할 위치 후보를 향해 레이 충돌검사
            if (Physics.Raycast(startPos, dir, out hitInfo, SPAWN_DIST))
            {
                // 충돌된 오브젝트가 있다면 다른 위치를 찾아야 됨
                Debug.Log("Raycast Hit: " + hitInfo.transform.name);
                continue;
            }

            isValidPos = true;
        }

        // 높이를 다시 0으로
        spawnPos.y = 0f;
        return spawnPos;
    }
}