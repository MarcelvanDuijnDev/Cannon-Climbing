using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    [SerializeField]private float powerr;
    private float timer1;
    private Rigidbody rb;
    private GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void OnDisable()
    {
        timer1 = 5;
    }

    void Update()
    {
        if (timer1 == 5)
        {
            Player playerScript = player.gameObject.GetComponent<Player>();
            float force = playerScript.power;
            float newForce = force / 10000;
            //Debug.Log(newForce);
            //rb.AddForce(transform.forward * newForce * 5);
            rb.AddForce(transform.right * powerr);
        }
        timer1 -= 1 * Time.deltaTime;
        if (timer1 <= 0)
        {
            this.gameObject.SetActive(false);
            timer1 = 5;
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        this.gameObject.SetActive(false);
    }
}
