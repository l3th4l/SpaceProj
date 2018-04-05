using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour 
{
    // Crosshair
    [SerializeField]
    private GameObject CrosshairPrefab;
    [SerializeField]
    Canvas CanvasElement;

    private GameObject CrosshairObj;
    private RectTransform CrossTransform;

    void Start()
    {
        //Crosshair
        CrosshairObj = Instantiate(CrosshairPrefab,CanvasElement.transform);
        CrossTransform = CrosshairObj.GetComponent<RectTransform>();
    }

	void Update () 
    {
        //Crosshair
        CrosshairDisplay();
	}

    void CrosshairDisplay()
    {
        CrossTransform.position = Camera.main.WorldToScreenPoint(transform.forward * 100 + transform.position);

    }
}
