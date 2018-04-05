using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleetControl : MonoBehaviour 
{
    public bool Selected = false;

    [SerializeField]
    private KeyCode AttackK;

    [SerializeField]
    private KeyCode DefendK;

    [SerializeField]
    private KeyCode ScoutK;

    [SerializeField]
    private KeyCode RegroupK;

    [SerializeField]
    private FleetProperties FleetProp;

    [HideInInspector]
    public GameObject ParentShip;
    [HideInInspector]
    public float FlSpreadRadius;
    [HideInInspector]
    public float FlDamage;
    [HideInInspector]
    public float FlHealth;
    [HideInInspector]
    public float FlSpeed;
    [HideInInspector]
    public float FlGap;
    [HideInInspector]
    public Vector3 FleetTarget;
    [HideInInspector]
    public int FleetState = 4;

    private Transform TargetObj;

    void Start()
    {
        TargetObj = ParentShip.transform;
    }
    void Update()
    {
        // Update Damage and health---
        FlDamage = FleetProp.FleetUnitDamage;
        FlHealth = FleetProp.FleetUnitHealth;
        FlSpeed = FleetProp.FleetUnitSpeed;
        FlGap = FleetProp.FleetUnitGap;
        //----------------------------

        if (Selected)
        {
            // assign states--------------
            //atack
            if (Input.GetKey(AttackK))
            {
                var tempTr = GetTarget();

                if (tempTr != null)
                    TargetObj = tempTr;

                FleetState = 1;
            }
            //defend
            if (Input.GetKey(DefendK))
            {
                var tempTr = GetTarget();

                if (tempTr != null)
                    TargetObj = tempTr;

                FleetState = 2;
            }
            //scout
            if (Input.GetKey(ScoutK))
            {
                TargetObj = ParentShip.transform;
                FleetState = 3;
            }
            //regroup
            if (Input.GetKey(RegroupK))
            {
                TargetObj = ParentShip.transform;
                FleetState = 4;
            }
            //---------------------------
        }

        // switch fleet state--------
        switch (FleetState)
        {
            //Attack
            case 1: 
                FleetTarget = TargetObj.position;
                FlSpreadRadius = FleetProp.FleetAttackSpreadRadius;
                break;

            //Defend
            case 2:
                FleetTarget = TargetObj.position;
                FlSpreadRadius = FleetProp.FleetDefendSpreadRadius;
                break;

            //Scout
            case 3:
                FleetTarget = ParentShip.transform.position + ParentShip.transform.forward * FleetProp.FleetScoutDistance;
                FlSpreadRadius = FleetProp.FleetSpreadRadius;
                break;

            //Regroup
            case 4:
                FleetTarget = ParentShip.transform.position;
                FlSpreadRadius = FleetProp.FleetRegroupSpreadRadius;
                break;
                
        }
        //---------------------------

        // Destroy fleet control if all units are dead
        if (transform.childCount == 0)
            Destroy(gameObject);
        //---------------------------
    }

    Transform GetTarget()
    {
        var Cam = Camera.main;

        RaycastHit CamHit;

        if (Physics.Raycast(Cam.transform.position, Cam.transform.forward, out CamHit))
            return CamHit.transform;
        
        return null;
    }
}
