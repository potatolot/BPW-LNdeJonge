using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTrigger : MonoBehaviour
{
    [SerializeField] private Animator animatedObject;

    [SerializeField] private GameObject cube;

    [SerializeField] private Material newMaterial;

    [SerializeField] private GameObject animatedText;
        

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            cube.GetComponent<Renderer>().material = newMaterial; 
            animatedObject.SetTrigger("CubeAnimationTrigger");

            animatedText.SetActive(true);
            animatedText.GetComponent<Animator>().SetTrigger("AnimateText");
        }

       
    }
}
