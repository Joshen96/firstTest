using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalInTrigger_sy : MonoBehaviour
{
    [SerializeField] private GameObject particleGO = null;

    void Start()
    {
        if (particleGO == null) particleGO = GameObject.Find("GoalParticle");
        particleGO.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "basketBall_mdl") particleGO.SetActive(true);
        StartCoroutine("TurnOffParticle");
    }

    private IEnumerator TurnOffParticle()
    {
        yield return new WaitForSeconds(1f);
        particleGO.SetActive(false);
    }
}
