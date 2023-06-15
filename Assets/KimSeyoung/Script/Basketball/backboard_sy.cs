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
    [SerializeField] private LimitTime_sy[] limitTime = new LimitTime_sy[2];
    [SerializeField] private ScoreBoard_sy scoreBoard1 = null;
    [SerializeField] private ScoreBoard_sy scoreBoard2 = null;
    [SerializeField] private Playground_sy playground = null;
    [SerializeField] private BallCountdown_sy ballCountdown = null;

    public bool isPickBall = false;
    public bool isStartGame = false;
    public int score = 0;
    private float scoreGuideDist = 12f;
    private bool isComeInPlayground = false;


    private void Awake()
    {
        if (soundManager == null) soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager_sy>();
        if (ballManager == null) ballManager = GameObject.Find("basketBall_mdl").GetComponent<BallManager_sy>();
        if (goalInTrigger == null) goalInTrigger = GameObject.Find("GoalInTrigger").GetComponent<GoalInTrigger_sy>();
        if (limitTime == null) //Debug.LogError("limitTime �־�!");
            //limitTime[0] = GameObject.Find("LimitTimeCanvas").GetComponent<LimitTime_sy>();

        if (scoreBoard1 == null || scoreBoard2 == null)// Debug.LogError("scoreboard �־�!");
        if (playground == null) playground = GameObject.Find("Playground").GetComponent<Playground_sy>();
        if (ballCountdown == null) ballCountdown = GameObject.Find("BallCountdown").GetComponent<BallCountdown_sy>();
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
                        scoreBoard1.InputScoreToScoreboard(score);
                        scoreBoard2.InputScoreToScoreboard(score);
                    }
                    if (soundManager.ESoundAudioSource.isPlaying) soundManager.StopEffectSound();

                    if (soundManager.BGMaudioSource.clip.name != "outside_Class_sound")
                        soundManager.PlayBGM("outside_Class_sound");

                    for (int i = 0; i < limitTime.Length; i++)
                    {
                        limitTime[i].TimeReset();
                        limitTime[i].textTimer.color = Color.white;
                        limitTime[i].textTimer.text = "�����غ�";
                    }

                    isPickBall = ballManager.isPickBall;
                    isComeInPlayground = playground.isComeInPlayground;

                    if (isPickBall && isComeInPlayground)
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
                        ballCountdown.CountdownBallNum();
                    }

                    if (score != 0) score = 0;

                    StartCoroutine(ChangeState(State.Playing));
                }
                break;
            case State.Playing:
                {
                    if (soundManager.BGMaudioSource.clip.name != "BasketballSound") soundManager.PlayBGM("BasketballSound");

                    // ���ѽð�
                    for (int i = 0; i < limitTime.Length; i++)
                    {
                        limitTime[i].TimeCountdown();
                        float LT = limitTime[i].limitTime;
                        if (LT > 10f)
                        {
                            limitTime[i].textTimer.color = Color.white;
                            int min = (int)LT / 60;
                            int sec = (int)LT % 60;
                            limitTime[i].textTimer.text = min + " : " + sec;
                        }
                        else if (LT <= 10f && LT > 0f)
                        {
                            limitTime[i].textTimer.color = Color.red;
                            int sec = (int)LT % 10;
                            limitTime[i].textTimer.text = sec + "��";

                            soundManager.BGMaudioSource.volume -= Time.deltaTime * 0.15f;
                            if (LT < 5f)
                            {
                                soundManager.StopBGM();
                                if (soundManager.ESoundAudioSource.clip.name != "GameOver") soundManager.PlayEffectSound("GameOver");
                            }
                        }
                        else if (LT <= 0f)
                        {
                            limitTime[i].textTimer.color = Color.blue;
                            limitTime[i].textTimer.text = "��!";
                            state = State.Over;
                        }
                    }
                    // ����
                    if (ballManager.BallToBackboardDis != 0)
                    {
                        if (ballManager.BallToBackboardDis > scoreGuideDist)
                        { 
                            score += 3;
                            scoreBoard1.InputScoreToScoreboard(score);
                            scoreBoard2.InputScoreToScoreboard(score);
                        }
                        else if (ballManager.BallToBackboardDis <= scoreGuideDist)
                        {
                            score += 1;
                            scoreBoard1.InputScoreToScoreboard(score);
                            scoreBoard2.InputScoreToScoreboard(score);
                        }

                        ballManager.BallToBackboardDis = 0;
                    }
                }
                break;
            case State.Over:
                {
                    //������ ���� ����Ʈ �Ҹ� �ٸ��� ����
                    if (score >= 10 && !soundManager.ESoundAudioSource.isPlaying) soundManager.PlayEffectSound("ClearGame");
                    else if (score < 10 && !soundManager.ESoundAudioSource.isPlaying) soundManager.PlayEffectSound("FailGame");

                    if (isPickBall) isPickBall = false;

                    // ���� �����ֱ� ����(-)
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
