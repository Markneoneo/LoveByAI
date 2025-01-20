using TMPro;
using UnityEngine;

public class Personality : MonoBehaviour
{
    // Singleton instance of the class
    public static Personality Instance { get; private set; }
    private string personalityText;

    public enum PersonalityType
    {
        Outgoing,
        Introverted,
        Charismatic,
        Pragmatic,
        Empathetic,
    }

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

    public string PersonalityText
    {
        get => personalityText;
        private set => personalityText = value;
    }

    public void SetPersonality(int type)
    {
        PersonalityType personalityType = (PersonalityType)type;

        switch (personalityType)
        {
            case PersonalityType.Outgoing: // 0
                PersonalityText = "Outgoing and Energetic";
                break;
            case PersonalityType.Introverted: // 1
                PersonalityText = "Introverted and Quiet";
                break;
            case PersonalityType.Charismatic: // 2
                PersonalityText = "Charismatic and Easygoing";
                break;
            case PersonalityType.Pragmatic: // 3
                PersonalityText = "Pragmatic and Honest";
                break;
            case PersonalityType.Empathetic: // 4
                PersonalityText = "Empathetic and Caring";
                break;
        }
        Debug.Log($"Personality set to: {PersonalityText}");
    }

    public string Get() => PersonalityText;
}
