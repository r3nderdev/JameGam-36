using UnityEngine;
using TMPro;

public class PlayerInteraction : MonoBehaviour
{
    [Header("Candle")]
    public GameObject candleLighting;
    public ParticleSystem particles;

    [Header("Raycast")]
    public Transform rayStart;
    public float rayLenght;
    public TMP_Text text;

    public static bool candleOn;
    public KeyCode candleKey = KeyCode.Mouse0;


    // Update is called once per frame
    void Update()
    {
        // Raycast for checking candles

        // Debug ray because yes
        Debug.DrawRay(rayStart.position, rayStart.transform.forward, Color.cyan);

        // Raycast
        if (Physics.Raycast(rayStart.position, rayStart.transform.forward, out RaycastHit hit, rayLenght))
        {
            // If we're hitting a candle
            if (hit.collider.CompareTag("Candle"))
            {
                // Enable UI element to indicate interaction
                text.enabled = true;

                // If player presses E
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("Lit Candle");
                }
                
            }
            // If we're not hitting a candle anymore 
            else
            {
                text.enabled = false;
            }

        }
        // If we're not hitting anything anymore 
        else
        {
            text.enabled = false;
        }




        // Sets the candleOn static variable
        if (candleLighting.activeInHierarchy == true)
        {
            candleOn = true;
        }
        else
            candleOn = false;

        // If the key to light the candle is pressed
        if (Input.GetKeyDown(candleKey))
        {
            // If the candle is already on, extinguish it
            if (candleOn)
            {
                candleLighting.SetActive(false);
                particles.Stop();
            }
            // If it is off, light it
            else if (!candleOn)
            {
                candleLighting.SetActive(true);
                particles.Play();
            }


        }
    }
}
