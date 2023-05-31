using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class UIMenuButton_sy: MonoBehaviour
{
    public enum EMBInfo { Name, Stock }              // ��ư ����

    private TextMeshProUGUI[] texts = null;
    private Button btn = null;

    private void Awake()
    {
        texts = GetComponentsInChildren<TextMeshProUGUI>();     // ��ư �ڽ����� ���� �ؽ�Ʈ
        btn = GetComponent<Button>();                           // ��ư(�ڱ��ڽ�)
    }

    public void InitInfos( VendingMachine_sy.SProductInfo _productInfo, int _num, UIMenu_sy.OnClickMenuDelegate _onClickCallback)
    {
        texts[(int)EMBInfo.Name].text = VendingMachine_sy.VMProductToName(_productInfo.product);

        btn.onClick.AddListener(() => { _onClickCallback?.Invoke(_num, this); });
        // ��ư ��Ŭ�� �̺�Ʈ�� Delegate ���� �Լ� ���� >> Vending Machine ��ũ��Ʈ�� OnclickButton �Լ� ����

        btn.interactable = _productInfo.stock > 0;
        // ��� 0���� ������ ��ư Ȱ��ȭ
        // �ƴ� ��� ��Ȱ��ȭ
    }

    public void UpdateInfo( VendingMachine_sy.SProductInfo _productInfo)
    {
        texts[(int)EMBInfo.Name].text = VendingMachine_sy.VMProductToName( _productInfo.product);

        btn.interactable = _productInfo.stock > 0;
    }
}
