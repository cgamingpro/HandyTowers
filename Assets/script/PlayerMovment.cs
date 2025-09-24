using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.Rendering;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    [Header("Movement Settings")]
    public float speed = 4f;
    [SerializeField] private float rotationSpeed = 500f;
    [Range(0f, 1f)][SerializeField] float moveSmooth = 0.15f;

    [Header("Gravity Settings")]
    public float gravity = -20f;           // gravity acceleration (negative)
    public float terminalVelocity = -50f;  // clamp downwards speed
    private float verticalVelocity = 0f;   // current vertical speed

    //[SerializeField] GameObject crossair;
    //[SerializeField] Vector3 crossAirOffser;

    private float inputX;
    private float inputY;
    Vector3 move;

    private Camera cam;
    private CharacterController characterController;

    private Vector3 inistaialPos;

    private void Awake()
    {
        inistaialPos = transform.position;
    }
    void Start()
    {
        cam = Camera.main;
        characterController = GetComponent<CharacterController>();

        // Defensive defaults for jams — adjust these in inspector if needed
        if (moveSmooth <= 0f) moveSmooth = 0.15f;
    }

    void Update()
    {
        HandleMovement();
        HandleRotation();
    }

    private void HandleMovement()
    {
        // read input
        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(inputX, 0f, inputY);
        if (moveDirection.magnitude > 1f) moveDirection.Normalize();

        // smooth horizontal movement
        move = Vector3.Lerp(move, moveDirection, Mathf.Clamp01(moveSmooth));

        // GRAVITY HANDLING
        if (characterController.isGrounded)
        {
            // small negative to keep us "stuck" to ground
            if (verticalVelocity < 0f) verticalVelocity = -2f;
        }
        else
        {
            // apply gravity while airborne
            verticalVelocity += gravity * Time.deltaTime;
            if (verticalVelocity < terminalVelocity) verticalVelocity = terminalVelocity;
        }

        // final movement vector: horizontal from input + vertical from gravity
        Vector3 finalMovement = move * speed;
        finalMovement.y = verticalVelocity;

        // ALWAYS call Move — even when idle — to let CharacterController resolve collisions properly
        characterController.Move(finalMovement * Time.deltaTime);
    }

    private void HandleRotation()
    {
        if (cam == null) return;

        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero); // Y = 0 plane
        float hitDist;

        if (groundPlane.Raycast(ray, out hitDist))
        {
            Vector3 targetPoint = ray.GetPoint(hitDist);
            //crossair.transform.position = targetPoint + crossAirOffser;
            Vector3 directionToMouse = (targetPoint - transform.position);
            directionToMouse.y = 0; // keep rotation flat on ground

            if (directionToMouse.sqrMagnitude > 0.001f) // avoid NaN rotations
            {
                Quaternion lookToward = Quaternion.LookRotation(directionToMouse, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(
                    transform.rotation,
                    lookToward,
                    Time.deltaTime * rotationSpeed
                );
            }
        }
    }
} 