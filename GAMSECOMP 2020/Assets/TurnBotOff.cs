using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnBotOff : MonoBehaviour {

    public bool visible = false;

    void Update() {
        if(!visible)
            transform.GetChild(0).gameObject.SetActive(false);
    }
}
