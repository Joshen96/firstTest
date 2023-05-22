using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputField_sy : MonoBehaviour
{
    [SerializeField] private BlackBoardManager_sy blackboardManager = null;
    private string inputText = ""; // 입력한 값

    public void InputFieldButtonClick()
    {
        inputText = this.gameObject.GetComponent<TextMeshProUGUI>().text;
        // 입력 텍스트 값 저장
        blackboardManager.CheckTheAnswer(inputText, blackboardManager.answerStr);
        // 입력한 텍스트 값과 정답이 같은지 확인
    }
}
