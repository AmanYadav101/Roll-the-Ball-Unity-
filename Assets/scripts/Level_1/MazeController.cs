using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MazeController : MonoBehaviour
{
    public float rotationSpeed = 5f;
    public float maxRotationAngle = 15f;
    private Rigidbody rb;

    private float rotationX = 0f;
    private float rotationY = 0f;
    private Quaternion initialRotation;

    Quaternion targetRotation;

    private void Start()
    {        /*Cursor.lockState = CursorLockMode.Locked;*/

        initialRotation = transform.localRotation;

        if (rb == null)
        {
            rb = GetComponent<Rigidbody>();
        }
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // Check if the mouse has moved
        
            rotationX -= mouseX * rotationSpeed;
            rotationY += mouseY * rotationSpeed;

            rotationX = Mathf.Clamp(rotationX, -maxRotationAngle, maxRotationAngle);
            rotationY = Mathf.Clamp(rotationY, -maxRotationAngle, maxRotationAngle);

            targetRotation = initialRotation * Quaternion.Euler(rotationY,0f , rotationX);

        

    }

    private void FixedUpdate()
    {
        rb.MoveRotation(Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed));
    }
}

/*    [SerializeField] private float moveSpeed = 7f;
*//*    
    [SerializeField] private float mouseSensitivity = 1.0f;
    private float mouseX;
    private float mouseY;
    private Quaternion currentRoation;
    Vector3 mousePoint;
    private Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>(); 
        currentRoation = Quaternion.Euler(0, 0f, 0);
        Cursor.lockState = CursorLockMode.Locked;
      *//*  
        currentRoation.x = -90.0f;
        currentRoation.z = 0;
        currentRoation.w = 1;
        currentRoation.y = 0;
        currentRoation = Quaternion.Euler(0, 0, 0);
        transform.rotation = currentRoation;
        Debug.Log(currentRoation);
*/
/*        currentRoation = transform.localRotation;
*//*

    }

    // Update is called once per frame
    private void Update()

    {

        mouseX += Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        mouseY += Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            currentRoation = Quaternion.Euler(mouseY, 0f, -mouseX);
        *//*transform.localRotation = currentRoation;*//*



        mouseX = Mathf.Clamp(mouseX, -15, 15);
        mouseY = Mathf.Clamp(mouseY, -15, 15);



        *//*Movement*/
/*
private void FixedUpdate()
{
rigidbody.rotation = currentRoation;
}

}*/