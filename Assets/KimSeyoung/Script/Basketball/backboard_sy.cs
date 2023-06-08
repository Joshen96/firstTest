using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backboard_sy : MonoBehaviour
{
    public enum State { Preparing, Start, Playing, Over }
    public State state = State.Preparing;

    [SerializeField] private SoundManager_sy soundManager = null;
    [SerializeField] private BallManager_sy ballManager = null;
    [SerializeField] private GoalInTrigger_sy goalInTrigger = null;
    [SerializeField] private LimitTime_sy limitTime = null;
    [SerializeField] private ScoreBoard_sy scoreBoard = null;

    public bool isPickBall = false;
    public bool isStartGame = false;
    public int score = 0;
    private float scoreGuideDist = 12f;


    private void Awake()
    {
        if (soundManager == null) soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager_sy>();
        if (ballManager == null) ballManager = GameObject.Find("basketBall_mdl").GetComponent<BallManager_sy>();
        if (goalInTrigger == null) goalInTrigger = GameObject.Find("GoalInTrigger").GetComponent<GoalInTrigger_sy>();
        if (limitTime == null) limitTime = GameObject.Find("LimitTimeCanvas").GetComponent<LimitTime_sy>();
        if (scoreBoard == null) scoreBoard = GameObject.Find("scoreboard").GetComponent<ScoreBoard_sy>();
    }

    private void Update()
    {
        switch (state)
        {
            case State.Preparing:
                {
                    if (score != 0)
                    {
                        score = 0;
                        scoreBoard.InputScoreToScoreboard(score);
                    }

                    if (soundManager.BGMaudioSource.clip.name != "outside_Class_sound")
                        soundManager.PlayBGM("outside_Class_sound");

                    limitTime.TimeReset();
                    limitTime.textTimer.color = Color.white;
                    limitTime.textTimer.text = "도전해봐";

                    isPickBall = ballManager.isPickBall;
                    if (isPickBall)
                    { 
                        state = State.Start;

                    }
                    
                }
                break;
            case State.Start:
                {
                    soundManager.StopBGM();

                    if(!soundManager.ESoundAudioSource.isPlaying)
                    {
                        soundManager.PlayEffectSound("BasketballCountdown");
                    }

                    // 카운트다운 화면에 나타내기(-)
                    if (score != 0) score = 0;
                    StartCoroutine(ChangeState(State.Playing));
                }
                break;
            case State.Playing:
                {
                    if (soundManager.BGMaudioSource.clip.name != "BasketballSound") soundManager.PlayBGM("BasketballSound");

                    // 제한시간
                    limitTime.TimeCountdown();
                    float LT = limitTime.limitTime;
                    if (LT > 10f)
                    {
                        limitTime.textTimer.color = Color.white;
                        int min = (int)LT / 60;
                        int sec = (int)LT % 60;
                        limitTime.textTimer.text = min + " : " + sec;
                    }
                    else if (LT <= 10f && LT > 0f)
                    {
                        limitTime.textTimer.color = Color.red;
                        int sec = (int)LT % 10;
                        limitTime.textTimer.text = sec + "초";

                        soundManager.BGMaudioSource.volume -= Time.deltaTime * 0.25f;
                        if (LT < 5f)
                        {
                            soundManager.StopBGM();
                            if (soundManager.ESoundAudioSource.clip.name != "GameOver") soundManager.PlayEffectSound("GameOver");
                        }
                    }
                    else if (LT <= 0f)
                    {
                        limitTime.textTimer.color = Color.blue;
                        limitTime.textTimer.text = "끝!";
                        state = State.Over;
                    }

                    // 점수
                    if (ballManager.BallToBackboardDis != 0)
                    {
                        if (ballManager.BallToBackboardDis > scoreGuideDist)
                        { 
                            score += 3;
                            scoreBoard.InputScoreToScoreboard(score);
                        }
                        else if (ballManager.BallToBackboardDis <= scoreGuideDist)
                        {
                            score += 1;
                            scoreBoard.InputScoreToScoreboard(score);
                        }

                        ballManager.BallToBackboardDis = 0;
                    }
                }
                break;
            case State.Over:
                {
                    //점수에 따라 이펙트 소리 다르게 설정
                    if (score >= 10 && !soundManager.ESoundAudioSource.isPlaying) soundManager.PlayEffectSound("ClearGame");
                    else if (score < 10 && !soundManager.ESoundAudioSource.isPlaying) soundManager.PlayEffectSound("FailGame");

                    if (isPickBall) isPickBall = false;

                    // 점수 보여주기 구현(-)
                    StartCoroutine(ChangeState(State.Preparing));
                }
                break;
        }
    }

    private IEnumerator ChangeState(State _state)
    {
        yield return new WaitForSeconds(5.0f);
        state = _state;
    }
}
