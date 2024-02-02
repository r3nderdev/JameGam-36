using UnityEngine;
using TMPro;
using EZCameraShake;
using UnityEngine.SceneManagement;

public class BookLogic : MonoBehaviour
{
    public Animator animator;
    public TMP_Text bookText;
    public GameObject textPanel;

    public Transform cameraPos;
    public CameraShaker shaker;
    [SerializeField] Book bookScript;
    public LevelFade levelFade;


    public void OpenBook()
    {
        PlayerMovement.canMove = false;
        animator.SetTrigger("BookOpen");
        gameObject.GetComponentInParent<Animator>().SetTrigger("BookDisappear");
        gameObject.GetComponent<SphereCollider>().enabled = false;
    }

    private void Update()
    {
        if(bookScript.currentPage == 4)
        {
            // Show text
            bookText.enabled = true;
            textPanel.SetActive(true);
            // If player says Lux Echo
            if (Input.GetKeyDown(KeyCode.E))
            {
                // Start camera shake and million other things
                shaker.enabled = true;
                shaker.RestPositionOffset = new Vector3(cameraPos.position.x,cameraPos.position.y,cameraPos.position.z);
                shaker.RestRotationOffset = new Vector3(cameraPos.rotation.x, cameraPos.rotation.y, cameraPos.rotation.z);
                CameraShaker.Instance.StartShake(3f, 3f, 1f);
                AudioManager.Instance.PlaySFX("Rumble");
                animator.SetTrigger("BookClose");
                bookText.enabled = false;
                textPanel.SetActive(false);
                Debug.Log("World Changing");
                //Trigger world change
                levelFade.FadeToLevel(SceneManager.GetActiveScene().buildIndex+1);
            }
        }
        else
        {
            bookText.enabled = false;
            textPanel.SetActive(false);
        }
        
    }
}
