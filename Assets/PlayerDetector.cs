using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerDetector : MonoBehaviour
{
    private Zproject _defaultPlayerActions;
    public DialogueBox _dialogueBox;
    private bool _isDialogueOpen = false;
    private bool _isInTrigger;
    public bool IsPossessed = false;
    public bool QuestAccepted = false;
    private string pnjMessage;


    private void Awake()
    {
        _defaultPlayerActions = new Zproject();
    }
    private void OnEnable()
    {
        _defaultPlayerActions.Player.Action.Enable();
        _defaultPlayerActions.Player.Action.performed += OnPressActionButton;
    }
    private void OnTriggerEnter(Collider other)
    {
        //PNJ
        HandlePNJ001(other);
        HandlePNJ002(other);

        //Items
        HandleGlassBeer(other);
    }

    private void HandlePNJ001(Collider other)
    {
        if (other.CompareTag("PNJ-001"))
        {
            _isInTrigger = true;
            pnjMessage = "Bonjour, je ne t'ai jamais vue ici je suis Mr.Denmark, je ne trouve pas ma goubette enfin ma femme l'aurais tu vue ?";
        }
    }
    private void HandlePNJ002(Collider other)
    {
        if (other.CompareTag("PNJ-002"))
        {
            Debug.Log("tag = " + other.tag);

            if (!IsPossessed && !QuestAccepted)
            {
                _isInTrigger = true;
                pnjMessage = "Bonjour, Je crois que mon homme est faché car j'ai perdu son verre de mousse";
            }
            else if (IsPossessed && QuestAccepted)
            {
                _isInTrigger = true;
                pnjMessage = "Ooh Super tu as trouvé le verre de mousse, mon mari sera ravie :D.";
                IsPossessed = false;
            }
        }
    }
    private void HandleGlassBeer(Collider other)
    {
        if (other.CompareTag("GLASSBEER"))
        {
            IsPossessed = true;
            other.gameObject.SetActive(false);
        }
    }

    void OnPressActionButton(InputAction.CallbackContext context)
    {
        if (!_isInTrigger) return;

        if (!_isDialogueOpen)
        {
            _dialogueBox.gameObject.SetActive(true);
            _dialogueBox.TextComponent.text = pnjMessage;
            _dialogueBox.StartDialogue(_dialogueBox.TextComponent);
            _isDialogueOpen = true;
        }
        else
        {
            _dialogueBox.StopDialogue(_dialogueBox.TextComponent);
            _dialogueBox.gameObject.SetActive(false);
            _isDialogueOpen = false;
            if (pnjMessage.Contains("mon homme est faché"))
            {
                QuestAccepted = true;
                Debug.Log("Quête acceptée après dialogue !");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("PNJ-001") || other.CompareTag("PNJ-002"))
        {
            SetActiveWithMessage();
        }
    }

    private void SetActiveWithMessage()
    {
        _isInTrigger = false;

        if (_isDialogueOpen)
        {
            _dialogueBox.StopDialogue(_dialogueBox.TextComponent);
            _dialogueBox.gameObject.SetActive(false);
            _isDialogueOpen = false;
        }
    }

    private void OnDisable()
    {
        if (_defaultPlayerActions?.Player.Action != null)
            _defaultPlayerActions.Player.Action.performed -= OnPressActionButton;
    }
}

