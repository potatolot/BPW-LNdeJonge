using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    private CharacterController playerController;
    [SerializeField]
    private AudioSource soundFile;
    [SerializeField]
    private Canvas BeginScreen;

    // Start is called before the first frame update
    void Start()
    {
        playerController.enabled = false;
        BeginScreen.gameObject.SetActive(true);
        soundFile.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(!soundFile.isPlaying)
        {
            playerController.enabled = true;
            BeginScreen.gameObject.SetActive(false);
        }
    }
}
