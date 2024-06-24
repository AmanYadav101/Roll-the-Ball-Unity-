using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] Transform destination;
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(destination.position,.4f);
        var direction = destination.TransformDirection(Vector3.forward);
        Gizmos.DrawRay(destination.position,direction);

    }
    private void OnTriggerEnter(Collider collider)
    {   
        Rigidbody rb = collider.GetComponent<Rigidbody>();
        var ballMovement = collider.GetComponent<BallMovement>();
        if(collider.CompareTag("Player")  )
        {
            audioManager.PlaySFX(audioManager.portal);
            ballMovement.Teleport(destination.position, destination.rotation); 
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;  
        }
    }
}
