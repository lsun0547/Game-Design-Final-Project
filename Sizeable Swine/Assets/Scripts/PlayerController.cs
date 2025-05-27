using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CharacterController))]

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;

    public float mouseSensitivity;

    public float upDownLimit;

    public float jumpSpeed;

    private float verticalVelocity;

    private float desiredUpDown;

    private float rotYaw;
    private float rotRoll;
    private Camera theCamera;

    private float forwardSpeed;
    private float strafeSpeed;
    private Vector3 speed;
    private CharacterController cc;
    private float oSpeed;
    private float sprintSpeed;
    public bool canMove;
    
    void Start()
    {
        cc = GetComponent<CharacterController>();
        theCamera = Camera.main;
        Cursor.lockState = CursorLockMode.Locked;

        oSpeed = moveSpeed;
        sprintSpeed = moveSpeed * 1.5f;
        canMove = true;
    }

    void Update()
    {
        if(canMove)
        {
            MoveAndRotate();
        }
    }

    void MoveAndRotate()
    {
        rotYaw = Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.Rotate(0f, rotYaw, 0f);
        rotRoll = Input.GetAxis("Mouse Y") * mouseSensitivity;
        desiredUpDown -= rotRoll;
        desiredUpDown = Mathf.Clamp(desiredUpDown, -upDownLimit, upDownLimit);
        theCamera.transform.localRotation = Quaternion.Euler(desiredUpDown, 0f, 0f);

        forwardSpeed = Input.GetAxis("Vertical") * moveSpeed;
        strafeSpeed = Input.GetAxis("Horizontal") * moveSpeed;
        verticalVelocity += Physics.gravity.y * Time.deltaTime;

        if(cc.isGrounded && Input.GetButtonDown("Jump"))
        {
            verticalVelocity = jumpSpeed;
        }

        speed = new Vector3(strafeSpeed, verticalVelocity, forwardSpeed);
        speed = transform.rotation * speed;
        cc.Move(speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {       
        if((other.gameObject.tag == "Pig" || other.gameObject.tag == "Ham") && other.isTrigger == false)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}