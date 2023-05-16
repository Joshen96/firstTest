using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager_sy : MonoBehaviour
{
    // 질문에 들어갈 텍스트
    public virtual string questionText()
    { return ""; }

    // 선택지에 들어갈 텍스트
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
