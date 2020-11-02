using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movebot : MonoBehaviour {

    public GameObject targetpos;
    float cd = 3f, cdtimer = 0;
    // Start is called before the first frame update
    void Start()
    {
        targetpos.transform.SetParent(null);
        cdtimer = cd;
    }

    void Update() {
        if(Vector3.Distance(transform.position, targetpos.transform.position) < 0.1f) {
            cdtimer += Time.deltaTime;
        }
        if(cdtimer >= cd){
            int newpos = Random.Range(0, 7);
            if(GameObject.Find("pos ("+ newpos + ")") != null)
            targetpos.transform.position = GameObject.Find("pos ("+ newpos + ")").transform.position;
            cdtimer = 0;
        }
    }
}
