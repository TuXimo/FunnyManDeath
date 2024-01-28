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
    
    private readonly float timeForNextLetter = 0.05f;
    private static readonly int SetUp = Animator.StringToHash("setUp");
    private static readonly int SetDown = Animator.StringToHash("setDown");
    
    private void OnEnable()
    {
        SetText(0);
        dialogueManager.notepadAnimator.SetTrigger(SetUp);
    }
    
    private void Start()
    {
        if (isKrusty)
        {
            krusties[0].SetActive(true); 
        }
        _nextButton.onClick.AddListener(NextText);
    }

    [Space(2)] [SerializeField]
    private GameObject closeUp;

    

    [Space(2)] 
    [SerializeField] private bool isKrusty;
    [SerializeField] private GameObject[] krusties;

    
    
    public void NextText()
    {
        _textIndex++;

        if (isKrusty)
        {
            if (krusties.Length > _textIndex)
            {
                krusties[_textIndex].SetActive(true);    
                krusties[_textIndex - 1].SetActive(false);   
            }
        }
        
        
        if (_textIndex < dialogues.dialogue.Length)
        {   
            SetText(_textIndex);
        }
        
        else
        {
            dialogueManager.EnableAllButtons();
            gameObject.SetActive(false);
            dialogueManager._cameraManager.isReadingAText = false;
            dialogueManager.notepadAnimator.SetTrigger(SetDown);
            _nextButton.gameObject.SetActive(false);
            _textIndex = 0;

            if (closeUp != null)
            {
                closeUp.SetActive(false);
            }
        }
    }

    private void SetText(int dialogueIndex)
    {
        if(dialogues.dialogue.Length != 0)
        {
            StartCoroutine(ShowTextCoroutine(dialogues.dialogue[dialogueIndex]));
        }
    }

    private IEnumerator ShowTextCoroutine(string fullText)
    {
        _tmpText.text = "";
        yield return new WaitForSeconds(0.8f);
        _nextButton.gameObject.SetActive(true);
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