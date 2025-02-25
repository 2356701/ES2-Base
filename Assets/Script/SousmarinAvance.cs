using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SousmarinAvance : MonoBehaviour
{
    [SerializeField] private float _vitessePromenade = 5f;
    [SerializeField] private float _vitesseVerticale = 3f;
    [SerializeField] private float _boostPromenade = 25f;
    [SerializeField] private float _boostVerticale = 20f;

    private float _vitesseActuellePromenade;
    private float _vitesseActuelleVerticale;

    private Rigidbody _rb;
    private Vector3 directionInput;
      private Animator _animator;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        
       

        _vitesseActuellePromenade = _vitessePromenade;
        _vitesseActuelleVerticale = _vitesseVerticale;
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

    void OnAccelere(InputValue etatBouton)
    {
        if (etatBouton.isPressed)
        {
            Debug.Log("presse");
            _vitesseActuellePromenade = _boostPromenade;
            _vitesseActuelleVerticale = _boostVerticale;
        }
        else
        {
            Debug.Log("lache");
            _vitesseActuellePromenade = _vitessePromenade;
            _vitesseActuelleVerticale = _vitesseVerticale;
        }
    }




    void Update()
    {
        Vector3 mouvement = new Vector3(0, directionInput.y * _vitesseActuelleVerticale, directionInput.z * _vitesseActuellePromenade) * Time.deltaTime;
        _rb.MovePosition(_rb.position + mouvement);
     
    }

}
