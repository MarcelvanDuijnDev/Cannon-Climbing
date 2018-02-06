using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followMouse : MonoBehaviour {

	void Start () 
    {
		
	}
	

	void Update () 
    {
        Vector3 mousePosition;
        mousePosition=Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Debug.Log(mousePosition);

        transform.position = mousePosition;
	}
}
