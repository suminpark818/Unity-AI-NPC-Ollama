//using System.Collections; // ← 이 줄이 필수!
//using UnityEngine;
//using TMPro;
//using UnityEngine.UI;

//public class DialogueManager : MonoBehaviour
//{
//    [SerializeField] private TMP_InputField inputField;
//    [SerializeField] private TextMeshProUGUI outputText;
//    [SerializeField] private Button sendButton;
//    [SerializeField] private OpenAIClient openAIClient;

//    private void Start()
//    {
//        sendButton.onClick.AddListener(OnSendClicked);
//    }

//    private void OnSendClicked()
//    {
//        string userText = inputField.text.Trim();
//        if (string.IsNullOrEmpty(userText)) return;

//        inputField.text = "";
//        outputText.text = "Thinking...";
//        StartCoroutine(openAIClient.SendRequest(userText, OnResponse));
//        StartCoroutine(SendCooldown()); // 요청 쿨다운
//    }

//    private void OnResponse(string reply)
//    {
//        outputText.text = reply;
//    }

//    private IEnumerator SendCooldown()
//    {
//        sendButton.interactable = false;
//        yield return new WaitForSeconds(3f); // 3초 대기
//        sendButton.interactable = true;
//    }
//}

using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private TextMeshProUGUI outputText;
    [SerializeField] private Button sendButton;
    [SerializeField] private OllamaClient ollamaClient;

    private void Start()
    {
        sendButton.onClick.AddListener(OnSendClicked);
    }

    private void OnSendClicked()
    {
        string userText = inputField.text.Trim();
        if (string.IsNullOrEmpty(userText)) return;

        inputField.text = "";
        outputText.text = "Thinking...";
        StartCoroutine(ollamaClient.SendRequest(userText, OnResponse));
    }

    private void OnResponse(string reply)
    {
        outputText.text = reply;
    }
}
