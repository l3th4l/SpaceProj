using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour 
{
    [SerializeField]
    private float Activation_Radius;
    [SerializeField]
    private float Activation_Speed_perUnit;
    [SerializeField]
    private float MaxActivatonLevel;

    private float ActivationLevel;

	void Start () 
    {
        ActivationLevel = 0;
	}
	
	void Update ()
    {
        Collider[] inRad = Physics.OverlapSphere(transform.position, Activation_Radius);

        foreach (Collider entity in inRad)
            ActivationLevel += (entity.CompareTag("Attack") ? 1 : entity.CompareTag("Defend") ? -1 : 0) * Activation_Speed_perUnit * Time.deltaTime;

        print(ActivationLevel);
	}
}
