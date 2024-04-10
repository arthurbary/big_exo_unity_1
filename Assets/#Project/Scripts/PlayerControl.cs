using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    //public InputActions actions;

    [SerializeField] private float height;
    public InputActionAsset actions;
    public float speed = 1f;
    private InputAction xAxis, jumpAction;
    private bool onTheFloor;

    void Awake()
    {
        xAxis = actions.FindActionMap("CubeActionsMap").FindAction("XAxis");
        jumpAction = actions.FindActionMap("CubeActionsMap").FindAction("Jump");
        onTheFloor = false;
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
        MoveX();
        MoveForward();
        if(onTheFloor)
        {
            Jump();
        }
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
            transform.position += speed * Time.deltaTime * (jump * height) * transform.up;
            if (jump != 0) {
                Debug.Log(jump);
                onTheFloor = false;
            }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            onTheFloor = true;
            Debug.Log($"ON the floor {onTheFloor}"); 
        }
    }
}
