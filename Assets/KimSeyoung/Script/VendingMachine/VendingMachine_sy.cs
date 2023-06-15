using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendingMachine_sy : MonoBehaviour
{
    [SerializeField] private GameObject SpawnPoint = null;

    public enum EVMProduct
    {
        Firecracker, buttonPushHammer
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
            //Debug.LogError("UIMenu is missing!");
            return;
        }

        if (SpawnPoint == null) SpawnPoint = GameObject.Find("SpawnPoint");
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
            case EVMProduct.Firecracker: return "폭죽총";
            case EVMProduct.buttonPushHammer: return "버튼망치";
            default: return "롸???";
        }
    }

    public void OnClickMenu( int _btnNum, UIMenuButton_sy _menuBtn)
    {
        if (!productInfoList[_btnNum].CheckStock()) return;

        SProductInfo changeInfo = productInfoList[_btnNum];
        changeInfo.Sell();
        productInfoList[_btnNum] = changeInfo;

        // 상품 만들기
        GameObject prefab = ProductSpawnManager_sy.GetPrefab( productInfoList[_btnNum].product);
        if (prefab != null)
        {
            // 자판기 앞에 생성
            Instantiate(prefab, SpawnPoint.transform.position, Quaternion.identity);
        }

        // 재고 변경된 버튼 정보 초기화
        _menuBtn.UpdateInfo(changeInfo);
    }
}        











    //private Vector3 GetValidSpawnPosition()
    //{
    //    const float SPAWN_DIST = 3f;            // 생성 거리
    //    const float PI2 = Mathf.PI * 2f;        // 360도로 배치하기 위해
    //    const float POS_Y = 0.5f;               // 바닥에서 검사하면 정확도가 떨어질까봐 위로 띄움, 나중에 0으로 복구

    //    Vector3 startPos = transform.position;  // 레이쏘기 시작할 위치
    //    startPos.y += POS_Y;
    //    bool isValidPos = false;                // 유효한 위치인지
    //    float angle = 0f;                       // 랜덤 각도 임의저장
    //    RaycastHit hitInfo;                     // 레이 히트 정보
    //    Vector3 spawnPos = Vector3.zero;        // 생성할 위치

    //    while (!isValidPos)
    //    {
    //        // 랜덤 각도 얻기
    //        angle = Random.Range(0f, PI2);
    //        spawnPos = transform.position + new Vector3( Mathf.Cos(angle) * SPAWN_DIST, POS_Y, Mathf.Sin(angle) * SPAWN_DIST);
    //        Vector3 dir = (spawnPos - startPos).normalized;

    //        // 생성할 위치 후보를 향해 레이 충돌검사
    //        if (Physics.Raycast(startPos, dir, out hitInfo, SPAWN_DIST))
    //        {
    //            // 충돌된 오브젝트가 있다면 다른 위치를 찾아야 됨
    //            Debug.Log("Raycast Hit: " + hitInfo.transform.name);
    //            continue;
    //        }
    //        isValidPos = true;
    //    }
    //    spawnPos.y -= POS_Y;// 높이를 다시 원래대로 

    //    return spawnPos;
    //}