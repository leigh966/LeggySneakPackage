using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class SneakyPlayer : MonoBehaviour
{

    public float walkSpeed, crouchSpeed, walkingNoiseEmission, crouchingNoiseEmission, currentNoiseEmission;
    private bool crouched = false;
    CharacterController characterController;

    // Start is called before the first frame update
    void Start()
    {
        currentNoiseEmission = 0;
        characterController = GetComponent<CharacterController>();
    }

    void Move(Vector3 movementInput)
    {
        Vector3 worldMovement = transform.localToWorldMatrix.MultiplyVector(movementInput);
        // sneak
        if(crouched)
        {
            characterController.Move(worldMovement*crouchSpeed*Time.deltaTime);
            currentNoiseEmission = crouchingNoiseEmission;
            return;
        }
        // walk
        characterController.Move(worldMovement*walkSpeed*Time.deltaTime);
        currentNoiseEmission = walkingNoiseEmission;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movementInput = new Vector3(Input.GetAxis("Horizontal"),0f,Input.GetAxis("Vertical"));
        Move(movementInput);
        if(Input.GetKeyDown(KeyCode.LeftControl)) crouched = !crouched;
        transform.Rotate(new Vector3(0f, Input.GetAxis("Mouse X"), 0f));
    }
}
