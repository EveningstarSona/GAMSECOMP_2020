using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {
    void Update() {
        Vector3 aux = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        aux.z = 0f;
        transform.up = aux;        
    }
}
