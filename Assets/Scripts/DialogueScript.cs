using System;
using Scriptable_Objects;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueScript : MonoBehaviour
{
    [SerializeField] private DialogueAsset dialogues;
    [SerializeField] private TMP_Text _tmpText;
    [SerializeField] private Button _button;

    private int _textIndex = 0;
    
    private void OnEnable()
    {
        SetText(0);
    }

    private void Start()
    {
        _button.onClick.AddListener(NextText);
    }


    private void NextText()
    {
        _textIndex++;
           
        if (_textIndex < dialogues.dialogue.Length)
        {
            SetText(_textIndex);
        }
        
        else
        {
            gameObject.SetActive(false);
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