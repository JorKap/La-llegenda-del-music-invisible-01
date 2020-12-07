using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TextReaccio : Reaccio
{

    [TextArea(3, 10)]
    public string textReaccio;
    public Text dialogueText;
    public Color textColor;
    public CanvasGroup canvasGroup;
   // private Queue<string> sentences;
    private float fade = 0;

    protected override void ExecutaReaccio()
    {
        StartDialogue(textReaccio);
        
    }

    // Start is called before the first frame update
    void Start()
    {
        textColor.a = fade;
        dialogueText.color = textColor;
        canvasGroup.alpha = fade;
    }

    public void StartDialogue(string dialogue)
    {
        dialogueText.text = dialogue;
        StartCoroutine(FadeIn());
    }
    IEnumerator FadeIn()
    {
        while (fade < 1)
        {
            textColor.a = fade;
            dialogueText.color = textColor;
            canvasGroup.alpha = fade;
            fade += 0.1f;
            yield return null;
        }

        yield return new WaitForSeconds(3);

        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        while (fade > 0)
        {
            textColor.a = fade;
            dialogueText.color = textColor;
            canvasGroup.alpha = fade;
            fade -= 0.1f;
            yield return null;
        }

        
    }

    
}
