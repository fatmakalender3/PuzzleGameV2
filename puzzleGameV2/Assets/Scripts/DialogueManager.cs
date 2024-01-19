using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;

    public Image characterIcon;
    public TextMeshProUGUI characterName;
    public TextMeshProUGUI dialogueArea;

    private Queue<DialogueLine> lines;

    public bool isDialogueActive = false;

    float typingSpeed = 0.05f;

    public Animator animator;



    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        lines = new Queue<DialogueLine>();
    }


    public void StartDialogue(Dialogue dialogue)
    {
        isDialogueActive = true;

        animator.Play("Entry");

        lines.Clear();

        foreach (DialogueLine dialogueLine in dialogue.dialogueLines)
        {
            lines.Enqueue(dialogueLine);
        }

        DisplayNextDialogueLine();
    }



    public void DisplayNextDialogueLine()
    {
        if (lines.Count == 0)
        {
            print("calisiyo mu");
            EndDialogue();
            return;
        }

        else 
        {
            DialogueLine currentLine = lines.Dequeue();

            characterIcon.sprite = currentLine.character.icon;
            characterName.text = currentLine.character.name;

            StopAllCoroutines();

            StartCoroutine(TypeSentence(currentLine));
            animator.Play("Idle");
        }

        
    }



    IEnumerator TypeSentence(DialogueLine dialogueLine)
    {
        dialogueArea.text = "";
        foreach (char letter in dialogueLine.line.ToCharArray())
        {
            dialogueArea.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }




    void EndDialogue()
    {
        GetComponent<Animator>().SetBool("EndDialogue", true);
        isDialogueActive = false;
        animator.Play("Exit");
    }
}
