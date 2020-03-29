using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTrigger : MonoBehaviour
{
    [SerializeField] private Animator animatedObject;

    [SerializeField] private AudioSource soundFile;

    // Update is called once per frame
    void Update()
    {
    }

    private void FadeOut()
    {
        animatedObject.Play("FadeOutTextAnimation");
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GetComponent<BoxCollider>().enabled = false;
            animatedObject.Play("FadeTextAnimation");
            soundFile.Play();

            float invokeTime = soundFile.clip.length;
            Invoke("FadeOut", invokeTime);
            
            

        }

       
    }
}
