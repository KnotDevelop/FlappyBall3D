using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public Transform startPoint;
    public Transform DonutList;
    public List<GameObject> doutPrefabs = new List<GameObject>();
    public bool isFirst = false;
    private void Start()
    {
        if (isFirst) return;
        SpawnDonut();
    }
    public void SpawnDonut()
    {
        int _rlc = Random.Range(4, DonutList.childCount + 1);
        List<int> _rnList = GenerateUniqueRandomNumbers(0, DonutList.childCount, _rlc);
        for (int i = 0; i < _rnList.Count; i++)
        {
            int _rn = Random.Range(0, doutPrefabs.Count);
            GameObject _go = Instantiate(doutPrefabs[_rn], DonutList.GetChild(_rnList[i]));
            int _rpos = Random.Range(0, 3);
            _go.transform.position = new Vector3(_go.transform.position.x, -0.8f + (0.8f * _rpos), _go.transform.position.z);
        }
    }
    List<int> GenerateUniqueRandomNumbers(int min, int max, int count)
    {
        if (count > max - min + 1)
        {
            Debug.LogError("Count cannot exceed the range of possible numbers.");
            return null;
        }

        HashSet<int> uniqueNumbers = new HashSet<int>();
        List<int> resultList = new List<int>();

        while (uniqueNumbers.Count < count)
        {
            int randomNumber = Random.Range(min, max);
            if (!uniqueNumbers.Contains(randomNumber))
            {
                uniqueNumbers.Add(randomNumber);
                resultList.Add(randomNumber);
            }
        }

        return resultList;
    }
}
