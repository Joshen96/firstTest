using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMenu : MonoBehaviour
{
    public delegate void OnClickMenuDelegate(int _btnNum, UIMenuButton _menuBtn);

    [SerializeField]
    private GameObject menuBtnPrefab = null;

    private List<UIMenuButton> menuBtnList = null;


    public void BuildButtons(
        List<VendingMachine.SProductInfo> _productInfoList,
        OnClickMenuDelegate _onClickCallback)
    {
        if (_productInfoList == null ||
            _productInfoList.Count == 0) return;

        if (menuBtnList != null &&
            menuBtnList.Count > 0)
            ClearMenuButtonList();

        menuBtnList = new List<UIMenuButton>();
        //menuBtnList.Clear();

        for (int i = 0; i < _productInfoList.Count; ++i)
        {
            GameObject go = Instantiate(menuBtnPrefab);
            //go.transform.SetParent(transform);
            //go.transform.localPosition = Vector3.zero;
            RectTransform rectTr =
                go.GetComponent<RectTransform>();
            rectTr.SetParent(GetComponent<RectTransform>());
            rectTr.localPosition =
                CalcLocalPositionWithIndex(i, _productInfoList.Count);

            UIMenuButton btn =
                go.GetComponent<UIMenuButton>();
            //btn.InitInfos(
            //    _productInfoList[i].product.ToString(),
            //    _productInfoList[i].price,
            //    _productInfoList[i].stock
            //    );
            btn.InitInfos(_productInfoList[i],
                          i,
                          _onClickCallback);

            //Button button = go.GetComponent<Button>();
            //button.onClick.AddListener(
            //    // 람다식(Lambda Expression)
            //    () =>
            //    {
            //        Debug.Log(i);
            //        _onClickCallback?.Invoke(i);
            //    }
            //);

            menuBtnList.Add(btn);
        }

        //Debug.Log(menuBtnList.Count);
    }

    private void ClearMenuButtonList()
    {
        // Range Based Loop
        foreach (UIMenuButton btn in menuBtnList)
        {
            Destroy(btn.gameObject);
        }
        menuBtnList.Clear();
    }

    /// <summary>
    /// 버튼 위치 구하는 함수
    /// </summary>
    /// <param name="_idx">현재 인덱스</param>
    /// <param name="_totalCnt">버튼 전체 갯수</param>
    /// <returns></returns>
    private Vector3 CalcLocalPositionWithIndex(int _idx, int _totalCnt)
    {
        if (_idx < 0 || _totalCnt < 1) return Vector3.zero;

        const int COL_MAX = 3;

        Vector2 bgSize = transform.GetChild(0).GetComponent<RectTransform>().sizeDelta;
        Vector2 btnSize = menuBtnPrefab.GetComponent<RectTransform>().sizeDelta;

        int colCnt = Mathf.Clamp(_totalCnt, 1, COL_MAX);
        float btnTotalW = colCnt * btnSize.x;
        float totalOffsetW = bgSize.x - btnTotalW;

        int rowCnt = (int)Mathf.Ceil((float)_totalCnt / colCnt);
        float btnTotalH = rowCnt * btnSize.y;
        float totalOffsetH = bgSize.y - btnTotalH;

        Vector2 offset = Vector2.zero;
        offset.x = totalOffsetW / (float)(colCnt + 1);
        offset.y = totalOffsetH / (float)(rowCnt + 1);

        Vector2 btnDist = offset + btnSize;
        Vector2 startPos = new Vector2(
            -btnDist.x / (colCnt % 2 == 0 ? 2f : 1f),
            btnDist.y / (rowCnt % 2 == 0 ? 2f : 1f)
            );

        Vector3 pos = Vector3.zero;
        if (colCnt > 1) pos.x = startPos.x + ((_idx % COL_MAX) * btnDist.x);
        if (rowCnt > 1) pos.y = startPos.y - ((_idx / COL_MAX) * btnDist.y);

        return pos;
    }

    public void UpdateButtonInfo(
        int _btnNum,
        VendingMachine.SProductInfo _productInfo)
    {
        menuBtnList[_btnNum].UpdateInfo(_productInfo);
    }
}
