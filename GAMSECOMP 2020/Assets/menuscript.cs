using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class menuscript : MonoBehaviour
{
    public GameObject painel;
    //public GameObject texto;
    // Start is called before the first frame update
    void Start()
    {
        if(staticclass.getwol() == 1){
            painel.SetActive(true);
            GameObject.Find("Textao").GetComponent<TextMeshProUGUI>().text = "Perdeu. Tu é ruim hein?";
            staticclass.setwol(0);
        }
        if(staticclass.getwol() == 2){
            painel.SetActive(true);
            GameObject.Find("Textao").GetComponent<TextMeshProUGUI>().text = "Ganhou, aí sim";
            staticclass.setwol(0);
        }
        //texto = GameObject.Find("Textao");
        //GameObject.Find("Textao").gameObject.GetComponent<TextMeshProUGUI>().SetText("teste");
        //texto.GetComponent<TextMeshPro>().SetText("teste");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void play(){
        SceneManager.LoadScene(1);
    }

    public void quit(){
        Application.Quit();
    }
}
