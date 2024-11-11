using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    Coroutine difCurve;
    void Start()
    {
        TimeManager.instance.isPuase = true;
        UIManager.Instance.UpdateScore();
        TimeManager.instance.SetTimeScale(0);
        Ball.Instance.SaveVelocity();
        AudioManager.instance.Play_Background();
    }
    public void StartGame()
    {
        TimeManager.instance.Unpuase();
        difCurve = StartCoroutine(Ball.Instance.DifficultCurve());
    }
    public void StopGame()
    {
        StopCoroutine(difCurve);
    }
}
