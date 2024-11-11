using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    [SerializeField] float liftTime = 1.0f;

    private void Start()
    {
        Destroy(gameObject, liftTime);
    }
}
