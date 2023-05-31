using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Product_sy : MonoBehaviour
{
    [SerializeField] private VendingMachine_sy.EVMProduct productType;

    public VendingMachine_sy.EVMProduct
    GetProductType() { return productType; }

    public abstract void Use();

    public void DestroyProduct()       // ªË¡¶
    {
        StartCoroutine("IDestroyProduct");
    }

    private IEnumerable IDestroyProduct()
    {
        yield return new WaitForSeconds(3f);
        Destroy(this);
    }
}
