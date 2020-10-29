using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private float moveSpeed = 5f;
    private float angle;
    private float visionDistance = 15f;
    private int lado = 1;

    public GameObject mira;
    public Rigidbody2D rb;

    Vector2 movement;

    void Update() {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate() {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void LateUpdate() {
        for(int i = 0; i < 360; i++){
            RaycastHit2D [] hit = Physics2D.RaycastAll(transform.position, mira.transform.position - transform.position, visionDistance);
            float auxdistancia = 100;
            for(int k = 0; k < 2; k++){
                for(int j=0; j < hit.Length; j++) {
                    float distancia = Vector3.Distance(transform.position, hit[j].collider.transform.position);
                    if(distancia < auxdistancia) {
                        hit[j].collider.gameObject.transform.GetChild(0).gameObject.SetActive(true);
                        if(hit[j].collider.gameObject.tag == "parede") auxdistancia = distancia;
                    }
                    //Debug.DrawLine(transform.position, hit[j].point, Color.red);
                }
            }
            mira.transform.Translate(new Vector3(0.06f*lado, 0, 0), Space.Self);
            if(mira.transform.localPosition.x > 5.5f) {
                lado = lado*-1;
                mira.transform.localPosition = new Vector3(5.5f, 13.5f, 0);
            }
            if(mira.transform.localPosition.x < -5.5f) {
                mira.transform.localPosition = new Vector3(-5.5f, 13.5f, 0);
                lado = lado*-1;
            }
        }
    }
}
