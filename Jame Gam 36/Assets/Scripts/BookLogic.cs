using UnityEngine;
using TMPro;

public class BookLogic : MonoBehaviour
{
    public Animator animator;
    public TMP_Text bookText;
    public GameObject textPanel;
    [SerializeField] Book bookScript;





    public void OpenBook()
    {
        animator.SetTrigger("BookOpen");
        gameObject.GetComponent<Animator>().SetTrigger("BookDisappear");
        gameObject.GetComponent<SphereCollider>().enabled = false;
    }

    private void Update()
    {
        if(bookScript.currentPage == 4)
        {
            // Show text
            bookText.enabled = true;
            textPanel.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("World Changing");
                //Trigger world change
            }
        }
        else
        {
            bookText.enabled = false;
            textPanel.SetActive(false);
        }
        
    }
}
