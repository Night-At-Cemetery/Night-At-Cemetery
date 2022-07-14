using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    [SerializeField] private float flySpeed;
    
    void Update()
    {
        transform.Translate(  Time.deltaTime * Vector2.left *  flySpeed);
    }
}
