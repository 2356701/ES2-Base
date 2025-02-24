using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SousmarinAvance : MonoBehaviour
{
    [SerializeField] private float _vitessePromenade = 5f;
    [SerializeField] private float _vitesseVerticale = 3f;
    private Rigidbody _rb;
    private Vector3 directionInput;
      private Animator _animator;

    void Start()
    {
        _rb = GetComponent<Rigidbody>(); 
          _animator = GetComponent<Animator>(); 
    }

 
    void OnAvance(InputValue directionBase)
    {
        Vector2 input = directionBase.Get<Vector2>();
        directionInput.z = input.y * _vitessePromenade;
        _animator.SetFloat("DeplacementAvance", directionInput.magnitude);
    }

   
    void OnMonter(InputValue etatBouton)
    {
        if (etatBouton.isPressed) 
        {
            Debug.Log("presse");
            directionInput.y = _vitesseVerticale;
            _animator.SetFloat("DeplacementMonte", directionInput.magnitude);
        } 
        else 
        { Debug.Log("lache");
            directionInput.y = 0f;
             _animator.SetFloat("DeplacementMonte", 0f);
        }
    }

   
    void OnDescendre(InputValue etatBouton)
    {
        if (etatBouton.isPressed) 
        {
            Debug.Log("presse");
            directionInput.y = -_vitesseVerticale;
               _animator.SetFloat("DeplacementMonte", directionInput.magnitude);
        } 
        else 
        {  Debug.Log("lache");
            directionInput.y = 0f;
             _animator.SetFloat("DeplacementMonte", 0f);
        }
    }

    void FixedUpdate()
    {
        Vector3 mouvement = directionInput * Time.fixedDeltaTime;
        _rb.MovePosition(_rb.position + mouvement);
    }
}
