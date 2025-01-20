using UnityEngine;
using TMPro;

public class UserName : MonoBehaviour
{
    // Singleton instance of the class
    public static UserName Instance { get; set; }
    public TMP_InputField nameInputField;
    public static string nameField;

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

    public string Get() 
    {
        Debug.Log("NAME: " + nameField);
        return nameField;
    }
}
