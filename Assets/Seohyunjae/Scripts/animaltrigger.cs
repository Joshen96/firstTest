using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class animaltrigger : MonoBehaviour
{
   
    public Transform animals;
    float scrPlayDist = 2f;
    // ���� ���� ȸ�� �ӵ�
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision _other)
    {
        if (_other.gameObject.tag == "Animals")
        {
            Debug.Log("�������� ����");


        }           

    }
    private void Update()
    {
        DebugDistance();
    }
    private void DebugDistance()
    {
        Vector3 dirToTarget =
            animals.position - this.transform.position;

        Color color = Color.white;

        if (scrPlayDist < dirToTarget.magnitude)
            color = Color.black;
        else
            color = Color.green;

        Debug.DrawLine(
            this.transform.position,
            animals.position,
            color);
    }
  

}
