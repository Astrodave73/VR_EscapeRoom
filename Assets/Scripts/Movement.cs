using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    Vector3 moveVector = Vector3.zero;
    CharacterController characterController;
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        moveVector.z = Input.GetAxis("Horizontal") * moveSpeed;
        moveVector.x = Input.GetAxis("Vertical") * moveSpeed;

        characterController.Move(moveVector * Time.deltaTime);
    }
}
