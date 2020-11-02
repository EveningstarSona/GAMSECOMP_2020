using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movebot : MonoBehaviour {

    public GameObject targetpos;
<<<<<<< HEAD
    // Start is called before the first frame update
    void Start()
    {
=======

    void Start() {
>>>>>>> 1ee155a6284c10cfd7e63c250ba3dfd43c35bb2b
        targetpos.transform.SetParent(null);
    }

    void Update() {
        if(Vector3.Distance(transform.position, targetpos.transform.position) < 0.1f) {
            float newposx = Random.Range(-6.1f, 28.0f);
            float newposy = Random.Range(6.6f, 23.0f);
            targetpos.transform.position = new Vector3(newposx, newposy, 0);
        }
    }
}
