using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;

    public Text dialogueText;

    public GameObject shopButton;
    public GameObject exitButton;
    public GameObject nextButton;
    public bool timeAdd;
    public GameObject portal;
    public bool interacted;
    private int scene;
    private void Start()
    {
        interacted = false;
        sentences = new Queue<string>();
    }
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        interacted = false;

    }
    public void StartDialogue(Dialogue dialogue)
    {
        sentences.Clear();
        interacted = true;
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
    }

    public void EndDialogue()
    {
        scene = SceneManager.GetActiveScene().buildIndex;
        if (timeAdd == false && scene == 2)
        {
            Timer timer = FindObjectOfType<Timer>();
            timer.currentTime += 140;
            timeAdd = true;
        }
        shopButton.SetActive(true);
        nextButton.SetActive(false);
        exitButton.SetActive(true);
        portal.SetActive(true);
    }
}
