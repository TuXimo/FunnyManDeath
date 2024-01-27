using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private ObjectButton[] _objectButtons;
    public GameObject placeHolder;

    private void Start()
    {
        foreach (var objectButton in _objectButtons)
        {
            objectButton.button.onClick.AddListener(() =>
            {
                DisableAllButtonsExceptThis(objectButton.button);
                objectButton.objectReference.SetActive(true);
            });
        }
    }

    public void DisableAllButtonsExceptThis(Button current)
    {
        foreach (var objectButton in _objectButtons)
        {
            objectButton.button.interactable = false;
        }

        current.enabled = false;
    }

    public void EnableAllButtons()
    {
        foreach (var objectButton in _objectButtons)
        {
            objectButton.button.interactable = true;
        }
    }
}
    