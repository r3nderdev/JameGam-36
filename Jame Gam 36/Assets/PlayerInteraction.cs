using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [Header("Candle")]
    public GameObject candleLighting;

    public static bool candleOn;
    public KeyCode candleKey = KeyCode.E;


    // Update is called once per frame
    void Update()
    {
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
                candleLighting.SetActive(false);
            // If it is off, light it
            else if (!candleOn)
                candleLighting.SetActive(true);

        }
    }
}
