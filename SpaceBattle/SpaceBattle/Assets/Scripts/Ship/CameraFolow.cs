using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFolow : MonoBehaviour 
{
    [SerializeField]
    private float TurnVelocity;

    [SerializeField]
    private float verticalAngleLimit;

	void Update () 
    {
        Turn(TurnVelocity);
	}
    void Turn(float TSpeed)
    {
        var vertTorque = Input.GetAxis("Mouse Y") * TSpeed;
        var horizTorque = Input.GetAxis("Mouse X") * TSpeed;

        var TempEulerAngle = transform.localEulerAngles;

        TempEulerAngle.z = 0.0f;

        TempEulerAngle += new Vector3(-vertTorque, horizTorque, 0.0f);

        transform.localEulerAngles = TempEulerAngle;
    }
}
