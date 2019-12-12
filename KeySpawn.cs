using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeySpawn : MonoBehaviour
{

    public GameObject Key;
    public GameObject Vase_fractures;
    public GameObject Vase;

    // Start is called before the first frame update
    void Start()
    {
       Key.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (Vase_fractures.gameObject.activeInHierarchy)
        {
            Vector3 newPostion = new Vector3(Vase_fractures.transform.position.x, Vase_fractures.transform.position.y, Vase_fractures.transform.position.z);
            Instantiate(Key, newPostion, Quaternion.identity);
        }

       
        

    }
}
