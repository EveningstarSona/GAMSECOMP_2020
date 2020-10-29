using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movebot : MonoBehaviour
{
    public GameObject targetpos;
    // Start is called before the first frame update
    void Start()
    {
        targetpos.transform.SetParent(null);
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, targetpos.transform.position) < 0.1f){
            float newposx = Random.Range(-6.1f, 28.0f);
            float newposy = Random.Range(6.6f, 23.0f);
            targetpos.transform.position = new Vector3(newposx, newposy, 0);
        }
    }
}
