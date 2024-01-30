using UnityEngine;

public class PositionFollower : MonoBehaviour
{
    public Transform TargetTransform;
    public Vector3 Offset;

    public float smoothTime = 0.3f;

    private Vector3 velocity = Vector3.zero;

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = Vector3.SmoothDamp(transform.position,TargetTransform.position + Offset, ref velocity, smoothTime);
    }
}
