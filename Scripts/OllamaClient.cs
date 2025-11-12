using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

[System.Serializable]
public class OllamaMessage
{
    public string role;
    public string content;
}

[System.Serializable]
public class OllamaChatRequest
{
    public string model;
    public OllamaMessage[] messages;
}

public class OllamaClient : MonoBehaviour
{
    private string apiUrl = "http://localhost:11434/api/chat";

    [TextArea(3, 10)]
    public string npcPersona = "You are Elina, a cheerful innkeeper in a medieval fantasy world. Speak warmly and kindly.";

    public IEnumerator SendRequest(string userInput, System.Action<string> callback)
    {
        var requestData = new OllamaChatRequest
        {
            model = "llama3",
            messages = new OllamaMessage[]
            {
                new OllamaMessage { role = "system", content = npcPersona },
                new OllamaMessage { role = "user", content = userInput }
            }
        };

        string json = JsonUtility.ToJson(requestData);
        using (UnityWebRequest www = new UnityWebRequest(apiUrl, "POST"))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
            www.uploadHandler = new UploadHandlerRaw(bodyRaw);
            www.downloadHandler = new DownloadHandlerBuffer();
            www.SetRequestHeader("Content-Type", "application/json");

            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                string response = www.downloadHandler.text;
                string clean = ExtractContent(response);
                callback?.Invoke(clean);
            }
            else
            {
                callback?.Invoke("Error: " + www.error);
            }
        }
    }

    private string ExtractContent(string response)
    {
        // Ollama는 여러 줄로 JSON을 반환함 → 모든 "content" 조각을 이어붙이기
        var lines = response.Split('\n');
        StringBuilder sb = new StringBuilder();

        foreach (var line in lines)
        {
            if (line.Contains("\"content\""))
            {
                int start = line.IndexOf("\"content\":\"") + 11;
                if (start < 11) continue;
                int end = line.IndexOf("\"", start);
                if (end == -1) end = line.Length - 1;

                string content = line.Substring(start, end - start);
                content = content.Replace("\\n", "\n").Replace("\\\"", "\"");
                sb.Append(content);
            }
        }

        string finalText = sb.ToString().Trim();
        return string.IsNullOrEmpty(finalText) ? "No response from model." : finalText;
    }

}
