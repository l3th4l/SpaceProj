using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

[CreateAssetMenu(fileName = "New Fleet Properties",menuName = "Fleet Properties")]
public class FleetProperties : ScriptableObject
{
    public float FleetSpreadRadius;

    public float FleetAttackSpreadRadius;

    public float FleetDefendSpreadRadius;

    public float FleetRegroupSpreadRadius;

    public float FleetUnitDamage;

    public float FleetUnitHealth;

    public float FleetUnitSpeed;

    public float FleetUnitGap;

    public float FleetScoutDistance;
}
