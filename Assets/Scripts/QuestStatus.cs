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
        TextComponent.text = "Quête Acceptée";
    }
    public void QuestFinish()
    {
        TextComponent.enabled = true;
        TextComponent.text = "Quête Terminée";
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
