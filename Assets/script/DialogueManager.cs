using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Animator animator;
    public Text nameText;
    public Text dialogueText;
    private Queue<string> sentences;
    public static DialogueManager instance;
    
        private void Awake()
        {
            if(instance != null)
            {
                Debug.LogWarning("Il y a plus d'une instance de DialogueManager dans la scene");
                return;
            }
            instance =this;

            sentences = new Queue<string>();
        }
    public void StartDialogue(Dialogue dialogue)
    {
        nameText.text =dialogue.name;
        animator.SetBool("IsOpen", true);
        sentences.Clear();
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }
   public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EnDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        
    }
    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }
    public void EnDialogue()
    {
      animator.SetBool("IsOpen",false);
    }
}
