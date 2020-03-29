using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutScene : MonoBehaviour
{
    [SerializeField]
    private GameObject characterObject;

    [SerializeField]
    private GameObject grandma;

    [SerializeField]
    private GameObject CutSceneCanvas;


    [SerializeField]
    private AudioClip audioClip0;

    [SerializeField]
    private AudioClip audioClip1;

    [SerializeField]
    private AudioClip audioClip2;

    [SerializeField]
    private AudioClip audioClip3;

    [SerializeField]
    private AudioClip audioClip4;

    [SerializeField]
    private AudioClip audioClip5;

    [SerializeField]
    private AudioClip audioClip6;

    [SerializeField]
    private AudioClip audioClip7;

    [SerializeField]
    private AudioClip audioClip8;

    public Vector3 playerPosition;

    public float characterSpeed = 2000f;

    private int currentSoundFile = 0;


    void Start()
    {
    }

    void Update()
    {

    }



    private void OnTriggerStay(Collider other)
    {
        characterObject.GetComponent<CharacterController>().enabled = false;
        MovePlayerToPosition();
        
       PlayCutScene();
        

    }


    private void MovePlayerToPosition()
    {
        Vector3.MoveTowards(characterObject.transform.position, transform.position, 1f);

        characterObject.transform.position += 0.1f * (transform.position - characterObject.transform.position);

        Debug.Log(characterObject.transform.position);

    }

    private void GrandmaStandup()
    {
        grandma.GetComponent<Animator>().Play("Armature|StandUp");


    }

    private void PlayCutScene()
    {
        //  ArrayList<SoundsResources.Load<>

        Debug.Log("thisistriggering");
        if (!CutSceneCanvas.GetComponentInChildren<AudioSource>().isPlaying) {
            switch (currentSoundFile)
            {
                case 0:
                    CutSceneCanvas.GetComponentInChildren<Text>().text = "test1";
                    CutSceneCanvas.GetComponentInChildren<AudioSource>().clip = audioClip0;
                    Invoke("GoToNextTrack", audioClip0.length);
                    break;
                case 1:
                    CutSceneCanvas.GetComponentInChildren<Text>().text = "test2";
                    CutSceneCanvas.GetComponentInChildren<AudioSource>().clip = audioClip1;
                    Invoke("GoToNextTrack", audioClip1.length);
                    break;
                case 2:
                    CutSceneCanvas.GetComponentInChildren<Text>().text = "";
                    CutSceneCanvas.GetComponentInChildren<AudioSource>().clip = audioClip2;
                    Invoke("GoToNextTrack", audioClip2.length);
                    break;
                case 3:
                    CutSceneCanvas.GetComponentInChildren<Text>().text = "";
                    CutSceneCanvas.GetComponentInChildren<AudioSource>().clip = audioClip3;
                    Invoke("GoToNextTrack", audioClip3.length);
                    break;
                case 4:
                    CutSceneCanvas.GetComponentInChildren<Text>().text = "";
                    CutSceneCanvas.GetComponentInChildren<AudioSource>().clip = audioClip4;
                    Invoke("GoToNextTrack", audioClip4.length);
                    break;
                case 5:
                    CutSceneCanvas.GetComponentInChildren<Text>().text = "";
                    CutSceneCanvas.GetComponentInChildren<AudioSource>().clip = audioClip5;
                    Invoke("GoToNextTrack", audioClip5.length);
                    break;
                case 6:
                    CutSceneCanvas.GetComponentInChildren<Text>().text = "";
                    CutSceneCanvas.GetComponentInChildren<AudioSource>().clip = audioClip6;
                    Invoke("GoToNextTrack", audioClip6.length);
                    break;
                case 7:
                    CutSceneCanvas.GetComponentInChildren<Text>().text = "";
                    CutSceneCanvas.GetComponentInChildren<AudioSource>().clip = audioClip7;
                    Invoke("GoToNextTrack", audioClip7.length);
                    break;
                case 8:
                    CutSceneCanvas.GetComponentInChildren<Text>().text = "";
                    CutSceneCanvas.GetComponentInChildren<AudioSource>().clip = audioClip8;
                    Invoke("GoToNextTrack", audioClip8.length);
                    break;


            }

            CutSceneCanvas.GetComponentInChildren<AudioSource>().Play();

        }
       

    }

    private void GoToNextTrack()
    {
        currentSoundFile++;
    }
}
