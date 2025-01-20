using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class HttpClient : MonoBehaviour
{
    public static HttpClient Instance { get; private set; } // Singleton instance
    private readonly string url = "https://hacknroll-backend.onrender.com/play/";  // FastAPI backend endpoint

    public TMP_Text OutputText;
    public GameObject loadingResult;
    public GameObject passResult;
    public GameObject failResult;

    void Awake()
    {
        // Singleton pattern implementation
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persist across scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Get(string user, string scenario, string personality, string rizz)
    {
        string jsonData = "{\n";
        jsonData += "  \"username\": \"" + user + "\",\n";
        jsonData += "  \"personality\": \"" + personality + "\",\n";
        jsonData += "  \"scenario\": \"" + scenario + "\",\n";
        jsonData += "  \"action\": \"" + rizz.Trim() + "\"\n"; // Trim out empty space
        jsonData += "}";

        StartCoroutine(SendPostRequest(jsonData));
        Debug.Log("Player Input Data Sent!");

        OutputText.text = "AI is judging your skibidi ohio sigma aura, you gyatt to be a gigachad and mew while waiting...";
        loadingResult.SetActive(true);
        passResult.SetActive(false);
        failResult.SetActive(false);

        // string jsonData = $@"
        // {{
        //     ""username"": ""{username}"",
        //     ""personality"": ""{(Personality.Instance != null ? Personality.Instance.get() : "default")}"",
        //     ""scenario"": ""{(Scenario.Instance != null ? Scenario.Instance.get() : "default")}"",
        //     ""action"": ""{(RizzInput.Instance != null ? RizzInput.Instance.get() : "default")}""
        // }}";
    }

    IEnumerator SendPostRequest(string jsonData)
    {
        Debug.Log(jsonData); // Log the player input data

        // Create a UnityWebRequest to send a POST request
        UnityWebRequest www = new(url, "POST")
        {
            uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(jsonData)),
            downloadHandler = new DownloadHandlerBuffer()
        };

        // Set content type to JSON
        www.SetRequestHeader("Content-Type", "application/json");

        // Wait for the request to complete
        yield return www.SendWebRequest();

        Debug.Log(www.result); // Log the result status

        // Check for errors
        if (www.result == UnityWebRequest.Result.Success)
        {
            // Handle the response (success)
            AIOutput ai = JsonUtility.FromJson<AIOutput>(www.downloadHandler.text);

            Debug.Log(ai.Story);
            OutputText.text = ai.Story; // Show player the response

            Debug.Log(ai.Verdict); 
            if (ai.Verdict == "Pass") // Show player Pass/Fail
            {
                loadingResult.SetActive(false);
                passResult.SetActive(true);
            } 
            else 
            {
                loadingResult.SetActive(false);
                failResult.SetActive(true);
            }
        } 
        else 
        {
            // Handle errors (failure)
            Debug.LogError("Error: " + www.error);
        }
    }
}