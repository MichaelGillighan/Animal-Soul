using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AnimBtns : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    private Animator anim;

    //private AudioSource audio;

    
    void Start () {
        anim = GetComponent<Animator>();
        //audio = GetComponent<AudioSource>();
    }	
	
	void Update () {

	}

    public void OnPointerEnter(PointerEventData eventData)
    {
        anim.SetBool("Activate2",true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        anim.SetBool("Activate2", false);
    }
}
