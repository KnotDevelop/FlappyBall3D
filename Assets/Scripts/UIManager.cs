using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    [SerializeField] TextMeshProUGUI score_text;
    [SerializeField] Transform playerPos;
    [SerializeField] Camera cam;
    [SerializeField] TextMeshProUGUI combo_text;

    [SerializeField] Transform comboCanvas;
    [SerializeField] GameObject puase_panel;

    [SerializeField] GameObject finish_panel;
    [SerializeField] TextMeshProUGUI fnnishScore_text;

    [SerializeField] GameObject audio_btn;
    [SerializeField] GameObject audioMute_btn;
    public bool isAudio = true;

    public void AudioButton_Switch()
    {
        if (isAudio)
        {
            audio_btn.SetActive(false);
            audioMute_btn.SetActive(true);
            AudioManager.instance.CloseAllAudio();
            isAudio = false;
        }
        else
        {
            audio_btn.SetActive(true);
            audioMute_btn.SetActive(false);
            AudioManager.instance.OpenAllAudio();
            isAudio = true;
        }
    }
    private void Awake()
    {
        Instance = this;
    }
    public void LoadScene() 
    {
        SceneManager.LoadScene("FlappyBall");
    }
    public void OpenFinishPanel()
    {
        TimeManager.instance.Puase();
        finish_panel.SetActive(true);
        fnnishScore_text.text = ScoreManager.instance.score.ToString();
    }
    public void PuasePanel_Switch(bool _result) 
    {
        puase_panel.SetActive(_result);
        if (_result)
        {
            TimeManager.instance.Puase();
        }
        else 
        {
            TimeManager.instance.Unpuase();
        }
    }
    public void UpdateScore()
    {
        score_text.text = ScoreManager.instance.score.ToString();
    }
    public void SetComboText(Donut donut)
    {
        ScoreManager _scoreManager = ScoreManager.instance;
        combo_text.transform.position = donut.textPos.position;
        comboCanvas.SetParent(donut.textPos);
        combo_text.text = _scoreManager.comboType;
        if (_scoreManager.combo > 0)
            combo_text.text += $"\n x{_scoreManager.combo}";

        combo_text.color = ScoreManager.instance.currentColor;
        comboCanvas.GetComponent<Animator>().SetTrigger("IsActive");
    }
}
