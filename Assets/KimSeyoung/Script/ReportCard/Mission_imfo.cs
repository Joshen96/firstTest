using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission_imfo : MonoBehaviour
{
    public static Mission_imfo Instance;

    public static bool isSolvingProblem;

    public static bool isFindingCat;
    public static bool isShootingFirecraker;
    public static bool isPlayingBasketball;
    public static bool isCatchingThief;
    public static bool isFindingEasteregg;
   

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }


}
