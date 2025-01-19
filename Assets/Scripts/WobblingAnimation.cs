using UnityEngine;

public class WobblingAnimation : MonoBehaviour
{
    public float ySpeed = 1.0f; // Speed for vertical movement
    public float xSpeed = 1.0f; // Speed for horizontal movement
    public float yAmount = 0.5f; // Amount of vertical movement
    public float xAmount = 0.3f; // Amount of horizontal movement
    private Vector3 originalPosition;

    private void Start()
    {
        // Store the original local position of the button
        originalPosition = transform.localPosition;
    }

    private void Update()
    {
        // Calculate the bobbing offset for the y-axis using Mathf.PingPong
        float yOffset = Mathf.PingPong(Time.time * ySpeed, yAmount);
        
        // Calculate the wobble offset for the x-axis using Mathf.PingPong
        float xOffset = Mathf.PingPong(Time.time * xSpeed, xAmount) - (xAmount / 2); // Center the wobble around the original position

        // Apply both the bobbing and wobbling effects to the position of the button
        transform.localPosition = originalPosition + new Vector3(xOffset, yOffset, 0);
    }
}
