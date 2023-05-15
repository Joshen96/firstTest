using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class UIMenuButton : MonoBehaviour
{
    public enum EMBInfo { Name, Price, Stock }

    private TextMeshProUGUI[] texts = null;

    private Button btn = null;

    private void Awake()
    {
        texts =
            GetComponentsInChildren<TextMeshProUGUI>();
        //foreach (TextMeshProUGUI text in texts)
        //    Debug.Log(text.name);

        btn = GetComponent<Button>();
    }

    //private void Start()
    //{
    //    InitInfos("ÄÝ¶ó", 600, 3);
    //}

    // Initialization
    public void InitInfos(
        string _name, int _price, int _stock,
        int _num,
        UIMenu.OnClickMenuDelegate _onClickCallback)
    {
        texts[(int)EMBInfo.Name].text = _name;
        texts[(int)EMBInfo.Price].text =
            _price.ToString();
        texts[(int)EMBInfo.Stock].text =
            _stock.ToString();

        btn.onClick.AddListener(() =>
        {
            _onClickCallback?.Invoke(
                _num,
                this);
        });

        btn.interactable = _stock > 0;
    }

    public void InitInfos(
        VendingMachine.SProductInfo _productInfo,
        int _num,
        UIMenu.OnClickMenuDelegate _onClickCallback)
    {
        InitInfos(
            VendingMachine.VMProductToName(_productInfo.product),
            _productInfo.price,
            _productInfo.stock,
            _num,
            _onClickCallback
            );
    }

    public void UpdateInfo(
        VendingMachine.SProductInfo _productInfo)
    {
        texts[(int)EMBInfo.Name].text =
            VendingMachine.VMProductToName(
                _productInfo.product);
        texts[(int)EMBInfo.Price].text =
            _productInfo.price.ToString();
        texts[(int)EMBInfo.Stock].text =
            _productInfo.stock.ToString();

        btn.interactable =
            _productInfo.stock > 0;
    }
}
