using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class SkipVideo : MonoBehaviour {

    private VideoPlayer myVp;

	// Use this for initialization
	void Start () {
        myVp = GetComponent<VideoPlayer>();
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(myVp.time);
        if (myVp.time > 16.50)
        {
            //myVp.enabled = false;
            //myVp.gameObject.SetActive(false);
            SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
        }
	}
}
