using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float Thrust = 1f;
    [SerializeField] float Rotate = 100f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        //thrust
        if(Input.GetKey(KeyCode.Space))
        {   
            rb.AddRelativeForce(Vector3.up * Thrust * Time.deltaTime);            
        }
    }
    
    void ProcessRotation()
    {   
        //rotate
        if(Input.GetKey(KeyCode.A))
        {
            ApplyRotation(Rotate);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-Rotate);
        }

    }

    void ApplyRotation(float RotationThisFrame)
    {   
        rb.freezeRotation = true; //freezing rotation so manually rotate
        transform.Rotate(Vector3.forward * RotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false;
    }
}
