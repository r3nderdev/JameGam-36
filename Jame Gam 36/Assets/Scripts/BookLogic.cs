using UnityEngine;

public class BookLogic : MonoBehaviour
{
    public Animator animator;
    [SerializeField] Book bookScript;

    public void OpenBook()
    {
        animator.SetTrigger("BookOpen");
        gameObject.GetComponent<SphereCollider>().enabled = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && bookScript.currentPage == 4)
        {
            Debug.Log("World Changing");
            //Trigger world change
        }
    }
}
