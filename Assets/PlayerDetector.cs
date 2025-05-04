using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerDetector : MonoBehaviour
{
    private Zproject _defaultPlayerActions;
    public DialogueBox _dialogueBox;
    public TextMeshProUGUI textMeshProUGUI = new();
    private bool isDialogueOpen = false;
    private bool isInTrigger;

    private void Awake()
    {
        _defaultPlayerActions = new Zproject();
        _dialogueBox.TextComponent = textMeshProUGUI;
    }
    private void OnEnable()
    {
        _defaultPlayerActions.Player.Action.Enable();
        _defaultPlayerActions.Player.Action.performed += OnPressActionButton;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PNJ-001"))
        {
            isInTrigger = true;
        }
    }
    void OnPressActionButton(InputAction.CallbackContext context)
    {
        if (!isInTrigger) return; // Ne rien faire si le joueur n’est pas dans le trigger

        if (isDialogueOpen)
        {
            _dialogueBox.StopDialogue(_dialogueBox.TextComponent);
            _dialogueBox.gameObject.SetActive(false);
            isDialogueOpen = false;
        }
        else
        {
            _dialogueBox.gameObject.SetActive(true);
            _dialogueBox.StartDialogue(_dialogueBox.TextComponent);
            isDialogueOpen = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("PNJ-001"))
        {
            isInTrigger = false;

            // Optionnel : fermer le dialogue si tu quittes la zone
            if (isDialogueOpen)
            {
                _dialogueBox.StopDialogue(_dialogueBox.TextComponent);
                _dialogueBox.gameObject.SetActive(false);
                isDialogueOpen = false;
            }
        }
    }
    private void OnDisable()
    {
        _defaultPlayerActions.Player.Action.performed -= OnPressActionButton;
    }

}
