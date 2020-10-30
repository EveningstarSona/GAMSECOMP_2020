using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour {
    
    public GameObject corpsePrefab;

    public void die() {
        GameObject corpse = Instantiate(corpsePrefab);
        corpse.transform.position = transform.position;
        transform.GetChild(0).gameObject.SetActive(true);
        transform.GetChild(0).SetParent(corpse.transform.GetChild(0));
        corpse.transform.right = corpse.transform.up;
        Destroy(gameObject);
    }
}
