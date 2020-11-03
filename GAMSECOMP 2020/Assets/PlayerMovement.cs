using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerMovement : MonoBehaviour {

    private float moveSpeed = 5f;
    private float angle;
    private float visionDistance = 15f;
    private int lado = 1;

    private GameObject places;
    public GameObject mira;
    public Rigidbody2D rb;

    Vector2 movement;

    void Start() {
        places = GameObject.Find("Places");
        places.SetActive(false);
    }

    void Update() {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if(GameObject.Find("PlacesText") != null){
            if(!GameObject.Find("Manager").GetComponent<manager>().onInterrogation){
                unpopup();
            }
        }
    }

    void FixedUpdate() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            float minDistance = 10000f, distance, nearest = 1;
            GameObject[] humans = GameObject.FindGameObjectsWithTag("human");
            for(int i = 0; i < humans.Length; i++) {
                distance = Vector3.Distance(humans[i].transform.position, transform.position);
                if(distance < minDistance) {
                    minDistance = distance;
                    nearest = i;
                }
            }
            float vampireDistance = Vector3.Distance(GameObject.FindGameObjectsWithTag("vampire")[0].transform.position, transform.position);
        
            if(vampireDistance < minDistance && vampireDistance < 5f)
                win();
            else if(minDistance < 5f)
                lose(); 
        }
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }    

    private void LateUpdate() {
        for(int i = 0; i < 360; i++){
            RaycastHit2D [] hit = Physics2D.RaycastAll(transform.position, mira.transform.position - transform.position, visionDistance);
            float auxdistancia = 100;
            for(int k = 0; k < 2; k++){
                for(int j=0; j < hit.Length; j++) {
                    if(hit[j].collider.gameObject.tag != "ignora"){
                        float distancia = Vector3.Distance(transform.position, hit[j].collider.transform.position);
                        if(distancia < auxdistancia) {
                            if(hit[j].collider.gameObject.tag == "parede"){
                                auxdistancia = distancia;
                            }else{
                                hit[j].collider.gameObject.transform.GetChild(0).gameObject.SetActive(true);
                            }
                            //if(hit[j].collider.gameObject.tag == "parede") auxdistancia = distancia;
                        }else{
                            //hit[j].collider.gameObject.transform.GetChild(0).gameObject.SetActive(false);
                        }
                    }
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

    private void win() {
        staticclass.setwol(2);
        SceneManager.LoadScene(0);
    }

    public void lose() {
        staticclass.setwol(1);
        SceneManager.LoadScene(0);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if((other.gameObject.tag == "human" || other.gameObject.tag == "vampire")&& GameObject.Find("Manager").GetComponent<manager>().onInterrogation) {
            popup(other.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if((other.gameObject.tag == "human" || other.gameObject.tag == "vampire") && GameObject.Find("Manager").GetComponent<manager>().onInterrogation) {
            unpopup();
        }
    }

    private void popup(GameObject other) {
        places.SetActive(true);
        GameObject.Find("PlacesText").GetComponent<TextMeshProUGUI>().text = other.GetComponent<movebot>().getPlaces();
    }

    private void unpopup() {
        places.SetActive(false);
        GameObject.Find("PlacesText").GetComponent<TextMeshProUGUI>().text = "";
    }
}