using TMPro;
using UnityEngine;

namespace Scriptable_Objects
{
    [CreateAssetMenu]
    public class DialogueAsset : ScriptableObject
    {
        [TextArea]
        public string[] dialogue;
    }
}