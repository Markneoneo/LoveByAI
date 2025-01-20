using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine;
using TMPro;

public class SceneController : MonoBehaviour
{
    public GameObject titleScreen;
    public GameObject nameScreen;
    public GameObject personalityScreen;
    public GameObject dateScreen;
    public GameObject inputScreen;
    public GameObject resultScreen;

    public TMP_InputField nameInputField;
    private string username = "";
    public TMP_InputField rizzInputField;
    private string rizz;

    void Start()
    {
        MenuSelect();
        // Add a listener to react when the user changes the input text
        //nameInputField.onValueChanged.AddListener(OnNameInputChanged);
        // Add a listener to react when the user finishes editing the input field
        nameInputField.onEndEdit.AddListener(OnNameInputSubmitted);
        // Add a listener to react when the user changes the input text
        //rizzInputField.onValueChanged.AddListener(OnRizzInputChanged);
        // Add a listener to react when the user finishes editing the input field
        rizzInputField.onEndEdit.AddListener(OnRizzInputSubmitted);
    }

    // private void Update()
    // {
    //     // Check if the input field is focused and the Enter key is pressed
    //     if (rizzInputField.isFocused && Input.GetKeyDown(KeyCode.Return))
    //     {
    //         // Trigger the OnEndEdit event
    //         EventSystem.current.SetSelectedGameObject(null);
    //         rizzInputField.DeactivateInputField();
    //         rizzInputField.onEndEdit.Invoke(rizzInputField.text);
    //     }
    // }

    #region Inputs
    private void OnNameInputChanged(string text)
    {
        Debug.Log("Text Changed: " + text);
    }
    private void OnNameInputSubmitted(string text)
    {
        Debug.Log("Text Submitted: " + text);
        username = text;
    }

    private void OnRizzInputChanged(string text)
    {
        Debug.Log("Text Changed: " + text);
    }
    private void OnRizzInputSubmitted(string text)
    {
        Debug.Log("Text Submitted: " + text);
        rizz = text;
        HttpClient.Instance.Get(username, Scenario.Instance.Get(), Personality.Instance.Get(), rizz);
    }
    #endregion

    #region Screen Select
    public void MenuSelect()
    {
        titleScreen.SetActive(true);
        nameScreen.SetActive(false);
        personalityScreen.SetActive(false);
        dateScreen.SetActive(false);
        inputScreen.SetActive(false);
        resultScreen.SetActive(false);
    }

    public void NameSelect()
    {
        titleScreen.SetActive(false);
        nameScreen.SetActive(true);
    }

    public void AISelect()
    {
        //nameText = nameInputField.text;
        nameScreen.SetActive(false);
        personalityScreen.SetActive(true);
    }

    public void DateSelect()
    {
        personalityScreen.SetActive(false);
        dateScreen.SetActive(true);
    }

    public void InputSelect()
    {
        dateScreen.SetActive(false);
        inputScreen.SetActive(true);
    }

    public void ResultSelect()
    {
        //rizzText = rizzInputField.text;
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
}