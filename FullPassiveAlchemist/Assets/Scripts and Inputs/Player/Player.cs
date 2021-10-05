using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour
{
    [SerializeField] InputActionReference Movement;
    [SerializeField] InputActionReference Jump;
    [SerializeField] float playerSpeed = 2.0f;
    [SerializeField] float jumpHeight = 1.0f;
    [SerializeField] float gravityValue = -9.81f;

   

    CharacterController controller;
    Vector3 playerVelocity;
    bool groundedPlayer;
    Transform camra;
    float rotSpeed = 4f;
    

    private void OnEnable()
    {
        Movement.action.Enable();
        Jump.action.Enable();
    }
    private void OnDisable()
    {
        Movement.action.Disable();
        Jump.action.Disable();
    }
    private void Awake()
    {
        
    }
    private void Start()
    {
        camra = Camera.main.transform;
        controller = gameObject.GetComponent<CharacterController>();
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector2 movement = Movement.action.ReadValue<Vector2>();
        Vector3 move = new Vector3(movement.x, 0, movement.y);
        move = camra.forward * move.z + camra.right * move.x;
        move.y = 0;
        controller.Move(move * Time.deltaTime * playerSpeed);
        
        // Changes the height position of the player..
        if (Jump.action.triggered && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        if(movement != Vector2.zero)
        {
            float target = Mathf.Atan2(movement.x, movement.y) * Mathf.Rad2Deg +camra.eulerAngles.y;
            Quaternion rot = Quaternion.Euler(0f, target, 0f);
            transform.rotation = Quaternion.Lerp(transform.rotation, rot, Time.deltaTime* rotSpeed);
        }
    }
   
}
