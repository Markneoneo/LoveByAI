using UnityEngine;

public class BobbingAnimation : MonoBehaviour
{
    public float speed = 1.0f;
    public float bobAmount = 0.5f;
    private Vector3 originalPosition;

    private void Start()
    {
        // Store the original local position of the button
        originalPosition = transform.localPosition;
    }

    private void Update()
    {
        // Calculate the bobbing offset using Mathf.PingPong
        float bobOffset = Mathf.PingPong(Time.time * speed, bobAmount);

        // Apply the bobbing effect to the y-position of the button
        transform.localPosition = originalPosition + new Vector3(0, bobOffset, 0);
    }
}
