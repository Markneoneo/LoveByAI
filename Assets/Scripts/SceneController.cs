using System.Collections;
using UnityEngine;
using TMPro;

public class SceneController : MonoBehaviour
{
    public GameObject titleScreen;
    public GameObject nameScreen;
    public GameObject AIScreen;
    public GameObject dateScreen;
    public GameObject inputScreen;
    public GameObject resultScreen;
    // public GameObject settingsScreen;
    // public GameObject creditsScreen;

    public TMP_InputField nameInputField;
    public TMP_InputField rizzInputField;
    [SerializeField] private string nameText;
    [SerializeField] private string personalityText;
    [SerializeField] private string dateScenarioText;
    [SerializeField] private string rizzText;
    [SerializeField] private bool pass; // True = successful rizz

    void Start()
    {
        MenuSelect();
    }

    #region Screen Select
    public void MenuSelect()
    {
        titleScreen.SetActive(true);
        nameScreen.SetActive(false);
        AIScreen.SetActive(false);
        dateScreen.SetActive(false);
        inputScreen.SetActive(false);
        resultScreen.SetActive(false);
        // settingsScreen.SetActive(false);
        // creditsScreen.SetActive(false);
    }

    public void NameSelect()
    {
        titleScreen.SetActive(false);
        nameScreen.SetActive(true);
    }

    public void AISelect()
    {
        nameText = nameInputField.text;
        nameScreen.SetActive(false);
        AIScreen.SetActive(true);
    }

    public void DateSelect()
    {
        AIScreen.SetActive(false);
        dateScreen.SetActive(true);
    }

    public void InputSelect()
    {
        dateScreen.SetActive(false);
        inputScreen.SetActive(true);
    }

    public void ResultSelect()
    {
        rizzText = rizzInputField.text;
        inputScreen.SetActive(false);
        resultScreen.SetActive(true);
    }

    public void ExitGame()
    {
        Debug.Log("Game is exiting");
        Application.Quit();
    }

    // IEnumerator ShowMessage(GameObject message)
    // {
    //     message.SetActive(true);
    //     yield return new WaitForSeconds(5);
    //     message.SetActive(false);
    // }
    #endregion

    #region Personality
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
        personalityText = "Practical and Honest";
    }

    public void Empathetic()
    {
        personalityText = "Empathetic and Caring";
    }

    public void Charismatic()
    {
        personalityText = "Charismatic and Easygoing";
    }
    #endregion

    #region Date Scenario
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
    #endregion
}
