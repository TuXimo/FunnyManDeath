using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private Button[] _buttons;
    public GameObject placeHolder;
    
    public void DisableAllButtonsExceptThis(Button current)
    {
        foreach (var button in _buttons)
        {
            button.interactable = false;
        }

        current.interactable = true;
    }

    public void EnableAllButtons()
    {
        foreach (var button in _buttons)
        {
            button.interactable = true;
        }
    }
}
    