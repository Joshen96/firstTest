using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager_sy : MonoBehaviour
{
    // ������ �� �ؽ�Ʈ
    public virtual string questionText()
    { return ""; }

    // �������� �� �ؽ�Ʈ
    public virtual string optionText1() 
    { return ""; }
    public virtual string optionText2() 
    { return ""; }
    public virtual string optionText3() 
    { return ""; }
    public virtual string optionText4() 
    { return ""; }
    public virtual string optionText5() 
    { return ""; }
}
