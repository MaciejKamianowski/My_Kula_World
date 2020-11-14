using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public enum CameraDirection {
        FRONT,
        RIGHT,
        BACK,
        LEFT,
        UP,
        DOWN
    }
    public static CameraDirection direction;
    private int temp = 0;
    private Quaternion rotating_quaternion = Quaternion.Euler(0,0,0);
    private Vector3 changePosition = new Vector3(0.0f, 0.0f, 0.0f);
    public GameObject player;
    public float rotateSpeed = 5.0f;
    private Vector3 offset;
    // Start is called before the first frame update
    Vector3 finalPositionCoordinates;
    void Start()
    {
        offset = new Vector3(0.0f, 1.0f, -3.0f);
        transform.position = player.transform.position + offset;
        transform.rotation = Quaternion.Euler(30.0f, 0.0f, 0.0f);
        direction = CameraDirection.FRONT;
        finalPositionCoordinates = player.transform.position + offset + changePosition;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            CameraRotateAnticlockwise();
        }
        if(Input.GetKeyDown(KeyCode.D))
        {
            CameraRotateClockwise();
        }
        // transform.rotation = rotating_quaternion;
        CameraRotateUpdate();
        // CameraPositionUpdate();
        //aktualizowanie pozycji kamery

        transform.position = player.transform.position + offset + changePosition;
    }

    private void CameraPositionUpdate()
    {
        // Nie działa poprawnie
        Vector3 currentPositionValues = player.transform.position;
        float [] positionUpdateValues = new float[3];
        positionUpdateValues[0] = currentPositionValues.x;
        positionUpdateValues[1] = currentPositionValues.y;
        positionUpdateValues[2] = currentPositionValues.z;

        // finalPositionCoordinates.x

        //aktualizowanie w osi X
        if(Mathf.Abs(finalPositionCoordinates.x - currentPositionValues.x) > 0.05)
        {
            //sprawdź czy obecna pozycja jest mniejsza niż wymagana
            if(currentPositionValues.x < finalPositionCoordinates.x)
            {
                positionUpdateValues[0] = positionUpdateValues[0] + 0.05f;
            }
            //sprawdź czy obecna pozycja jest większa niż wymagana
            if(currentPositionValues.x > finalPositionCoordinates.x)
            {
                positionUpdateValues[0] = positionUpdateValues[0] - 0.05f;
            }
        }
        //aktualizowanie w osi Y
        if(Mathf.Abs(finalPositionCoordinates.y - currentPositionValues.y) > 0.05)
        {
            //sprawdź czy obecna pozycja jest mniejsza niż wymagana
            if(currentPositionValues.y < finalPositionCoordinates.y)
            {
                positionUpdateValues[1] = positionUpdateValues[1] + 0.05f;
            }
            //sprawdź czy obecna pozycja jest większa niż wymagana
            if(currentPositionValues.y > finalPositionCoordinates.y)
            {
                positionUpdateValues[1] = positionUpdateValues[1] - 0.05f;
            }
        }
        //aktualizowanie w osi Z
        if(Mathf.Abs(finalPositionCoordinates.z - currentPositionValues.z) > 0.05)
        {
            //sprawdź czy obecna pozycja jest mniejsza niż wymagana
            if(currentPositionValues.z < finalPositionCoordinates.z)
            {
                positionUpdateValues[2] = positionUpdateValues[2] + 0.05f;
            }
            //sprawdź czy obecna pozycja jest większa niż wymagana
            if(currentPositionValues.z > finalPositionCoordinates.z)
            {
                positionUpdateValues[2] = positionUpdateValues[2] - 0.05f;
            }
        }

        transform.position = new Vector3(positionUpdateValues[0], positionUpdateValues[1], positionUpdateValues[2]);
    }

    private void CameraRotateUpdate()
    {
        Vector3 rotatingVector = rotating_quaternion.eulerAngles;
        float [] rotatingValues = new float[3];
        rotatingValues[0] = rotatingVector.x;
        rotatingValues[1] = rotatingVector.y;
        rotatingValues[2] = rotatingVector.z;

        Vector3 currentRotatingVector = transform.rotation.eulerAngles;
        float[] currentRotatingValues = new float[3];
        currentRotatingValues[0] = currentRotatingVector.x;
        currentRotatingValues[1] = currentRotatingVector.y;
        currentRotatingValues[2] = currentRotatingVector.z;
        //aktualizowanie w osi x
        //

        //aktualizowanie w osi y
        if(Mathf.Abs(rotatingValues[1] - currentRotatingValues[1]) > 0.005){
            //sprawdź czy kąt obecny jest mniejszy niż wymagany
            if(currentRotatingValues[1] < rotatingValues[1]){
                currentRotatingValues[1] = currentRotatingValues[1] + 1.0f;
            }
            //sprawdź czy kąt obecny jest większy niż wymagany
            //transform.rotation.y
            if(currentRotatingValues[1] > rotatingValues[1]){
                currentRotatingValues[1] = currentRotatingValues[1] - 1.0f;
            }
        }
        //aktualizowanie w osi z
        //
        transform.rotation = Quaternion.Euler(currentRotatingValues[0],
            currentRotatingValues[1],currentRotatingValues[2]);

    }

    private void CameraRotateAnticlockwise()
    {
            if(temp > 3)
            {
                temp = 0;
            }
            RotationChange();
            temp++;
    }

    private void CameraRotateClockwise()
    {
        if(temp < 0)
        {
            temp = 3;
        }
        RotationChange();
        temp--;
    }

    private void RotationChange()
    {
        int choice = temp % 4;
        // rotating_quaternion = Quaternion.Euler(0,0,0);
        // Quaternion target = Quaternion.Euler(30.0f, -90.0f, 0.0f);
        changePosition = new Vector3(0.0f, 0.0f, 0.0f);
        switch(choice)
        {
            case 0:
            {
                rotating_quaternion = Quaternion.Euler(30.0f, -90.0f, 0.0f);
                changePosition = new Vector3(3.0f, 0.0f, 3.0f);
                offset = new Vector3(0.0f, 1.0f, -3.0f);
                direction = CameraDirection.RIGHT;
            }   break;
            case 1:
            {   rotating_quaternion = Quaternion.Euler(30.0f, -180.0f, 0.0f);
                changePosition = new Vector3(-3.0f, 0.0f, 0.0f);
                offset = new Vector3(3.0f, 1.0f, 3.0f);
                direction = CameraDirection.BACK;
            }   break;
            case 2:
            {   rotating_quaternion = Quaternion.Euler(30.0f, -270.0f, 0.0f);
                changePosition = new Vector3(3.0f, 0.0f, 0.0f);
                offset = new Vector3(-6.0f, 1.0f, 0.0f);
                direction = CameraDirection.LEFT;
            }   break;
            case 3:
            {
                rotating_quaternion = Quaternion.Euler(30.0f, 0.0f, 0.0f);
                changePosition = new Vector3(0.0f, 0.0f, 0.0f);
                offset = new Vector3(0.0f, 1.0f, -3.0f);
                direction = CameraDirection.FRONT;
            }   break;
        }
        finalPositionCoordinates = player.transform.position + offset + changePosition;
    }
}
