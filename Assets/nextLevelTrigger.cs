using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextLevelTrigger : MonoBehaviour {

    private GameObject pick;
    public GameObject loadS;

    // Use this for initialization
    void Start () {

        pick = GameObject.FindGameObjectWithTag("CountManager");

	}
	
	// Update is called once per frame
	void Update () {

        //Debug.Log(pick.name);
        //Debug.Log(SceneManager.GetActiveScene().name);

	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" || other.tag == "Player2")
        {
            Debug.Log("if 1");

            if (pick.GetComponent<PickUp>().PetCount == 12)
            {
                Debug.Log("if 2");

                Scene scene = SceneManager.GetActiveScene();

                Debug.Log(scene.name);

                if (scene.name == "Level 1")
                {
                    Debug.Log("if 3");

                    loadS.SetActive(true);
                    StartCoroutine(loadScreen("Level2"));
                    //SceneManager.LoadScene("level2", LoadSceneMode.Single);

                }
                if (scene.name == "Level2")
                {
                    loadS.SetActive(true);
                    StartCoroutine(loadScreen("Level3"));
                    //SceneManager.LoadScene("level3", LoadSceneMode.Single);

                }
            }
        }
    }
    
    IEnumerator loadScreen(string level)
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(level, LoadSceneMode.Single);
    }

}
