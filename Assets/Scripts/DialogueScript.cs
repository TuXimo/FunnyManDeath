using System;
using Scriptable_Objects;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class DialogueScript : MonoBehaviour
{
    [SerializeField] private DialogueAsset dialogues;
    [SerializeField] private TMP_Text _tmpText;
    [SerializeField] private Button _nextButton;

    private int _textIndex;
    
    private void OnEnable()
    {
        SetText(0);
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
            Destroy(gameObject);
        }
    }

    private void SetText(int dialogueIndex)
    {
        if(dialogues.dialogue != null)
        {
            _tmpText.text = dialogues.dialogue[dialogueIndex];
        }
    }
}