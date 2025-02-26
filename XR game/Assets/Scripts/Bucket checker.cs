using UnityEngine;

public class BucketTrigger : MonoBehaviour
{
    public Light indicatorLight; 
    public Color triggeredColor; 
    public Color defaultColor = Color.white; 
    private int ballCount = 0; 

    private void Start()
    {
        if (indicatorLight != null)
        {
            indicatorLight.color = defaultColor;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            ballCount++;
            UpdateLight();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            ballCount = Mathf.Max(0, ballCount - 1);
            UpdateLight();
        }
    }

    private void UpdateLight()
    {
        if (indicatorLight != null)
        {
            indicatorLight.color = ballCount > 0 ? triggeredColor : defaultColor;
        }
    }
}
