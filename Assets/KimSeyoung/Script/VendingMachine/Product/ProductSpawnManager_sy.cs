using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductSpawnManager_sy
{
    private static List<GameObject> productPrefabList = null;

    public static GameObject GetPrefab( VendingMachine_sy.EVMProduct _productType)
    {
        if (productPrefabList == null)
        {
            GameObject[] prefabs = Resources.LoadAll<GameObject>("Products");
            productPrefabList = new List<GameObject>(prefabs);
        }

        foreach (GameObject prefab in productPrefabList)
        {
            Product_sy product = prefab.GetComponent<Product_sy>();
            if (product.GetProductType() == _productType)
                return prefab;
        }
        return null;
    }
}
