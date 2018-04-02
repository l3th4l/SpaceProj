using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleetUnit : MonoBehaviour 
{
    private Rigidbody RB;
    private FleetControl ParentFC;
    private Vector3 Target;
    private float SpreadRad;
    private float Speed;
    private float Damage;
    private float Health;
    private float Gap;


    void Start()
    {
        RB = GetComponent<Rigidbody>();
        ParentFC = GetComponentInParent<FleetControl>();//fleet control reference
        Damage = ParentFC.FlDamage;//damage given by the fleet unit
        Health = ParentFC.FlHealth;//health of fleet unit
    }

	void Update ()
    {
        Target = ParentFC.FleetTarget;//targeted position
        SpreadRad = ParentFC.FlSpreadRadius;//min stopping distance
        Speed = ParentFC.FlSpeed;//flight speed of fleet
        Gap = ParentFC.FlGap;//personal space

        Attack();
        Move(Target,SpreadRad,Speed*Time.deltaTime);//move to targeted position
        Spread(Gap);//spreads out the fleet units

	}

    void Attack()
    {
        
    }

    void Spread(float pSpace)
    {
        Vector3 dirCollector = Vector3.zero;

        Collider[] Objects = Physics.OverlapSphere(transform.position, pSpace);

        foreach(Collider Obj in Objects)//adds up -ve direction to all nearby objects
        {
            Transform ObjTrans = Obj.GetComponent<Transform>();
            dirCollector += transform.position - ObjTrans.position;
        }

        RB.velocity += dirCollector;//moves away from all nearby objects
    }

    void Move(Vector3 pos, float errorRadius, float uSpeed)
    {
        if (Vector3.SqrMagnitude(pos - transform.position) > errorRadius * errorRadius)
        {
            RB.velocity = (pos - transform.position).normalized * uSpeed;

            // Explict activation while moving and state isn't 4 
            if (ParentFC.FleetState != 4)
            {
                GetComponent<Collider>().enabled = true;
                GetComponent<MeshRenderer>().enabled = true;
            }
        }
        else
        {
            RB.velocity = Vector3.zero;

            loadFleet(ParentFC.FleetState);
        }
    }

    //loads/unloads fleet when within radius
    void loadFleet(int State)
    {
        if (State == 4)
        {
            GetComponent<Collider>().enabled = false;
            GetComponent<MeshRenderer>().enabled = false;
        }
        else
        {
            GetComponent<Collider>().enabled = true;
            GetComponent<MeshRenderer>().enabled = true;
        }
    }
}
