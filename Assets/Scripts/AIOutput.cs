using UnityEngine;

[System.Serializable]
public class AIOutput
{
    public string Story;
    public string Verdict;

    public void AccessSpecificKeyValue(string json)
    {
        AIOutput playerData = JsonUtility.FromJson<AIOutput>(json);
        Debug.Log("Player Name: " + playerData.Story); // Access specific key
        Debug.Log("Player Score: " + playerData.Verdict);
    }
}
