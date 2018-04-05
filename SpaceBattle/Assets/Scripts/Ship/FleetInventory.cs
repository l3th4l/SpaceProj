using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleetInventory : MonoBehaviour
{
    [SerializeField]
    private KeyCode[] ActivationKeys;
    [SerializeField]
    private GameObject FleetControlPrefab;

    private List<FLCGroup> Groups;

    void Start()
    {
        Groups = new List<FLCGroup>();

        foreach (KeyCode Key in ActivationKeys)
        {
            Debug.Log("ins");

            GameObject tempCtrl = Instantiate(FleetControlPrefab, transform.parent);
            tempCtrl.GetComponent<FleetControl>().ParentShip = gameObject;

            var tempGroup = new FLCGroup(tempCtrl, Key, false);

            Groups.Add(tempGroup);
        }
    }

    void Update()
    {
        for (int i = 0; i < Groups.Count;i++)
        {
            if (Input.GetKeyDown(Groups[i].SelectionKey))
                Groups[i] = new FLCGroup(Groups[i].FLCPrefab, Groups[i].SelectionKey, !Groups[i].Selected);
            
            Groups[i].FLCPrefab.GetComponent<FleetControl>().Selected = Groups[i].Selected;
        }
    }
    public struct FLCGroup
    {
        public GameObject FLCPrefab;
        public KeyCode SelectionKey;
        public bool Selected;

        public FLCGroup(GameObject _FLCPrefab, KeyCode _SelectionKey, bool _Selected)
        {
            FLCPrefab = _FLCPrefab;
            SelectionKey = _SelectionKey;
            Selected = _Selected;
        }
    }
}
