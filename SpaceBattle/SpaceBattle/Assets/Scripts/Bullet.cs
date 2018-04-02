using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour 
{
    public float speed;
    public float lifetime;
	void Update () 
    {
        Destroy(gameObject, lifetime);
        transform.Translate(-Vector3.forward * Time.deltaTime * speed);
	}
}
