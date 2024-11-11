using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    public Background background_prefab;
    public float distance = 10.5289f;
    public List<Background> backgrounds = new List<Background>();
    public Transform playerPos;
    public Background currentBG;
    private void Start()
    {
        Spawn();
    }
    private void Update()
    {
        CheckAndSpawnBackground();
    }
    void CheckAndSpawnBackground()
    {
        if (playerPos.position.x >= currentBG.startPoint.position.x)
        {
            Spawn();
        }
    }
    void Spawn()
    {
        Background _bg = Instantiate(background_prefab, transform);
        _bg.gameObject.SetActive(true);
        _bg.transform.position = new Vector3(currentBG.transform.position.x + distance, 0, currentBG.transform.position.z);
        if (backgrounds.Count >= 3)
        {
            Destroy(backgrounds[0].gameObject);
            backgrounds.RemoveAt(0);
        }
        currentBG = _bg;
        backgrounds.Add(_bg);
    }
}
