using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Product_sy : MonoBehaviour
{
    [SerializeField] private VendingMachine_sy.EVMProduct productType;

    public VendingMachine_sy.EVMProduct
    GetProductType() { return productType; }

    public abstract void Use();

    public static void UseWithType(VendingMachine_sy.EVMProduct _productType)
    {
        switch (_productType)
        {
            case VendingMachine_sy.EVMProduct.Firecracker:
                Debug.Log("Firecracker");
                break;
            case VendingMachine_sy.EVMProduct.ElectricToothbrush:
                Debug.Log("ElectricToothbrush");
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
        { 
            StartCoroutine("DestroyProduct");
            Product_sy product = GetComponent<Product_sy>();
            Destroy(this);
        }
    }

    private IEnumerable DestroyProduct()
    {
        yield return new WaitForSeconds(3f);
        Destroy(this);
    }
}
