using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float Thrust = 1f;
    [SerializeField] float Rotate = 100f;
    [SerializeField] AudioClip ThrustSound;

    [SerializeField] ParticleSystem ThrustParticle;
    AudioSource As; 
    Rigidbody rb;

    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        As = GetComponent<AudioSource>();
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
            StartThrusting();
        }
        else
        {
            StopThrustAudio();
        }
    }
    void StopThrustAudio()
    {
        As.Stop();
        ThrustParticle.Stop();
    }
    void StartThrusting()
    {
        rb.AddRelativeForce(Vector3.up * Thrust * Time.deltaTime);
        if (!As.isPlaying)
        {
            As.PlayOneShot(ThrustSound);
        }
        if (!ThrustParticle.isPlaying)
        {
            ThrustParticle.Play();
        }
    }

    void ProcessRotation()
    {
        ProcessLeftRight();

    }

    void ProcessLeftRight()
    {
        //rotate
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(Rotate);
        }
        else if (Input.GetKey(KeyCode.D))
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
