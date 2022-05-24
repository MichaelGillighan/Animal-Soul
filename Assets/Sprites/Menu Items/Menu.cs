using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    public GameObject inst;
    public GameObject loadS;
    public GameObject backgorund;
    public Animator loadSAnim;
    
    public AudioSource[] misSonidos;

	void Start () {
      
	}

	void Update () {
		
	}

    public void PlayBtn() {

        misSonidos[0].Play();
        loadS.SetActive(true);
        backgorund.SetActive(false);
        StartCoroutine(loadScreen("Animatico"));
    }

    public void ActivarInstruc()
    {
        inst.SetActive(true);

        misSonidos[1].Play();
    }

    public void DesactivarInstruct()
    {
        inst.SetActive(false);

        misSonidos[1].Play();
    }

    IEnumerator loadScreen(string level)
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(level, LoadSceneMode.Single);
    }

    public void ReTry()
    {
        loadS.SetActive(true);
        backgorund.SetActive(false);

        Scene scene = SceneManager.GetActiveScene();
        //Debug.Log("Name" + "" + scene.name);

        SceneManager.LoadScene(scene.name, LoadSceneMode.Single);

        //StartCoroutine(loadScreen("Level3"));
        //SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }

    public void Menum()
    {
        loadS.SetActive(true);
        backgorund.SetActive(false);
        //loadSAnim.SetBool("loadSAnim", true);
        StartCoroutine(loadScreen("Menu"));
       // SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }

}
