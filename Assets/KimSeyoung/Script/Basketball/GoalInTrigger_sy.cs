using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalInTrigger_sy : MonoBehaviour
{
    [SerializeField] private GameObject particleGO = null;
    [SerializeField] private SoundManager_sy soundManager = null;

    void Awake()
    {
        if (particleGO == null) particleGO = GameObject.Find("GoalParticle");
        if (soundManager == null) soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager_sy>();
        particleGO.SetActive(false);
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
