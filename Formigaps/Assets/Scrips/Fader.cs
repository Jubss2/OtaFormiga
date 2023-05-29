using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fader : MonoBehaviour
{
    // Start is called before the first frame update
    public Text historia;
    private float fadeTime;
    private bool fedingIn;

    void Start()
    {
        historia.CrossFadeAlpha(0, 0.0f, false);
        fadeTime = 0;
        fedingIn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(fedingIn)
        {
            FadeIn();
        }else if(historia.color.a !=0)
        {
            historia.CrossFadeAlpha(0,0.5f, false);
        }
    }

    void FadeIn()
    {
        historia.CrossFadeAlpha(1, 0.5f, false);
        fadeTime += Time.deltaTime;
        if(historia.color.a ==1 && fadeTime >1.5f)
        {
            fedingIn = false;
            fadeTime = 0;
        }
        
    }
    void OnTriggerEnter(Collider other) {
        if(other.tag == "origem")
        {
            fedingIn = true;
            historia.text = other.name;
        }
        
    }
}
