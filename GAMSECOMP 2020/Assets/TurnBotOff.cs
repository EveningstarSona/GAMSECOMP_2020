using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnBotOff : MonoBehaviour {
    void Update() {
        transform.GetChild(0).gameObject.SetActive(false);
    }
}
