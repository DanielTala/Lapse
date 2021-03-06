﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class onsceneChange : MonoBehaviour
{
    public GameObject dialogueBox;
    public GameObject shopButton;
    public GameObject exitButton;
    public GameObject nextButton;
    public GameObject UI;
    public Movement mov;
    // Start is called before the first frame update
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Tilemap Tower(Stage)"|| scene.name == "Tilemap Tower(Ending)")
        {
            FindObjectOfType<Interaction>().dialogueBox = dialogueBox;
            FindObjectOfType<Interaction>().shopButton = shopButton;
            FindObjectOfType<Interaction>().exitButton = exitButton;
            FindObjectOfType<Interaction>().nextButton = nextButton;
            FindObjectOfType<Interaction>().UI = UI;
            FindObjectOfType<Interaction>().mov = mov;
            FindObjectOfType<DialogueBoxButtons>().mov = mov;
            FindObjectOfType<SecondDialogue>().mov = mov;
            FindObjectOfType<Movement>().prespawn = true;
        }
        if (scene.buildIndex ==5)
        {
            shopButton.SetActive(false);
        }
    }
}
