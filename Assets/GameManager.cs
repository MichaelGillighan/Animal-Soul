using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject[] pickUps;

    public GameObject[] efects;
    //public Animation animFx;

    public GameObject[] PickUps
    {
        get
        {
            return pickUps;
        }

        set
        {
            pickUps = value;
        }
    }

    public GameObject[] Efects
    {
        get
        {
            return efects;
        }

        set
        {
            efects = value;
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Instanciar(Transform trans)
    {
        Instantiate(pickUps[Random.Range(0, 4)], trans.position, trans.rotation);
    }
}
