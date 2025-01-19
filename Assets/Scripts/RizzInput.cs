using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class RizzInput : MonoBehaviour
{
    // Static instance of the class
    public TMP_InputField rizzInputField;
    private string finalInput;
    public static RizzInput Instance { get; private set; }

/*    private void Start()
    {
        // Add a listener to react when the user changes the input text
        rizzInputField.onValueChanged.AddListener(OnNameInputChanged);

        // Add a listener to react when the user finishes editing the input field
        rizzInputField.onEndEdit.AddListener(OnNameInputSubmitted);
    }*/

/*    private void OnNameInputChanged(string text)
    {
        Debug.Log("Text Changed: " + text);
    }

    private void OnNameInputSubmitted(string text)
    {
        Debug.Log("Text Submitted: " + text);
        //UserName.Instance.updateName(text);
        finalInput = text;
    }*/

    private void Awake()
    {
        // Check if an instance already exists
        if (Instance != null && Instance != this)
        {
            // Destroy this instance to enforce the singleton pattern
            Destroy(gameObject);
            return;
        }

        // Assign the instance
        Instance = this;

        // Optionally, make this object persist between scenes
        DontDestroyOnLoad(gameObject);
    }

    public void updateInput(string text)
    {
        finalInput = text;
    }

    public string get()
    {
        return finalInput;
    }

}
