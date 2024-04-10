using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    //public InputActions actions;

    public InputActionAsset actions;
    public float speed = 1f;
    private InputAction xAxis, jumpAction;

    void Awake()
    {
        xAxis = actions.FindActionMap("CubeActionsMap").FindAction("XAxis");
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
        float jump = jumpAction.ReadValue<float>();
        Debug.Log($"in the jump's data: {jump}");
    }

    void OnCollisionEnter(Collider other)
    {
        Debug.Log(other);
    }
    void OnTriggerEnter(Collider other) {}
}
