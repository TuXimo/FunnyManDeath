using System.Collections;
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
        dialogueManager.placeHolder.gameObject.SetActive(true);
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
            gameObject.SetActive(false);
            dialogueManager._cameraManager.isReadingAText = false;
            dialogueManager.placeHolder.gameObject.SetActive(false);

            _textIndex = 0;
        }
    }

    private void SetText(int dialogueIndex)
    {
        if(dialogues.dialogue.Length != 0)
        {
            StartCoroutine(ShowTextCoroutine(dialogues.dialogue[dialogueIndex]));
        }
    }
    
    private readonly float timeForNextLetter = 0.05f;
    private IEnumerator ShowTextCoroutine(string fullText)
    {
        _nextButton.interactable = false;
        
        string currentText = " ";
        
        for (int i = 0; i < fullText.Length+1; i++)
        {
            currentText = fullText.Substring(0, i);
            _tmpText.text = currentText;
            yield return new WaitForSeconds(timeForNextLetter); 
        }

        _nextButton.interactable = true;
    }
}