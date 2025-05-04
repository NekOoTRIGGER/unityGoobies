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

    void OnPressActionButton(InputAction.CallbackContext context)
    {
        if (isDialogueOpen)
        {
            // Fermer le dialogue
            _dialogueBox.StopDialogue(_dialogueBox.TextComponent);  // Assure-toi que cette méthode existe
            _dialogueBox.gameObject.SetActive(false);
            isDialogueOpen = false;
        }
        else
        {
            // Ouvrir le dialogue
            _dialogueBox.gameObject.SetActive(true);
            _dialogueBox.StartDialogue(_dialogueBox.TextComponent);
            isDialogueOpen = true;
        }

    }
    private void OnDisable()
    {
        _defaultPlayerActions.Player.Action.performed -= OnPressActionButton;
    }
 
}
