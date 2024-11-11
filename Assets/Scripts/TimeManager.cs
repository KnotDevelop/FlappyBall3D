using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TimeManager : MonoBehaviour
{
    public static TimeManager instance;
    float gameTimeScale = 1f;
    public bool isPuase = false;

    private void Awake()
    {
        instance = this;
    }
    public void Puase()
    {
        isPuase = true;
        Ball.Instance.SaveVelocity();
        gameTimeScale = 0;
    }
    public void Unpuase()
    {
        isPuase = false;
        StartCoroutine(Ball.Instance.SetCurrentVelocity());
        gameTimeScale = 1;
    }
    public void SetTimeScale(int _scale)
    {
        gameTimeScale = _scale;
    }
    public float GetTimeScale()
    {
        return gameTimeScale;
    }
}
