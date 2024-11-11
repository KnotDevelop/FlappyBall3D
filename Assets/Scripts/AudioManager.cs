using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField] AudioSource background;
    [SerializeField] AudioSource gameOver;
    [SerializeField] AudioSource jump;
    [SerializeField] AudioSource dead;
    [SerializeField] AudioSource click;
    [SerializeField] AudioSource note;

    [SerializeField] List<AudioClip> normalNoteList;
    [SerializeField] List<AudioClip> perfectNoteList;
    [SerializeField] int makeScoreCount = 0;

    private void Awake()
    {
        instance = this;
    }
    public void Play_Background()
    {
        background.Play();
    }
    public void Stop_Background()
    {
        background.Stop();
    }
    public void Play_GameOver()
    {
        gameOver.Play();
    }
    public void Play_Jump() 
    {
        jump.Play();
    }
    public void Play_Dead()
    {
        dead.Play();
    }
    public void Play_Click()
    {
        click.Play();
    }
    public void Play_Note(bool isPerfect)
    {
        if (isPerfect) 
        {
            note.clip = perfectNoteList[makeScoreCount];
        }
        else
        {
            note.clip = normalNoteList[makeScoreCount];
        }
        note.Play();
        makeScoreCount++;
        int _t = Mathf.Min(normalNoteList.Count, perfectNoteList.Count);
        if (makeScoreCount >= _t) makeScoreCount = 0;
    }
    public void OpenAllAudio()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<AudioVolume>().OpenSound();
        }
    }
    public void CloseAllAudio()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<AudioVolume>().CloseSound();
        }
    }
}
