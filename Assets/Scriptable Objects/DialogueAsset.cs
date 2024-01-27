using TMPro;
using UnityEngine;

namespace Scriptable_Objects
{
    [CreateAssetMenu]
    public class DialogueAsset : ScriptableObject
    {
        [SerializeField] TextMeshProUGUI dialogueText;
        [SerializeField] GameObject dialoguePanel;

        public void ShowDialogue(string dialogue)
        {
            dialogueText.text = dialogue;
            dialoguePanel.SetActive(true);
        }

        public void EndDialogue()
        {
            dialogueText.text = null;
            dialoguePanel.SetActive(false);
        }
    }
}