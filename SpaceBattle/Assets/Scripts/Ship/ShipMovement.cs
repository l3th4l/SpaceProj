using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour 
{
    [SerializeField]
    private float MaxSpeed;

    [SerializeField]
    private float ForwardAcceleration;

    [SerializeField]
    private float SidewaysAcceleration;

    [SerializeField]
    private Transform CameraContainer;

    [SerializeField]
    private float LerpRate;

    [SerializeField]
    private float Friction;

    private Rigidbody RB;
    private Collider ShipCol;

	void Start () 
    {
        RB = GetComponent<Rigidbody>();
        ShipCol = GetComponent<Collider>();
	}
	
	void Update ()
    {
        Cursor.lockState = CursorLockMode.Locked;

        // Flight Movement
        Move(MaxSpeed,ForwardAcceleration,SidewaysAcceleration);

        //Turning
        Turn(CameraContainer,LerpRate);

        //Camera position update
        CameraContainer.position = transform.position;

        //Friction
        RB.AddForce(-RB.velocity * Friction, ForceMode.Acceleration);
	}

    void Move(float Max_Speed, float F_Acceleration, float S_Acceleration)
    {
        var z_mov = Input.GetAxis("Vertical")*F_Acceleration;
        var x_mov = Input.GetAxis("Horizontal") * S_Acceleration;

        RB.AddForce( transform.right*x_mov + transform.forward*z_mov, ForceMode.VelocityChange);
        RB.velocity = Vector3.ClampMagnitude(RB.velocity, Max_Speed);

        //tilt effect
        Transform MeshObj = transform.GetChild(0);
        MeshObj.eulerAngles = Vector3.Lerp(MeshObj.eulerAngles, new Vector3(MeshObj.eulerAngles.x, MeshObj.eulerAngles.y, -x_mov), SidewaysAcceleration);

    }
    void Turn(Transform CamTransform, float LRate)
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, CamTransform.rotation,LRate);
    }
}
