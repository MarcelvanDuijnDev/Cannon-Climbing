using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour {
    float timer1 = 0.1f;
    void Update()
    {
        timer1 -= 1 * Time.deltaTime;
        if (timer1 <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
