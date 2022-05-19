using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthbar : MonoBehaviour
{
    Quaternion rotate;
    void Awake()
    {
        rotate = transform.rotation;
    }
    void LateUpdate()
    {
        transform.rotation = rotate;
    }
}
