using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Electronics : Objet
{
    [SerializeField]
    private int price = 0;
    // 전원 케이블이 꽂혀있는지 여부
    private bool isPluged = true;
    private bool isPowerOn = false;

    public int Price { get { return price; } }
    // Inline Function
    public bool GetIsPowerOn() { return isPowerOn; }

    public virtual void Awake()
    {
        type = EType.Pluged;
    }

    public void PowerOn()
    {
        if (isPluged)
        {
            isPowerOn = true;
            Debug.Log(productName + " Power On");
        }
    }

    public void PowerOff()
    {
        if (isPowerOn)
        {
            isPowerOn = false;
            Debug.Log(productName + " Power Off");
        }
    }

    public abstract void Use();
    //public virtual void Use() { }
}
