using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimerScript : MonoBehaviour {


    public Text contador;
    public Text fin;
    public float tiempo = 200f;
    public GameObject gameOverS;


    void Start () {
        contador.text = " " + Mathf.Round(tiempo);
        fin.enabled = false;
	}
	

	void Update () {
        //contador.text = " " + tiempo.ToString("f");
        contador.text = "" + Mathf.Round(tiempo);
        tiempo -= Time.deltaTime; 

        if (tiempo <= 0) {
            contador.text = "00.00";
            fin.enabled = true;
            StartCoroutine(GameOverScreen());
        }
	}
    IEnumerator GameOverScreen()
    {
        yield return new WaitForSeconds(3);
        gameOverS.SetActive(true);
    }
}
