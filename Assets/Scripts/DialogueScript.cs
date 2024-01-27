using Scriptable_Objects;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueScript : MonoBehaviour
{
    [SerializeField] private DialogueAsset dialogues;
    [SerializeField] private DialogueManager dialogueManager;
    [SerializeField] private TMP_Text _tmpText;
    [SerializeField] private Button _nextButton;

    private int _textIndex;
    
    private void OnEnable()
    {
        SetText(0);
        dialogueManager.placeHolder.SetActive(true);
    }
    
    private void Start()
    {
        _nextButton.onClick.AddListener(NextText);
    }


    public void NextText()
    {
        _textIndex++;
           
        if (_textIndex < dialogues.dialogue.Length)
        {   
            SetText(_textIndex);
        }
        
        else
        {
            dialogueManager.EnableAllButtons();
            Destroy(gameObject);
            dialogueManager.placeHolder.SetActive(false);
        }
    }

    private void SetText(int dialogueIndex)
    {
        if(dialogues.dialogue.Length != 0)
        {
            _tmpText.text = dialogues.dialogue[dialogueIndex];
        }
    }
}