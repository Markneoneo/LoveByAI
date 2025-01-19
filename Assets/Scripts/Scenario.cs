using TMPro;
using UnityEngine;
public class Scenario : MonoBehaviour
{
    // Static instance of the class
    [SerializeField] private string dateScenarioText;
    public static Scenario Instance { get; private set; }

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

    public void Kayaking()
    {
        dateScenarioText = "You and AI are on a nighttime kayaking adventure, paddling through bioluminescent waters.";
    }

    public void Wildlife()
    {
        dateScenarioText = "You are volunteering with AI at a wildlife sanctuary, helping to release rehabilitated animals back into the wild.";
    }

    public void Market()
    {
        dateScenarioText = "You meet AI at a vintage flea market, and the two of you compete to find the quirkiest item.";
    }

    public void Balloon()
    {
        dateScenarioText = "You're at a hot air balloon festival with AI, and she dares you to ride one together.";
    }

    public void Abandoned()
    {
        dateScenarioText = "You're exploring an abandoned historical fort with AI, armed with flashlights and a shared sense of curiosity.";
    }

    public string get() { return dateScenarioText; }

}
