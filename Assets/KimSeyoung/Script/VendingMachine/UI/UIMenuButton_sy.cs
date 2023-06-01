using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class UIMenuButton_sy: MonoBehaviour
{
    public enum EMBInfo { Name, Stock }              // 버튼 인포

    private TextMeshProUGUI[] texts = null;
    private Button btn = null;

    private void Awake()
    {
        texts = GetComponentsInChildren<TextMeshProUGUI>();     // 버튼 자식으로 들어가는 텍스트
        btn = GetComponent<Button>();                           // 버튼(자기자신)
    }

    public void InitInfos( VendingMachine_sy.SProductInfo _productInfo, int _num, UIMenu_sy.OnClickMenuDelegate _onClickCallback)
    {
        texts[(int)EMBInfo.Name].text = VendingMachine_sy.VMProductToName(_productInfo.product);

        btn.onClick.AddListener(() => { _onClickCallback?.Invoke(_num, this); });
        // 버튼 온클릭 이벤트에 Delegate 설정 함수 시행 >> Vending Machine 스크립트의 OnclickButton 함수 시행

        btn.interactable = _productInfo.stock > 0;
        // 재고가 0보다 많으면 버튼 활성화
        // 아닐 경우 비활성화
    }

    public void UpdateInfo( VendingMachine_sy.SProductInfo _productInfo)
    {
        texts[(int)EMBInfo.Name].text = VendingMachine_sy.VMProductToName( _productInfo.product);

        btn.interactable = _productInfo.stock > 0;
    }
}
