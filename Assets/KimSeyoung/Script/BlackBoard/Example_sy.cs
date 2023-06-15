using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// Æ¯Á¤ ±³½Ç°ú ¹®Á¦ ¹øÈ£¿¡ µû¶ó º¸±â ¶ç¿ì±â

public class Example_sy : MonoBehaviour
{
    public void SetExample_Humanities(int _questionNum) // ÀÎ¹®°è
    {
        // ÆùÆ® Å©±â, »ö»ó, ±½±â ¼³Á¤
        this.gameObject.GetComponent<TextMeshProUGUI>().color = Color.red;
        this.gameObject.GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Bold;

        switch (_questionNum)
        {
            case 0:
                this.gameObject.GetComponent<TextMeshProUGUI>().fontSize = 3;
                this.gameObject.GetComponent<TextMeshProUGUI>().text = "[ 1 + 1 = »ÑÁ÷ ]\t[ 1 + 3 = »ÑÁöÁ÷ ]\n" +
                    "[ 3 + 5 = »Ñ¿õ ]\t[ 21 + 9 = »ÑÁ÷»×»× ]\t[ 13 + 35 = »ÑÁöÁ÷»Ñ¿õ ]\n" +
                    "[ 25 + 25 = »ÑÁ÷»×»× ]\t[ 113 + 121 = »ÑÁ÷»ÑÁ÷»ÑÁöÁ÷ ]\n[ 4807 + 4100 = ??? ]";

                break;
            case 1:
                this.gameObject.GetComponent<TextMeshProUGUI>().fontSize = 7;
                this.gameObject.GetComponent<TextMeshProUGUI>().text = "N  W  H  O  I (?)";
                break;
            case 2:
                this.gameObject.GetComponent<TextMeshProUGUI>().fontSize = 7;
                this.gameObject.GetComponent<TextMeshProUGUI>().text = "B  C  D  E  I  K  O  X ";
                break;
        }
    }

    public void SetExample_Engineering(int _questionNum) // ÀÌ°ø°è
    {
        // ÆùÆ® Å©±â, »ö»ó, ±½±â ¼³Á¤
        this.gameObject.GetComponent<TextMeshProUGUI>().color = Color.red;
        this.gameObject.GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Normal;

        switch (_questionNum) 
        {
            case 0:
                {
                    this.gameObject.GetComponent<TextMeshProUGUI>().fontSize = 5;
                    this.gameObject.GetComponent<TextMeshProUGUI>().text 
                        = "[ 2 * 3 = 9 ]\t[5 * 4 = 26]\n" +
                        "[6 * 2 = 13]\t[7 * 4 = (?) ]";}
                break;
            case 1:
                {
                    this.gameObject.GetComponent<TextMeshProUGUI>().fontSize = 6;
                    this.gameObject.GetComponent<TextMeshProUGUI>().text  = "100ÀÇ ¹ÝÀ» 1/2·Î ³ª´« °ªÀº?"; 
                }
                break;
            case 2:
                {
                    this.gameObject.GetComponent<TextMeshProUGUI>().fontSize = 5;
                    this.gameObject.GetComponent<TextMeshProUGUI>().text 
                        = "[ 5 + 3 = 28 ]\t[9 + 1 + 810]\n" +
                        "[8 + 6 = 214]\t[5 + 4 + = 19]\n[7 + 3 = ??? ]";}
                break;
        }
    }
}
