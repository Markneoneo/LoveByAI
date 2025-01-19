using TMPro;
using UnityEngine;

public class UserName : MonoBehaviour
{
    // Static instance of the class
    public TMP_InputField nameInputField;
    public static UserName Instance { get; private set; }

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

    public string get() { return nameInputField.text; }

}
