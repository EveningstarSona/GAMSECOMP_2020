using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour {
    
    public GameObject corpsePrefab;

    void Start(){
        GameObject roupas = spawnhumans();
        roupas.transform.SetParent(transform.GetChild(0).transform);
        roupas.transform.localPosition = Vector3.zero;
    }

    public void die() {
        GameObject corpse = Instantiate(corpsePrefab);
        corpse.transform.position = transform.position;
        transform.GetChild(0).gameObject.SetActive(true);
        transform.GetChild(0).SetParent(corpse.transform.GetChild(0));
        corpse.transform.right = corpse.transform.up;
        Destroy(gameObject);
    }

    public GameObject spawnhumans(){
        GameObject go = Resources.Load<GameObject>("GameObject");
        GameObject roupas = Instantiate(go);
        //Camiseta
        GameObject camiseta = Instantiate(go);
        camiseta.transform.SetParent(roupas.transform);
        camiseta.AddComponent<SpriteRenderer>();
        int camisetacor = Random.Range(1,14);
        camiseta.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("chars/camiseta/"+ camisetacor.ToString());
        //Cabelo
        GameObject cabelo = Instantiate(go);
        cabelo.transform.SetParent(roupas.transform);
        cabelo.AddComponent<SpriteRenderer>();
        int cabelocor = Random.Range(1,4);
        cabelo.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("chars/cabelo/"+ cabelocor.ToString());
        //Calca
        GameObject calca = Instantiate(go);
        calca.transform.SetParent(roupas.transform);
        calca.AddComponent<SpriteRenderer>();
        int calcacor = Random.Range(1,5);
        calca.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("chars/calca/"+ calcacor.ToString());
        //Acessorio
        GameObject acessorio = Instantiate(go);
        acessorio.transform.SetParent(roupas.transform);
        acessorio.AddComponent<SpriteRenderer>();
        int acessoriocor = Random.Range(1,5);
        acessorio.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("chars/acessorio/"+ acessoriocor.ToString());
        roupas.transform.localScale = new Vector3(2, 2, 0);
        return roupas;
    }
}
