using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class manager : MonoBehaviour
{
    public GameObject [] humans;
    public GameObject vampire;
    GameObject humanprefab;
    GameObject escmenu;
    int nhumans = 10;
    public bool onInterrogation = false;

    // Start is called before the first frame update
    void Start()
    {
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
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            escmenu.SetActive(true);
        }

    }

    public void backtomenu(){
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
        
    }

    private void teleportHumansBack() {
        
    }
}
