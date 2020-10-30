using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VampireKill : MonoBehaviour {

    private float watchRadius = 15f;
    public float cooldown = 20f;
    private float baseCooldown = 10f;
    private float killDistance = 5f;

    private GameObject[] humans;

    public GameObject player;

    void Start() {
        humans = GameObject.FindGameObjectsWithTag("human");
        player = GameObject.Find("Player");
    }

    void Update() {
        if(cooldown == 0f && Vector3.Distance(player.transform.position, transform.position) > watchRadius ) {
            Kill();
        }
        cooldown = Mathf.Max(0f, cooldown - 1f * Time.deltaTime);
    }

    private void Kill() {
        foreach(GameObject human in humans) {
            if(human != null){
                if (Vector3.Distance(human.transform.position, transform.position) <= killDistance) {
                    human.GetComponent<Human>().die();
                    humans = GameObject.FindGameObjectsWithTag("human");
                    cooldown = baseCooldown;
                    break;
                }
            }
        }
    }
}
