using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnhumans(){
        GameObject go = Resources.Load<GameObject>("GameObject");
        GameObject roupas = Instantiate(go);
        //Camiseta
        GameObject camiseta = Instantiate(go);
        camiseta.transform.SetParent(roupas.transform);
        camiseta.AddComponent<SpriteRenderer>();
        int camisetacor = Random.Range(1,6);
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
    }
}
