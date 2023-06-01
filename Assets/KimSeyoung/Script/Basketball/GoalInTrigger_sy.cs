using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalInTrigger_sy : MonoBehaviour
{
    [SerializeField] private GameObject particleGO = null;
    [SerializeField] private SoundManager_sy soundManager = null;

    void Start()
    {
        if (particleGO == null) particleGO = GameObject.Find("GoalParticle");
        particleGO.SetActive(false);
        if (soundManager == null) soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager_sy>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "basketBall_mdl")
        { 
            particleGO.SetActive(true);
            soundManager.ESoundAudioSource.volume = 0.5f;
            soundManager.PlayEffectSound("GoalInSound_");
        }
        
        StartCoroutine("TurnOffParticle");
    }

    private IEnumerator TurnOffParticle()
    {
        yield return new WaitForSeconds(1f);
        particleGO.SetActive(false);
    }
}
