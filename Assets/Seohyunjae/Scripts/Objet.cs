using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objet : MonoBehaviour
{
    public enum EType { Pluged, Unpluged }

    [SerializeField]
    protected string productName = "Unknown";
    [SerializeField]
    protected EType type = EType.Unpluged;
}
