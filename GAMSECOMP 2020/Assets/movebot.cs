using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class movebot : MonoBehaviour {

    public GameObject targetpos;
    float cd = 3f, cdtimer = 0;
    GameObject escmenu;
    public string [] lugares;
    int arraypos = 0, maxlugares = 5;
    //Vector3 posicao;
    // Start is called before the first frame update
    void Start()
    {
        targetpos.transform.SetParent(null);
        cdtimer = cd;
        lugares = new string[maxlugares];
    }


    void Update() {
        if(Vector3.Distance(transform.position, targetpos.transform.position) < 0.1f) {
            cdtimer += Time.deltaTime;
        }
        if(cdtimer >= cd){
            int newpos = Random.Range(0, 49);
            if(GameObject.Find("pos ("+ newpos + ")") != null)
            targetpos.transform.position = GameObject.Find("pos ("+ newpos + ")").transform.position;
            cdtimer = 0;
        }
        //GetComponent<IAstarAI>().canMove = false;
    }

    public void setLugar(string n){
        if(arraypos == maxlugares){
            for(int i = 0; i< maxlugares - 1; i++){
                lugares[i] = lugares[i+1];
            }
            arraypos = maxlugares - 1;
        }
        if(arraypos > 0){
            if(lugares[arraypos-1] != n && lugares[arraypos] != n){
                lugares[arraypos] = n;
                arraypos++;
            }
        }
        else{
            lugares[arraypos] = n;
            arraypos++;
        }
    }

    public string getPlaces() {
        string aux, arrow = " -> ";
        if(lugares[maxlugares - 1] == lugares[maxlugares - 2]) {
            aux = lugares[maxlugares - 4] + arrow + lugares[maxlugares - 3] + arrow + lugares[maxlugares - 2];
        } else {
            aux = lugares[maxlugares - 3] + arrow + lugares[maxlugares - 2] + arrow + lugares[maxlugares - 1];
        }
        return aux;
    }
}
