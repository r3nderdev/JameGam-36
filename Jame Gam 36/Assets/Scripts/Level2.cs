using UnityEngine;

public class Level2 : MonoBehaviour
{
    [SerializeField] GameObject text;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Destroy(text);
            Destroy(gameObject);
        }
    }
}
