
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public bool IsInRange;

    private Text interactUI;

    private void Awake()
    {
          interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();
    }
    void Update()
    {
        if(IsInRange && Input.GetKeyDown(KeyCode.E))
        {
            TriggerDialogue();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            interactUI.enabled =true;
            IsInRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            IsInRange = false;
            interactUI.enabled =false;
            DialogueManager.instance.EnDialogue();
        }
    }
    void TriggerDialogue()
    {
        DialogueManager.instance.StartDialogue(dialogue);
    }
}
