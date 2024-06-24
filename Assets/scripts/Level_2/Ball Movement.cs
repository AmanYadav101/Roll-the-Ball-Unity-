using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

public class BallMovement : MonoBehaviour
{
    [Header("-----------Normal Speed and Force----------")]

    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float torqueForce = 100f;

    [Header("---------RB---------")]
    public Rigidbody rb;
    public int numberofStars = 0;


    [Header("-----------Pad Elements----------")]
    public float newMoveSpeed = 200f;
    public float speedBoostDuration = 5f;
    public float jumpForce = 100f; 
    public Vector3 frc = new Vector3(100f, 100f, 0); 

    
    private float currentSpeed;
    private Vector2 inputVector = Vector2.zero;
    private IS_PlayerController playerController;//Unity Enhanced Player Controller
    private bool isOnGroundOrPlatform = false;
    AudioManager audioManager;

    void Start()
    {

        currentSpeed = moveSpeed;
        rb = GetComponent<Rigidbody>();
        rb.maxAngularVelocity = 100f; // Increase the max angular velocity
    }

    private void FixedUpdate()
    {
        //Checks if the ball is either on the ground or platform or not
        if (isOnGroundOrPlatform)
        {
            Vector3 dir = new Vector3(inputVector.y, 0f, -inputVector.x);
            ApplyMovement(dir);
        }
    }

    private void Awake()
    {
        //getting the isntance of the Player controller 
        playerController = new IS_PlayerController();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }



    private void OnEnable()
    {
        playerController.Enable();
        playerController.Sphere.Movement.performed += OnMovementPerformed;
        playerController.Sphere.Movement.canceled += OnMovementCancelled;
    }

    private void OnDisable()
    {
        playerController.Disable();
        playerController.Sphere.Movement.performed -= OnMovementPerformed;
        playerController.Sphere.Movement.canceled -= OnMovementCancelled;
    }


    //Updates the input vector based on the Action performed
    private void OnMovementPerformed(InputAction.CallbackContext value)
    {
        inputVector = value.ReadValue<Vector2>();

    }

    private void OnMovementCancelled(InputAction.CallbackContext value)
    {
        inputVector = Vector2.zero;
    }


    //Applies movement to the ball
    private void ApplyMovement(Vector3 direction)
    {

        rb.AddForce(direction * moveSpeed);
            Vector3 torque = new Vector3(direction.z, 0, -direction.x) * torqueForce;
            rb.AddTorque(torque);
        
    }


    //--------------------Teleport---------------------------
    public void Teleport(Vector3 position, Quaternion rotation)
    {

        transform.position = position;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        Physics.SyncTransforms();
        
    }



    //Makes the Ball Move only of the objects with the tag Ground or Platform
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Platform"))
        {
            isOnGroundOrPlatform = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Platform"))
        {
            isOnGroundOrPlatform = false;
        }
    }

    

    //Pads based on the tags given to the objects
    //Tag: "SpeedUP" - For speed Boost
    //Tag: "JumpPad" - For Making the ball jump
    private void OnTriggerEnter(Collider collider)
    {
        switch (collider.tag)
        {
            case "SpeedUP":
                audioManager.PlaySFX(audioManager.speedUP);
                StartCoroutine(SpeedBoost());
                break;
            case "JumpPad":
                audioManager.PlaySFX(audioManager.jump);
                Vector3 jumpDirection = new Vector3(0,1,0);
                rb.AddForce(jumpDirection * jumpForce, ForceMode.Impulse); //Applies force in the direction of jumpDirection with a force of jumpForce
                break;
        }
    }

    //Coroutine for SpeedUp pad so that ball gets the speed boost for a particular time
    private IEnumerator SpeedBoost()
    {
        moveSpeed = newMoveSpeed;
        yield return new WaitForSeconds(speedBoostDuration);
        moveSpeed = currentSpeed;
    }
}
