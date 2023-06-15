using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Busstop : MonoBehaviour
{
    public GameObject speedcontrol;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider _other)
    {
        if (_other.tag == "Bus")
        {
            speedcontrol.GetComponent<Scrollbar>().value= 0;
           // Debug.Log("Â÷°¨Áö1");
            StartCoroutine(pass());
        }

        IEnumerator pass()
        {
            yield return new WaitForSeconds(5f);
            speedcontrol.GetComponent<Scrollbar>().value = 0.2f;

        }

    }
}
