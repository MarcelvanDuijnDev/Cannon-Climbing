using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    ObjectPool_Script objectPoolScript;
    public GameObject objectPool;
    public GameObject shootPoint;

	void Start () 
    {
        objectPoolScript = (ObjectPool_Script)objectPool.GetComponent(typeof(ObjectPool_Script));
	}

    void Fire()
    {
        for (int i = 0; i < objectPoolScript.objects.Count; i++)
        {
            if (!objectPoolScript.objects[i].activeInHierarchy)
            {
                objectPoolScript.objects[i].transform.position = shootPoint.transform.position;
                objectPoolScript.objects[i].transform.rotation = shootPoint.transform.rotation;
                objectPoolScript.objects[i].SetActive(true);
                break;
            }
        }
    }
}
