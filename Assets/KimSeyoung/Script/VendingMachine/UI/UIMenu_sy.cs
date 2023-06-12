using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMenu_sy : MonoBehaviour
{
    public delegate void OnClickMenuDelegate(int _btnNum, UIMenuButton_sy _menuBtn);           // Onclick 함수

    [SerializeField] private GameObject menuBtnPrefab = null;                               // 버튼 프리펩

    private List<UIMenuButton_sy> menuBtnList = null;                                          // 버튼 리스트


    public void BuildButtons( List<VendingMachine_sy.SProductInfo> _productInfoList, OnClickMenuDelegate _onClickCallback)
    {
        if (_productInfoList == null || _productInfoList.Count == 0) return;
        if (menuBtnList != null && menuBtnList.Count > 0) ClearMenuButtonList();

        menuBtnList = new List<UIMenuButton_sy>();

        for (int i = 0; i < _productInfoList.Count; ++i)
        {
            // 버튼 생성
            GameObject go = Instantiate(menuBtnPrefab);
            RectTransform rectTr = go.GetComponent<RectTransform>();
            rectTr.SetParent(GetComponent<RectTransform>());
            rectTr.localPosition = CalcLocalPositionWithIndex(i, _productInfoList.Count);
            rectTr.localRotation = Quaternion.Euler(0, 0, 0);

            // 버튼 내 내용 설정
            UIMenuButton_sy btn = go.GetComponent<UIMenuButton_sy>();
            btn.InitInfos(_productInfoList[i], i, _onClickCallback);
            menuBtnList.Add(btn);
        }
    }

    private void ClearMenuButtonList()
    {
        foreach (UIMenuButton_sy btn in menuBtnList) Destroy(btn.gameObject);
        menuBtnList.Clear();
    }

    private Vector3 CalcLocalPositionWithIndex(int _idx, int _totalCnt)
    {
        if (_idx < 0 || _totalCnt < 1) return Vector3.zero;

        const int COL_MAX = 2;

        Vector2 bgSize = transform.GetChild(0).GetComponent<RectTransform>().sizeDelta;
        Vector2 btnSize = menuBtnPrefab.GetComponent<RectTransform>().sizeDelta;

        int colCnt = Mathf.Clamp(_totalCnt, 1, COL_MAX);        // 가로 갯수
        float btnTotalW = colCnt * btnSize.x;
        float totalOffsetW = bgSize.x - btnTotalW;

        int rowCnt = (int)Mathf.Ceil((float)_totalCnt / colCnt); // 세로 갯수
        float btnTotalH = rowCnt * btnSize.y;
        float totalOffsetH = bgSize.y - btnTotalH;

        Vector2 offset = Vector2.zero;
        offset.x = totalOffsetW / (float)(colCnt + 1);
        offset.y = totalOffsetH / (float)(rowCnt + 1);

        Vector2 btnDist = offset + btnSize;
        Vector2 startPos = new Vector2( -btnDist.x / (colCnt % 2 == 0 ? 2f : 1f), btnDist.y / (rowCnt % 2 == 0 ? 2f : 1f));


        Vector3 pos = Vector3.zero;
        if (colCnt > 1) pos.x = startPos.x + ((_idx % COL_MAX) * btnDist.x);
        if (rowCnt > 1) pos.y = startPos.y - ((_idx / COL_MAX) * btnDist.y);

        return pos;
    }

    public void UpdateButtonInfo(int _btnNum, VendingMachine_sy.SProductInfo _productInfo)
    { menuBtnList[_btnNum].UpdateInfo(_productInfo); }
}
