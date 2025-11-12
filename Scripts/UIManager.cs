using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI npcNameText;
    public TextMeshProUGUI dialogueText;

    public void UpdateDialogue(string npcName, string text)
    {
        npcNameText.text = npcName;
        dialogueText.text = text;
    }
}
