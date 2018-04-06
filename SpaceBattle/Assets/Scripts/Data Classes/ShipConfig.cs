using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ShipConfig
{
    public string ShipName;
    public WeaponConfig[] ShipWeapons;
    public int ShipSelectedWeaponIndex;
}
