using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private ObjectButton[] _objectButtons;
    public CameraManager _cameraManager;
    
    public Animator notepadAnimator;

    private void Start()
    {
        foreach (var objectButton in _objectButtons)
        {
            objectButton.button.onClick.AddListener(() =>
            {
                DisableAllButtonsExceptThis(objectButton.button);
                objectButton.objectReference.SetActive(true);
                _cameraManager.isReadingAText = true;
            });
        }
    }

    public void DisableAllButtonsExceptThis(Button current)
    {
        foreach (var objectButton in _objectButtons)
        {
            objectButton.button.interactable = false;
        }
    }

    public void EnableAllButtons()
    {
        foreach (var objectButton in _objectButtons)
        {
            objectButton.button.interactable = true;
        }
    }
}
    