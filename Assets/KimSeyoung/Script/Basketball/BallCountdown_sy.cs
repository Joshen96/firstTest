using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCountdown_sy : MonoBehaviour
{
    [SerializeField] private GameObject[] countdownNumGO = new GameObject[4];

    private SpriteRenderer spriteRenderer = null; 


    private void Awake()
    {
        countdownNumGO[3] = Resources.Load<GameObject>("BallCountdown/count3");
        countdownNumGO[2] = Resources.Load<GameObject>("BallCountdown/count2");
        countdownNumGO[1] = Resources.Load<GameObject>("BallCountdown/count1");
        countdownNumGO[0] = Resources.Load<GameObject>("BallCountdown/go");
    }

    public void CountdownBallNum()
    {
        StartCoroutine(WaitForCountdown(3));
    }

    private IEnumerator WaitForCountdown(int i)
    {
        GameObject number = Instantiate(countdownNumGO[i], transform.position, Quaternion.identity);
        number.transform.localScale = number.transform.localScale - new Vector3(0.7f,0.7f,0);
        spriteRenderer = number.GetComponent<SpriteRenderer>();
        spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 1f);

        yield return new WaitForSeconds(1.3f);
        Destroy(number);

        if (i - 1 >= 0) StartCoroutine(WaitForCountdown(i - 1));
    }

}