using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerInteraction : MonoBehaviour
{
    [Header("Candle")]
    public GameObject candleLighting;
    public ParticleSystem particles;
    public float candleLife;
    public TMP_Text candleDeadText;

    [Header("Raycast")]
    public Transform rayStart;
    public float rayLenght;
    public TMP_Text candleText;
    public TMP_Text bookText;
    public LayerMask candleLayerMask;
    public LayerMask bookLayerMask;

    public static bool candleOn;
    public static bool candleDead;

    private GameObject hitCandle;
    private GameObject hitBook;


    // Update is called once per frame
    void Update()
    {
        // Sets the candleOn static variable
        if (candleLighting.activeInHierarchy == true)
        {
            candleOn = true;
            candleDead = false;
            // Deplete candle life
            candleLife -= Time.deltaTime;
            Debug.Log("Candle Life: " + candleLife);
        }
        else
            candleOn = false;

        // Candle death
        if (candleLife < 0)
        {
            // Candle has died
            candleDead = true;
            candleLighting.SetActive(false);
            particles.Stop();
            candleDeadText.enabled = true;
        }

        // If we're hitting a candle
        if (Physics.Raycast(rayStart.position, rayStart.transform.forward, out RaycastHit hit, rayLenght, candleLayerMask))
        {
            // Enable UI element to indicate interaction
            candleText.enabled = true;

            // If player presses E
            if (Input.GetKeyDown(KeyCode.E))
            {
                hitCandle = hit.transform.gameObject;
                hitCandle.GetComponent<CandleLogic>().LightCandle();

                Debug.Log("Lit Candle");
            }
        }
        // If we're not hitting a candle anymore 
        else 
        {
            HeldCandle();
        }



        // If we're hitting a book
        if (Physics.Raycast(rayStart.position, rayStart.transform.forward, out RaycastHit _hit, rayLenght, bookLayerMask))
        {
            // Enable UI element to indicate interaction
            bookText.enabled = true;

            // If player presses E
            if (Input.GetKeyDown(KeyCode.E))
            {
                hitBook = _hit.transform.gameObject;
                hitBook.GetComponent<BookLogic>().OpenBook();

                Debug.Log("Opened Book");
            }
        }
        // If we're not hitting a book anymore
        else
        {
            bookText.enabled = false;
        }

        // Restarts the level if player hits R
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        // Runs when we're not hitting a world candle
        void HeldCandle()
        {
            candleText.enabled = false;


            // If the key to light the held candle is pressed
            if (!candleDead && Input.GetKeyDown(KeyCode.E))
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
}
