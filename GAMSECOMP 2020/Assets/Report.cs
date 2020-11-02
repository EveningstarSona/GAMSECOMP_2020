using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Report : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D other) {
        if(other.gameObject.tag == "Player")
            if (Input.GetKeyDown(KeyCode.Q))
                GameObject.Find("Manager").GetComponent<manager>().report();
    }
}
