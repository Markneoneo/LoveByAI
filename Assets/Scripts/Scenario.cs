using TMPro;
using UnityEngine;

public class Scenario : MonoBehaviour
{
    // Singleton instance of the class
    public static Scenario Instance { get; private set; }
    private string dateScenarioText;

    public enum ScenarioType
    {
        Wildlife,
        Kayaking,
        Abandoned,
        Market,
        Balloon,
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

    public string DateScenarioText
    {
        get => dateScenarioText;
        private set => dateScenarioText = value;
    }

    public void SetScenario(int type)
    {
        ScenarioType scenarioType = (ScenarioType)type;

        switch (scenarioType)
        {
            case ScenarioType.Wildlife:
                DateScenarioText = "You are volunteering with AI at a wildlife sanctuary, helping to release rehabilitated animals back into the wild.";
                break;
            case ScenarioType.Kayaking:
                DateScenarioText = "You and AI are on a nighttime kayaking adventure, paddling through bioluminescent waters.";
                break;
            case ScenarioType.Abandoned:
                DateScenarioText = "You are exploring an abandoned historical fort with AI, armed with flashlights and a shared sense of curiosity.";
                break;
            case ScenarioType.Market:
                DateScenarioText = "You meet AI at a vintage flea market, and the two of you compete to find the quirkiest item.";
                break;
            case ScenarioType.Balloon:
                DateScenarioText = "You are at a hot air balloon festival with AI, and she dares you to ride one together.";
                break;
        }
        Debug.Log($"Scenario set to: {DateScenarioText}");
    }

    public string Get() => DateScenarioText;
}
