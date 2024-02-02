using UnityEngine;

public class CandleLogic : MonoBehaviour
{
    [SerializeField] GameObject candleLighting;
    [SerializeField] ParticleSystem particles;

    
    public void LightCandle()
    {
        // Disable the candle's own collider
        gameObject.GetComponent<SphereCollider>().enabled = false;
        // Turn on candle
        candleLighting.SetActive(true);
        particles.Play();
    }
}
