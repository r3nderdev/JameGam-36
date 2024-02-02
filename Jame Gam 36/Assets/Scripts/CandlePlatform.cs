using UnityEngine;
using System.Collections;

public class CandlePlatform : MonoBehaviour
{
    public AudioSource source;
    public AudioClip doorHide;
    public AudioClip doorShow;

    private void Start()
    {
        StartCoroutine(StartMute());
    }


    private void Update()
    {
        if (!PlayerInteraction.candleOn)
        {
            gameObject.GetComponent<Animator>().SetTrigger("WallShow");
        }
    }
    // Update is called once per frame
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (PlayerInteraction.candleOn)
            {
                gameObject.GetComponent<Animator>().SetTrigger("WallHide");
            }
        }
    }

    public void PlayHideSound()
    {
        source.clip = doorHide;
        source.Play();
    }

    public void PlayShowSound()
    {
        source.clip = doorShow;
        source.Play();
    }

    IEnumerator StartMute()
    {
        source.mute = true;
        yield return new WaitForSeconds(2);
        source.mute = false;
    }
}
