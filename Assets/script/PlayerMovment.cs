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
    [SerializeField] float moveSmooth;

    //[SerializeField] GameObject crossair;
    //[SerializeField] Vector3 crossAirOffser;

    private float inputX;
    private float inputY;
    Vector3 move;

    private Camera cam;
    private CharacterController characterController;

    void Start()
    {
        cam = Camera.main;
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        HandleMovement();
        HandleRotation();
    }

    private void HandleMovement()
    {
        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(inputX, 0, inputY);
        move = Vector3.Lerp(move,moveDirection,moveSmooth);
        if (moveDirection.magnitude > 0.1f) 
        {
            characterController.Move(move * Time.deltaTime * speed);
        }
    }

    private void HandleRotation()
    {
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
