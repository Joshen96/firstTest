using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class Player : MonoBehaviour
{
    private PlayerController playerCtrl = null;

    private Electronics electronics = null;

    [SerializeField]
    //private Queue<Product> inventory =
    //    new Queue<Product>();
    private Queue<VendingMachine.EVMProduct> inventory =
        new Queue<VendingMachine.EVMProduct>();

    [SerializeField] private UIMoney uiMoney = null;
    private int money = 10000;

    public int Money { get { return money; } }

    private void Awake()
    {
        playerCtrl = GetComponent<PlayerController>();
        playerCtrl.SetMLBDelegate(OnMLBDown);
        playerCtrl.SetMRBDelegate(OnMRBDown);
        playerCtrl.SetUseDelegate(UseProduct);
    }

    private void Start()
    {
        uiMoney.UpdatePosition(transform.position);
        uiMoney.UpdateMoney(money);
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.U))
        //    UseProduct();
        uiMoney.UpdatePosition(transform.position);
    }

    private void OnTriggerEnter(Collider _other)
    {
        //if (_other.gameObject.tag == "Electronics")
        if (_other.gameObject.CompareTag("Electronics"))
        {
            electronics =
                _other.GetComponent<Electronics>();
            //Debug.Log("Get Electronics");
        }

        if (_other.CompareTag("Product"))
        {
            //GetProduct(_other.GetComponent<Product>());
            Product product =
                _other.GetComponent<Product>();
            GetProduct(product.GetProductType());
            Destroy(product.gameObject);
        }
    }

    private void OnTriggerExit(Collider _other)
    {
        if (_other.CompareTag("Electronics"))
        {
            electronics = null;
        }
    }

    public void OnMLBDown()
    {
        // Power On/Off
        if (electronics)
        {
            if (electronics.GetIsPowerOn())
                electronics.PowerOff();
            else
                electronics.PowerOn();
        }

        //Debug.Log("On Mouse Left Button");
    }

    public void OnMRBDown()
    {
        // Use
        if (electronics != null)
        {
            electronics.Use();
        }

        //Debug.Log("On Mouse Right Button");
    }

    public void GetProduct(
        //Product _product
        VendingMachine.EVMProduct _product
        )
    {
        inventory.Enqueue(_product);

        StringBuilder sb = new StringBuilder();
        //foreach (Product product in inventory)
        foreach (VendingMachine.EVMProduct product
                in inventory)
        {
            //sb.Append(product.name + " - ");
            //sb.Append(product.name);
            sb.Append(product.ToString());
            sb.Append(" - ");
        }

        //sb.Append("(" + inventory.Count + ")");
        sb.Append("(");
        sb.Append(inventory.Count);
        sb.Append(")");

        Debug.Log(sb.ToString());
    }

    public void UseProduct()
    {
        if (inventory.Count == 0) return;
        //Product product = inventory.Dequeue();
        //product.Use();
        VendingMachine.EVMProduct product =
            inventory.Dequeue();
        Product.UseWithType(product, this);

        //Product.UseWithType(inventory.Dequeue(), this);
    }

    public void Buy(int _price)
    {
        if (_price > money) return;
        money -= _price;

        if (uiMoney) uiMoney.UpdateMoney(money);
    }
}
