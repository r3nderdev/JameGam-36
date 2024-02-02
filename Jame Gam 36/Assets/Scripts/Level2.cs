using UnityEngine;

public class Level2 : MonoBehaviour
{
    [SerializeField] GameObject text;

    // Update is called once per frame
    void Update()
    {
        if (text != null&&Input.GetKeyDown(KeyCode.E))
        {
            Destroy(text);
        }
    }
}
