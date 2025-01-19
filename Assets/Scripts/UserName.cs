using TMPro;
using UnityEngine;

public class UserName : MonoBehaviour
{
    // Static instance of the class
    public TMP_InputField nameInputField;
    public static string nameField;
    public static UserName Instance { get; set; }

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

    public void updateName(string text)
    {
        nameField = text;
    }

    public string get() {
        Debug.Log("NAME: " + nameField);
        return nameField;
    }
}
