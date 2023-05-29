using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Carsppedpercent : MonoBehaviour
{

    TextMeshProUGUI text;
    public GameObject carspeedControl;
    float scrollbar;


    public void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
     
    }
 
    public void Update()
    {
        scrollbar = carspeedControl.GetComponent<Scrollbar>().value;
        string speed = Mathf.Round(scrollbar * 100).ToString();


        text.text = speed +"%";
    }
}