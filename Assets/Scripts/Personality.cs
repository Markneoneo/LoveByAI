using TMPro;
using UnityEngine;
public class Personality : MonoBehaviour
{
    // Static instance of the class
    [SerializeField] private string personalityText;
    public static Personality Instance { get; private set; }

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

    public void Outgoing()
    {
        personalityText = "Outgoing and Energetic";
    }

    public void Introverted()
    {
        personalityText = "Introverted and Quiet";
    }

    public void Practical()
    {
        personalityText =  "Practical and Honest";
    }

    public void Empathetic()
    {
        personalityText = "Empathetic and Caring";
    }

    public void Charismatic()
    {
        personalityText = "Charismatic and Easygoing";
    }

    public string get() { return personalityText; }

}
