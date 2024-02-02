using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelFade : MonoBehaviour
{
    private Animator animator;
    private int levelToLoad;

    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    public void FadeToLevel(int levelIndex)
    {
        levelToLoad = levelIndex;
        animator.SetTrigger("FadeIn");
    }

    public void OnFadeComplete()
    {
        // Load new scene
        Debug.Log("Loading scene: " + levelToLoad);
        SceneManager.LoadScene(levelToLoad);
    }
}
