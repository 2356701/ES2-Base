using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SousmarinRecule : MonoBehaviour
{
    private Rigidbody _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void OnRecule()
    {
        _rb.AddRelativeForce(Vector3.back * 1f, ForceMode.VelocityChange);
    }
}
