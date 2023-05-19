using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputField_sy : MonoBehaviour
{
    [SerializeField] private BlackBoardManager_sy blackboardManager = null;
    private string inputText = ""; // �Է��� ��

    public void InputFieldButtonClick()
    {
        inputText = this.gameObject.GetComponent<TextMeshProUGUI>().text;
        // �Է� �ؽ�Ʈ �� ����
        blackboardManager.CheckTheAnswer(inputText, blackboardManager.answerStr);
        // �Է��� �ؽ�Ʈ ���� ������ ������ Ȯ��
    }
}
