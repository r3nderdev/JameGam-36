using UnityEngine;

public class CandleDoor : MonoBehaviour
{
    private void Update()
    {
        if (PlayerInteraction.candleOn)
        {
            gameObject.GetComponent<Animator>().SetTrigger("WallShow");
        }
    }
    // Update is called once per frame
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!PlayerInteraction.candleOn)
            {
                gameObject.GetComponent<Animator>().SetTrigger("WallHide");
            }
        }
    }
}
