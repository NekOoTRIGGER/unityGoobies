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
        TextComponent.enabled = true;
        TextComponent.text = "Qu�te Accept�e";
    }
    public void QuestFinish()
    {
        TextComponent.enabled = true;
        TextComponent.text = "Qu�te Termin�e";
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
