using System.Collections;
using TMPro;
using UnityEngine;

public class DialogueBox : MonoBehaviour, IDialogueBox
{
    public TMP_Text TextComponent;
    public string[] Lines;
    public float TextSpeed = 0.2f;
    private int index;

    public DialogueBox(string[] lines)
    {
        this.Lines = lines;
    }
    public void StopDialogue(TMP_Text TextComponent)
    {
        TextComponent.enabled = false;
        TextComponent.text = string.Empty;
    }

    public void StartDialogue(TMP_Text TextComponent)
    {
        if (TextComponent != null)
        {
            TextComponent.enabled = true;
            index = 0;
            StartCoroutine(TypeLine(TextComponent));
        }
    }
    IEnumerator TypeLine(TMP_Text TextComponent)
    {
        foreach (var c in Lines[index].ToCharArray())
        {
            TextComponent.text += c;
            yield return new WaitForSeconds(TextSpeed);
        }
    }
}
