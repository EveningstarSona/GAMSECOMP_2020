using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class room : MonoBehaviour {
    public string sala = "";

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "human" || other.gameObject.tag == "vampire") {
            other.gameObject.GetComponent<movebot>().setLugar(sala);
        }
    }
}
