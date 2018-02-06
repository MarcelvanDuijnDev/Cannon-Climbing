using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Player : MonoBehaviour {

    JsonInfo saveScript = new JsonInfo();
    SaveScript saveScript2 = new SaveScript();
    ObjectPool_Script objectPoolScript;
    public GameObject shootEffect;

    private GameObject objectPool,shootPoint,rotationPoint,wheel;
    private bool isGrounded;
    private Rigidbody rb;
    [SerializeField]private float waterStrength;

    public float power;
    public Text powerText;

    void Start () 
    {
        objectPool = GameObject.Find("ObjectPool_Cannon");
        shootPoint = GameObject.Find("ShootPoint_Cannon");
        rotationPoint = GameObject.Find("Center_Cannon");
        wheel = GameObject.Find("Wheels_Cannon");
        rb = gameObject.GetComponent<Rigidbody>();
        objectPoolScript = (ObjectPool_Script)objectPool.GetComponent(typeof(ObjectPool_Script));
    }

	void Update () 
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 0;

        Vector3 objPos = Camera.main.WorldToScreenPoint(transform.position);
        mousePos.x = mousePos.x - objPos.x;
        mousePos.y = mousePos.y - objPos.y;

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        rotationPoint.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        if (Input.GetMouseButton(0) && power <= 100000)
        {
            power += 50000 * Time.deltaTime;
        }

        if (Input.GetMouseButtonUp(0))
        {
            KnockBack(power);
        }
	}
    void FixedUpdate()
    {
        SentToText();
    }

    void KnockBack(float power)
    {
        Vector2 mouse = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Ray ray;
        ray = Camera.main.ScreenPointToRay(mouse);
        Vector3 force = new Vector3(ray.origin.x, ray.origin.y, 0);
        rb.AddForce((shootPoint.transform.position - transform.position).normalized * -power * Time.smoothDeltaTime);
        Fire();
    }

    void Fire()
    {
        saveScript.totalCannonShots += 1;
        Instantiate(shootEffect, new Vector3(shootPoint.transform.position.x, shootPoint.transform.position.y, shootPoint.transform.position.z), Quaternion.identity);
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
        power = 0;
    }

    void SentToText()
    {
        float powerTextNew = power / 1000;
        powerText.text = "Power: " + powerTextNew.ToString("F0");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Teleporter")
        {
            if (SceneManager.GetActiveScene().buildIndex < SceneManager.sceneCountInBuildSettings - 1)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Water")
        {
            rb.AddForce(Vector3.up * waterStrength * Time.deltaTime);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Water")
        {
            rb.AddForce(Vector3.up * -waterStrength * 5 * Time.deltaTime);
        }
    }
}











/*
if (Input.GetKey(KeyCode.A))
{
    transform.Translate(-Vector3.right * 5 * Time.deltaTime);
    wheel.transform.Rotate(Vector3.forward * 200 * Time.deltaTime);
}
if (Input.GetKey(KeyCode.D))
{
    transform.Translate(Vector3.right * 5 * Time.deltaTime);
    wheel.transform.Rotate(-Vector3.forward * 200 * Time.deltaTime);
}
*/
