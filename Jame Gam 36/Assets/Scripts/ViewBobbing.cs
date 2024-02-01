using UnityEngine;

[RequireComponent(typeof(PositionFollower))]

public class ViewBobbing : MonoBehaviour
{
    public float intensity;
    public float intensityX;
    public float speed;

    private PositionFollower followerInstance;
    private Vector3 originalOffset;
    private float sinTime;

    // Start is called before the first frame update
    void Start()
    {
        followerInstance = GetComponent<PositionFollower>();
        originalOffset = followerInstance.Offset;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 inputVector = new(Input.GetAxis("Vertical"), 0f, Input.GetAxis("Horizontal"));

        if (inputVector.magnitude > 0f)
        {
            sinTime += Time.deltaTime * speed;
        }
        else
        {
            sinTime = 0f;
        }

        float sinAmountY = -Mathf.Abs(intensity * Mathf.Sin(sinTime));
        Vector3 sinAmountX = intensity * intensityX * Mathf.Cos(sinTime) * followerInstance.transform.right;

        followerInstance.Offset = new Vector3
        {
            x = originalOffset.x,
            y = originalOffset.y + sinAmountY,
            z = originalOffset.z
        };

        followerInstance.Offset += sinAmountX;
    }
}
