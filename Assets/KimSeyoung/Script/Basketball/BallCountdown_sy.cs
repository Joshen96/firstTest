using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCountdown_sy : MonoBehaviour
{
    [SerializeField] private GameObject[] countdownNumGO = new GameObject[4];

    private bool isInstantiateGO = true;

    public float fadeDuration = 1f;
    private float fadeTimer = 0.0f; 
    private SpriteRenderer spriteRenderer = null; 


    private void Awake()
    {
        countdownNumGO[3] = Resources.Load<GameObject>("BallCountdown/count3");
        countdownNumGO[2] = Resources.Load<GameObject>("BallCountdown/count2");
        countdownNumGO[1] = Resources.Load<GameObject>("BallCountdown/count1");
        countdownNumGO[0] = Resources.Load<GameObject>("BallCountdown/go");

        fadeTimer = fadeDuration;
    }

    public void CountdownBallNum()
    {
        if (!isInstantiateGO) return;
        isInstantiateGO = false;

        fadeTimer -= Time.deltaTime;

        for (int i = 3; i >= 0; i--)
        {
            countdownNumGO[i].SetActive(true);

            spriteRenderer = countdownNumGO[i].GetComponent<SpriteRenderer>();

            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 1f);

            if (fadeTimer <= 0f) 
            {
                gameObject.SetActive(false);
            }
            else 
            {
                float alpha = fadeTimer / fadeDuration;
                Color spriteColor = spriteRenderer.color;
                spriteColor.a = alpha;
                spriteRenderer.color = spriteColor;
            }
        }



    }

}