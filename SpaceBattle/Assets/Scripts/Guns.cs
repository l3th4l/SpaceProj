using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guns : MonoBehaviour 
{
    public Transform[] Muzzles;

    [SerializeField]
    float FireRate;
    [SerializeField]
    float Damage;
    [SerializeField]
    float Range;
    [SerializeField]
    KeyCode FireKey;
    [SerializeField]
    GameObject TrailPrefab;

    private float NextFTime;

	void Start () 
    {
        NextFTime = 0;
	}
	
	void Update () 
    {
        if (Input.GetKey(FireKey) && Time.time >= NextFTime)
        {
            NextFTime = Time.time + 1/FireRate;
            foreach (Transform muzzle in Muzzles)
            {
                Shoot(Damage, muzzle, Range);
            }

        }
	}
    void Shoot(float DMG, Transform muzzleTransform, float range)
    {
        Instantiate(TrailPrefab, muzzleTransform.position,muzzleTransform.rotation);

        RaycastHit BulletHit;
        if(Physics.Raycast(muzzleTransform.position, -muzzleTransform.forward, out BulletHit,range))
        {
            print(BulletHit.transform.name);
            var hitHealth = BulletHit.transform.GetComponent<Health>();
            if (hitHealth != null)
                hitHealth.ObjHealth -= DMG;
        }
    }
}
