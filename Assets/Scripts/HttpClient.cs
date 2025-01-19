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
    public string username;
    string personality;
    string scenario;
    string action;

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

    public void get(string user,string scenario,string personality,string action)
    {
        username = user;
        /*        string jsonData = $@"
                {{
                    ""username"": ""{username}"",
                    ""personality"": ""{(Personality.Instance != null ? Personality.Instance.get() : "default")}"",
                    ""scenario"": ""{(Scenario.Instance != null ? Scenario.Instance.get() : "default")}"",
                    ""action"": ""{(RizzInput.Instance != null ? RizzInput.Instance.get() : "default")}""
                }}";*/

        string jsonData2 = "{\n";
        jsonData2 += "  \"username\": \"" + user + "\",\n";
        jsonData2 += "  \"personality\": \"" + personality + "\",\n";
        jsonData2 += "  \"scenario\": \"" + scenario + "\",\n";
        jsonData2 += "  \"action\": \"" + action + "\"\n";
        jsonData2 += "}";


        Debug.Log("RUN!!!");
        StartCoroutine(SendPostRequest(jsonData2));
    }

    // Start is called before the first frame update
    /*    void Start()
        {
            // Start the POST request
            StartCoroutine(SendPostRequest());
        }*/

    // Coroutine to send POST request
    IEnumerator SendPostRequest(string jsonData)
    {
        // Create a UnityWebRequest to send a POST request
        Debug.Log(jsonData);
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
                ResponseText.text = ai.Story;
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
