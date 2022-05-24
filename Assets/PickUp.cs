using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour {

    public int keyCount = 0;
    public int petCount = 0;

    //public GameObject sanduche;

    public int KeyCount
    {
        get
        {
            return keyCount;
        }

        set
        {
            keyCount = value;
        }
    }

    public int PetCount
    {
        get
        {
            return petCount;
        }

        set
        {
            petCount = value;
        }
    }
}
