using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private GameObject cameraTarget;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float mouseSpeed;

    private CharacterController controller;
    private Animator animator;
    private Vector3 dirert;

    private float mouseX;
    private float mouseY;


    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        dirert = ((transform.forward * vertical) + (transform.right * horizontal)) * moveSpeed;
        if (controller.isGrounded == false)
        {
            dirert.y += -20f * Time.deltaTime;
        }

        controller.Move(dirert * Time.deltaTime);

        animator.SetFloat("speed", vertical);

        if (Input.GetMouseButton(1))
        {
            mouseX += Input.GetAxisRaw("Mouse X") * mouseSpeed;
            mouseY += Input.GetAxisRaw("Mouse Y") * mouseSpeed;
            mouseY = Mathf.Clamp(mouseY, -55f, 55f);

            transform.localEulerAngles = new Vector3(-mouseY, mouseX, 0);
            cameraTarget.transform.localEulerAngles = new Vector3(-mouseY, 0, 0);
        }
    }
    
}
