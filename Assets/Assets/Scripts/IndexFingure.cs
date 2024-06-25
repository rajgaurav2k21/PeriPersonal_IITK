using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndexFingure : MonoBehaviour
{
    [Header("love from rg" )]
    public Transform ColliderPosition;
    public Transform Fingertip;
    void Update()
    {
        Vector3 Finguring = Fingertip.position;
        ColliderPosition.position = Finguring;
    }
}
