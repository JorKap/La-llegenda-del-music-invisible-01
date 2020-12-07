using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;
    private Queue<Sprite> handIcons;
    public GameObject tancaTutorial;
   // public Text nameText;
    public Text dialogueText;
    public Image holdHandIcon;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        handIcons = new Queue<Sprite>();
        
    }

   public void StartDialogue(Dialogue dialogue)
    {
       // nameText.text = dialogue.name;
        sentences.Clear();
        handIcons.Clear();
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        foreach (Sprite handImage in dialogue.handImages)
        {
            handIcons.Enqueue(handImage);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
             EndDialogue();
            //dialogueText.text = "Això és tot";
            return;
        }

        string sentence = sentences.Dequeue();
        Sprite icon = handIcons.Dequeue();
        holdHandIcon.GetComponent<Image>().sprite = icon;
       dialogueText.text = sentence;
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (Char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    private void EndDialogue()
    {
        //Debug.Log("Això és tot");
        tancaTutorial.SetActive(false);

    }
}
