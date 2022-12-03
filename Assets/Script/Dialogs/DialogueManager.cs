using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI nameText;

    public Animator boxAnim;
    public Animator startAnim;
 
    private Queue<string> sentences;
    public int counter = 0;
    public int name_ind = 0;
    public string[] names;

    private void Start()
    {
        sentences = new Queue<string>();
    }
   
    public void StartDialogue(Dialogue dialogue)
    {
        boxAnim.SetBool("boxOpen", true);
        startAnim.SetBool("startOpen",false);

        names = dialogue.name;
        nameText.text = names[name_ind];
        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        } 
        DisplayNextSentence();
    }
    public void DisplayNextSentence()
    {
        
        nameText.text = names[name_ind];
        counter = sentences.Count;
        if(sentences.Count == 0) 
        {
            name_ind = 0;
            EndDialogue();
            return;
        }
        if (name_ind + 1 < names.Length)
        name_ind++;
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text +=letter;
            yield  return null;
        }
     }

     public void EndDialogue()
     {
 
         boxAnim.SetBool("boxOpen",false);
     }
}
