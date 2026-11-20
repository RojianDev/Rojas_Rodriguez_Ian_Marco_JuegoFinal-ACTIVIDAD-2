
using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class OguriController : MonoBehaviour
{
    [SerializeField] Transform cam;
    [SerializeField] Transform groundCheck;
    [SerializeField] float GroundDistance = 0.4f;
    [SerializeField] LayerMask groundMask;
    public HungerComponent hunger;
    
    [Header("Actions")]

    [SerializeField] InputActionReference move;
    [SerializeField] InputActionReference Sprint;
    [SerializeField] InputActionReference Interact;
    [SerializeField] InputActionReference Jump;

    [Header("Movement")]
    [SerializeField] float MoveSpeed = 7f;
    [SerializeField] float SprintSpeed = 10f;
    [SerializeField] float turnSmoothTime = 0.1f;

    [SerializeField] float jumpheight = 2f;
    [SerializeField] float gravity = -9.81f;

    [Header("Hunger")]
    [SerializeField] int normalReduction = 3;
    [SerializeField] int sprintReduction = 5;

    private CharacterController controller;
    private bool isGrounded;

    private Vector2 moveInput;
    private Vector3 currentMovement;

    private float Speed;
    Vector3 velocity;
    private float turnSmoothVelocity;

    private bool isSprinting;

    void Awake()
    {
        controller = GetComponent<CharacterController>();

        move.action.started += OnMove;
        move.action.performed += OnMove;
        move.action.canceled += OnMove;

        Interact.action.started += OnInteract;
        Jump.action.started += OnJump;

        Sprint.action.performed += OnSprint;
        Sprint.action.canceled += OnSprint;
    }

    void OnEnable()
    {
        move.action.Enable();
        Interact.action.Enable();
        Jump.action.Enable();
        Sprint.action.Enable();
    }

    void OnDisable()
    {
        move.action.Disable();
        Interact.action.Disable();
        Jump.action.Disable();
        Sprint.action.Disable();
    }

    void Update()
    {
        //handleGravity();
        isGrounded = Physics.CheckSphere(groundCheck.position, GroundDistance, groundMask);
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity* Time.deltaTime);

        Speed = isSprinting ? SprintSpeed: MoveSpeed;
        hunger.ReduceAmount = isSprinting ? sprintReduction : normalReduction;
        
        if(currentMovement.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(currentMovement.x, currentMovement.z) * Mathf.Rad2Deg + cam.eulerAngles.y;

            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y,targetAngle, ref turnSmoothVelocity, turnSmoothTime);

            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDirection = Quaternion.Euler(0f,targetAngle,0f) * Vector3.forward;

            controller.Move(moveDirection.normalized* Speed * Time.deltaTime);
        }


        
    }

    void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();

        currentMovement.x = moveInput.x;
        currentMovement.z = moveInput.y;
    }

    void OnSprint(InputAction.CallbackContext context)
    {
        isSprinting = context.ReadValueAsButton();
    }

    void OnJump(InputAction.CallbackContext context)
    {
        if (isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpheight*-2f*gravity);
        }
    }

    void OnInteract(InputAction.CallbackContext context)
    {
        
    }

   
}
