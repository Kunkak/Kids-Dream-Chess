using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{
    public static Clock instance;

    public GameObject blackClockGO, whiteClockGO;
    Text blackClock, whiteClock;
    public float time, timeFor3DMove;
    float whiteTime, blackTime, time3D;

    private bool isStopped;

    private void Awake()
    {
        if(instance == null)
            instance = this;
    }

    void Start()
    {
        blackClock = blackClockGO.GetComponent<Text>();
        whiteClock = whiteClockGO.GetComponent<Text>();
        whiteTime = time;
        blackTime = time;

        whiteClock.text = ToString(whiteTime);
        blackClock.text = ToString(blackTime);
    }

    void Update()
    {
        if (isStopped)
        {
            if (GameManager.instance.is3DActive)
            {
                Clock3DMode();
            }

            return;
        }

        if (GameManager.instance.playing && GameManager.instance.whiteTurn && GameManager.instance.turnNumber != 0)
        {
            whiteTime -= Time.deltaTime;
            if (whiteTime < 0)
            {
                whiteClock.text = ToString(0f);
                GameManager.instance.GameOver(-2);
                return;
            }
            whiteClock.text = ToString(whiteTime);
        }
        else if(GameManager.instance.playing && GameManager.instance.turnNumber != 0)
        {
            blackTime -= Time.deltaTime;
            if (blackTime < 0)
            {
                blackClock.text = ToString(0f);
                GameManager.instance.GameOver(2);
                return;
            }
            blackClock.text = ToString(blackTime);
        }
    }

    private string ToString(float time)
    {
        if(time >= 59)
        {
            string seconds = ((int)time % 60).ToString("00");
            string minutes = ((int)time / 60).ToString("00");

            return minutes + ":" + seconds;
        }
        else
        {
            return time.ToString("00.00");
        }
    }

    public void Pause()
    {
        isStopped = true;
    }

    public void Unpause()
    {
        isStopped = false;
    }

    public void Set3DClock()
    {
        Pause();
        time3D = timeFor3DMove;
    }

    public void Set2DClock()
    {
        Unpause();
        whiteClock.text = ToString(whiteTime);
        blackClock.text = ToString(blackTime);
    }

    public void Clock3DMode()
    {
        time3D -= Time.deltaTime;

        if (time3D < 0)
        {
            GameManager.instance.ChangeTo2D();
        }
        else if (GameManager.instance.whiteTurn)
        {
            whiteClock.text = ToString(time3D);
        }
        else
        {
            blackClock.text = ToString(time3D);
        }
        
    }
}
