using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private GameObject playerObj = null;
    private GameObject playerCamera = null;
    // public Vector3 gravity;
    private float speed = 100.0f;
    // public float rotateSpeed = 10.0f;
    private Rigidbody rigidBody;
    private Vector3 destinationPosition;
    // Start is called before the first frame update
    void Start()
    {
        if (playerObj == null)
        {
            playerObj = GameObject.Find("Player");
            // Debug.Log("Player found!");
        }

        if(playerCamera == null)
        {
            playerCamera = GameObject.Find("Main Camera");
            // Debug.Log("Camera found!");
        }

        transform.position = new Vector3(0.0f, 1.75f, -5.0f);
        rigidBody = GetComponent<Rigidbody>();
        destinationPosition = transform.position;
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(0.0f, 0.0f, 0.0f);
        if(Input.GetKeyDown(KeyCode.W))
        {
            switch(CameraController.direction)
            {
                case CameraController.CameraDirection.FRONT:
                {
                    movement = new Vector3(0.0f, 0.0f, 1.0f);
                    destinationPosition += movement;
                }
                break;

                case CameraController.CameraDirection.RIGHT:
                {
                    movement = new Vector3(-1.0f, 0.0f, 0.0f);
                }
                break;

                case CameraController.CameraDirection.BACK:
                {
                    movement = new Vector3(0.0f, 0.0f, -1.0f);
                }
                break;

                case CameraController.CameraDirection.LEFT:
                break;

                case CameraController.CameraDirection.UP:
                break;

                case CameraController.CameraDirection.DOWN:
                break;
            }
        }
            rigidBody.AddForce(movement * speed);
        
        
        


    }

}
