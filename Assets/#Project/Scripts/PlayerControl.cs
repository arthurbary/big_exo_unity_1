using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlayerControl : MonoBehaviour
{

    //public InputActions actions;

    [SerializeField] private float height;
    public InputActionAsset actions;
    public float speed = 1f;
    private InputAction xAxis, jumpAction;
    private bool onTheFloor;
    private Rigidbody rb;
    private bool theEnd;

    void Awake()
    {
        xAxis = actions.FindActionMap("CubeActionsMap").FindAction("XAxis");
        jumpAction = actions.FindActionMap("CubeActionsMap").FindAction("Jump");
        rb = GetComponent<Rigidbody>();
        onTheFloor = false;
        theEnd = false;
    }

    void OnEnable()
    {
        actions.FindActionMap("CubeActionsMap").Enable();
    }

    void OnDisable()
    {
        actions.FindActionMap("CubeActionsMap").Disable();
    }

    void Update()
    {
        if(!theEnd)
        {
            MoveX();
            MoveForward();
        }
        Jump();


        FallFromFloor();
        if(transform.position.y > 2) Debug.Log(transform.position.y);
    }

    private void MoveX()
    {
        float xMove = xAxis.ReadValue<float>();

        transform.position += speed * Time.deltaTime * xMove * transform.right;

    }

    private void MoveForward()
    {
        transform.position += speed * Time.deltaTime * transform.forward;
    }
    private void Jump() 
    {
        //Debug.Log(onTheFloor);
            float jump = jumpAction.ReadValue<float>();
            if (jump != 0 && onTheFloor ) {
                //transform.position += speed * Time.deltaTime * (jump * height) * transform.up;
                onTheFloor = false;

                var jumpSpeed = Mathf.Sqrt(2 * height * Mathf.Abs(Physics.gravity.y));
                rb.velocity = new Vector3(rb.velocity.x, jumpSpeed, rb.velocity.z);
            }
            rb.constraints = RigidbodyConstraints.FreezeRotation;
    }

    void FallFromFloor()
    {
        if(transform.position.y < 0)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            onTheFloor = true;
        }
        if (other.gameObject.CompareTag("Finish"))
        {
            theEnd = true;
        }

    }
}
