using System.Collections;
using TMPro;
using UnityEngine;

public class QuestStatus : MonoBehaviour
{
    public string questStatus;
    public TMP_Text TextComponent;

    void Start()
    {
        TextComponent.enabled = false;
    }

    public void QuestAccepted()
    {
        StopAllCoroutines(); // Optionnel : arr�ter les messages pr�c�dents
        StartCoroutine(DisplayMessage("Qu�te Accept�e"));
    }

    public void QuestFinish()
    {
        StopAllCoroutines(); // Optionnel
        StartCoroutine(DisplayMessage("Qu�te Termin�e"));
    }

    IEnumerator DisplayMessage(string message)
    {
        TextComponent.text = message;
        TextComponent.enabled = true;

        yield return new WaitForSeconds(3f); // attendre 3 secondes

        TextComponent.enabled = false;
    }
}
