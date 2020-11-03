using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Pathfinding;

public class manager : MonoBehaviour {
    public GameObject [] humans;
    public GameObject vampire;
    public Material litMaterial;
    public Material unlitMaterial;
    GameObject humanprefab;
    GameObject escmenu;
    int nhumans = 10;
    public bool onInterrogation = false;
    private int vampirePosition;
    GameObject audiomanager;

    // Start is called before the first frame update
    void Start() {
        humanprefab = Resources.Load<GameObject>("Human 2");
        humans = new GameObject[nhumans];
        for(int i = 0; i<nhumans; i++){
            humans[i] = Instantiate(humanprefab);
        }
        vampire = Instantiate(humanprefab);
        vampire.tag = "vampire";
        vampire.AddComponent<VampireKill>();
        escmenu = GameObject.Find("Escmenu");
        escmenu.SetActive(false);
        vampirePosition = Random.Range(0, nhumans + 1);
        audiomanager = GameObject.Find("AudioManager");
    }

    // Update is called once per frame
    void Update() {
        if(Input.GetKeyDown(KeyCode.Escape)){
            escmenu.SetActive(true);
        }
        if(Input.GetKeyDown(KeyCode.E) && onInterrogation) {
             onInterrogationEnd();
        }
        int humancont = 0;
        for(int i = 0; i< nhumans; i++){
            if(humans[i] != null){
                humancont++;
            }
        }
        if(humancont < 4){
            GameObject.Find("Player").GetComponent<PlayerMovement>().lose();
        }

    }

    public void backtomenu() {
        SceneManager.LoadScene(0);
    }

    public void report() {
        GameObject[] corpses = GameObject.FindGameObjectsWithTag("corpse");
        for(int i = 0; i < corpses.Length; i++) {
            Destroy(corpses[i]);
        }
        teleportHumansToSideRoom();
        onInterrogation = true;
    }

    public void onInterrogationEnd() {
        teleportHumansBack();
        onInterrogation = false;
    }

    private void teleportHumansToSideRoom() {
        GameObject.Find("Player").transform.position = GameObject.Find("ponto (0)").transform.position;
        for(int i = 0; i < humans.Length; i++) {
            if(i == vampirePosition) {
                vampire.transform.position = GameObject.Find("ponto (" + i + ")").transform.position;
                vampire.GetComponent<IAstarAI>().canMove = false;
                vampire.GetComponent<TurnBotOff>().visible = true;
                vampire.GetComponent<VampireKill>().canKill = true;
                vampire.transform.GetChild(0).GetComponent<SpriteRenderer>().material = litMaterial;
                vampire.transform.GetChild(0).gameObject.SetActive(true);
                if (humans[i] != null) {
                    humans[i].transform.position = GameObject.Find("ponto (" + humans.Length + ")").transform.position;
                    humans[i].GetComponent<IAstarAI>().canMove = false;
                    humans[i].GetComponent<TurnBotOff>().visible = true;
                    humans[i].transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().material = litMaterial;
                    humans[i].transform.GetChild(0).gameObject.SetActive(true);
                }
            } else if(humans[i] != null) {
                humans[i].transform.position = GameObject.Find("ponto (" + i + ")").transform.position;
                humans[i].GetComponent<IAstarAI>().canMove = false;
                humans[i].GetComponent<TurnBotOff>().visible = true;
                humans[i].transform.GetChild(0).GetComponent<SpriteRenderer>().material = litMaterial;
                humans[i].transform.GetChild(0).gameObject.SetActive(true);
            }
        }
    }

    private void teleportHumansBack() {
        GameObject.Find("Player").transform.position = new Vector3(2, 2, 0);
        for(int i = 0; i < humans.Length; i++)
            if(humans[i] != null) {
                humans[i].transform.position = new Vector3(2, 2, 0);
                humans[i].GetComponent<IAstarAI>().canMove = true;
                humans[i].GetComponent<TurnBotOff>().visible = false;
                humans[i].transform.GetChild(0).GetComponent<SpriteRenderer>().material = unlitMaterial;
            }
        vampire.transform.position = new Vector3(2, 2, 0);
        vampire.GetComponent<IAstarAI>().canMove = true;
        vampire.GetComponent<TurnBotOff>().visible = false;
        vampire.transform.GetChild(0).GetComponent<SpriteRenderer>().material = unlitMaterial;
        vampire.GetComponent<VampireKill>().resetCooldown();
        for(int i = 0; i< nhumans; i++){
            if(humans[i] != null){
                humans[i].GetComponent<movebot>().resetlista();
            }
        }
        vampire.GetComponent<movebot>().resetlista();
    }

    public void morreualguem(){
        //audiomanager.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("morreu");
        audiomanager.GetComponent<AudioSource>().PlayOneShot(Resources.Load<AudioClip>("morreu"), 1.0F);
    }

    public void mute(){
        GameObject.Find("Main Camera").GetComponent<AudioSource>().mute = !GameObject.Find("Main Camera").GetComponent<AudioSource>().mute;
    }
}
