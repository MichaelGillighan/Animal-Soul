using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingGif : MonoBehaviour {

    public Sprite[] mySprites;
    private Image myImages;
    public float timerAnim = 1f;
    public int timerAnim2 = 1;

    IEnumerator MuevaGif()
    {
        for (int j = 0; j < 3; j++)
        {
            for (int i = 0; i < mySprites.Length; i++)
            {
                myImages.sprite = mySprites[i];
                yield return new WaitForSeconds(timerAnim2);
            }
        }
        

        //for (int i = 0; i < mySprites.Length; i++)
        //{
        //    
        //    

        //}
        //int i = 0;
        //while (i < mySprites.Length)
        //{
        //    myImages.sprite = mySprites[i];
        //    yield return new WaitForSeconds(timerAnim);
        //    i++;
        //}

        //yield return new WaitForSeconds(timerAnim);
    }

     

	// Use this for initialization
	void Start () {
        myImages = GetComponent<Image>();
        StartCoroutine(MuevaGif());

        //int i = 0;
        //while (i < mySprites.Length)
        //{
        //    StartCoroutine(MuevaGif());
        //    i++;
        //}
	}
	
	// Update is called once per frame
	void Update () {
        //MuevaGif();
        


    }
}
