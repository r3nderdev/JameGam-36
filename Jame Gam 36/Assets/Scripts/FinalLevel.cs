using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalLevel : MonoBehaviour
{
    public Book book;
    public LevelFade fade;

    // Update is called once per frame
    void Update()
    {
        if (book.currentPage == 6)
        {
            // End game
            fade.FadeToLevel(3);
        }
    }
}
