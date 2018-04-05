using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour 
{
    [SerializeField]
    private float InitialHealth;

    [HideInInspector]
    public float ObjHealth;

	void Start () 
    {
        ObjHealth = InitialHealth;
	}
	
	void Update () 
    {
        if (ObjHealth <= 0)
            gameObject.SetActive(false);
        else
            gameObject.SetActive(true);
	}
}
