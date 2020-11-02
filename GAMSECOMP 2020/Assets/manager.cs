using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manager : MonoBehaviour
{
    public GameObject [] humans;
    public GameObject vampire;
    GameObject humanprefab;
    int nhumans = 10;
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
