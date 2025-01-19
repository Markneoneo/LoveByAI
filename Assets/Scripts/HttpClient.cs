using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class HttpClient : MonoBehaviour
{
    public static HttpClient instance { get; private set; } // Singleton instance

    public TMP_Text ResponseText;

    private string url = "http://127.0.0.1:8000/play/";  // FastAPI backend endpoint

    // Collect data from the input fields
    string username;
    string personality;
    string scenario;
    string action;

    string jsonData = $@"
         {{
             ""username"": ""{UserName.Instance.get()}"",
             ""personality"": ""{Personality.Instance.get()}"",
             ""scenario"": ""{Scenario.Instance.get()}"",
             ""action"": ""{RizzInput.Instance.get()}""
         }}";

    void Awake()
    {
        // Singleton pattern implementation
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Persist across scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void get()
    {
        Debug.Log("RUN!!!");
        StartCoroutine(SendPostRequest());
    }

    // Start is called before the first frame update
    /*    void Start()
        {
            // Start the POST request
            StartCoroutine(SendPostRequest());
        }*/

    // Coroutine to send POST request
    IEnumerator SendPostRequest()
    {
        // Create a UnityWebRequest to send a POST request
        using (UnityWebRequest www = UnityWebRequest.PostWwwForm(url, jsonData))
        {
            // Set content type to JSON
            www.SetRequestHeader("Content-Type", "application/json");
            Debug.Log(jsonData);

            // Define the body for the POST request
            byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonData);
            www.uploadHandler = new UploadHandlerRaw(bodyRaw);
            www.downloadHandler = new DownloadHandlerBuffer();

            // Wait for the request to complete
            yield return www.SendWebRequest();

            Debug.Log(www.result);

            // Check for errors
            if (www.result == UnityWebRequest.Result.Success)
            {
                // Handle the response (success)
                //Debug.Log("Response: " + www.downloadHandler.text);
                AIOutput ai  = JsonUtility.FromJson<AIOutput>(www.downloadHandler.text);
                Debug.Log(ai.Story);
                //string jsonString = JsonUtility.ToJson(www.downloadHandler.text);
            }
            else
            {
                // Handle errors (failure)
                Debug.LogError("Error: " + www.error);
            }
        }
    }
}
