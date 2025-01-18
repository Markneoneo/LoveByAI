using System.Collections;
using UnityEngine;
using TMPro;

public class SceneController : MonoBehaviour
{
    public GameObject titleScreen;
    public GameObject nameScreen;
    public GameObject AIScreen;
    public GameObject dateScreen;
    public GameObject gameScreen;
    public GameObject settingsScreen;
    public GameObject creditsScreen;

    void Start()
    {
        MenuSelect();
    }

    public void MenuSelect()
    {
        // Activate title screen only
        titleScreen.SetActive(true);
        nameScreen.SetActive(false);
        AIScreen.SetActive(false);
        dateScreen.SetActive(false);
        gameScreen.SetActive(false);
        settingsScreen.SetActive(false);
        creditsScreen.SetActive(false);
    }

    public void NameSelect()
    {
        titleScreen.SetActive(false);
        nameScreen.SetActive(true);
    }

    public void AISelect()
    {
        nameScreen.SetActive(false);
        AIScreen.SetActive(true);
    }

    public void DateSelect()
    {
        AIScreen.SetActive(false);
        dateScreen.SetActive(true);
    }

    public void GameSelect()
    {
        dateScreen.SetActive(false);
        gameScreen.SetActive(true);
    }

    public void ToggleSettings()
    {
        settingsScreen.SetActive(!settingsScreen.activeSelf);
    }

    public void ToggleCredits()
    {
        creditsScreen.SetActive(!creditsScreen.activeSelf);
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Game is exiting");
    }

    IEnumerator ShowMessage(GameObject message)
    {
        message.SetActive(true);
        yield return new WaitForSeconds(5);
        message.SetActive(false);
    }
}