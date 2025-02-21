using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SousmarinAvance : MonoBehaviour
{
    private Rigidbody _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void OnAvance()
    {
        _rb.AddRelativeForce(Vector3.forward * 1f, ForceMode.VelocityChange);
    }
}
