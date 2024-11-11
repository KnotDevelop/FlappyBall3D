using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public int score = 0;
    public int combo = 0;
    public string comboType = "";

    public GameObject great_fx;
    public GameObject perfect_fx;
    public GameObject lostCombo_fx;

    public Color currentColor;
    [SerializeField] Color perfect_color;
    [SerializeField] Color loseCombo_color;
    [SerializeField] Color great_color;

    private void Awake()
    {
        instance = this;
    }
    public int ComboCalculate() 
    {
        return Mathf.FloorToInt(2 + (combo / 5));
    }
    public void GetScore(bool _notPerfect, Transform _pos)
    {
        if (_notPerfect)
        {
            comboType = "Great";
            score += 1;
            combo = 0;
            Debug.Log("Not Perfect Score");

            if (combo > 0)
            {
                currentColor = loseCombo_color;
                Instantiate(lostCombo_fx, _pos);
                return;
            }

            currentColor = great_color;
            Instantiate(great_fx, _pos);
        }
        else
        {
            comboType = "Perfect";
            score += ComboCalculate();
            combo++;
            Debug.Log("Perfect Score");
            currentColor = perfect_color;
            Instantiate(perfect_fx, _pos);
        }
        AudioManager.instance.Play_Note(!_notPerfect);
    }
}
