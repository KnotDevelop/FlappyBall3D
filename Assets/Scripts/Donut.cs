using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Donut : MonoBehaviour
{
    public bool isHitDonut = false;
    public bool isGeted = false;
    public bool isFromTop = false;
    public Transform textPos;
    public void GetScore()
    {
        if (!isFromTop) return;
        if (isGeted) return;
        Debug.Log("Get Score");
        ScoreManager.instance.GetScore(isHitDonut , transform);
        UIManager.Instance.UpdateScore();
        UIManager.Instance.SetComboText(this);
        isGeted = true;
    }
    public void HitDonut()
    {
        if(isHitDonut) return;
        isHitDonut = true;

        Debug.Log("Hit Donut");
    }
    public void FromTop()
    {
        if (isFromTop) return;
        isFromTop = true;

        Debug.Log("From Top");
    }
}
