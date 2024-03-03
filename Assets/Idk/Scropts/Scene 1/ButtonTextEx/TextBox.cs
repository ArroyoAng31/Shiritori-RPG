using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Manager of what to do with all the text

public class TextBox : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;

    private Queue<string> sentences;

    // Use this for initialization
    void Start()
    {
        sentences = new Queue<string>();
        
    }

    public void StartText(TextTest test)
    {
        nameText.text = test.name;
        sentences.Clear();

        foreach (string sentence in test.sentences)
        {
            sentences.Enqueue(sentence);
        }
           
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndText();
            return;
        }

        string sentence = sentences.Dequeue();
        //dialogueText.text = sentence; //makes the entire sentence show up

        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)//Makes the sentence show up char by char
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndText()
    {
        Debug.Log("No more Text");
    }
}
