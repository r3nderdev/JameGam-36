using UnityEngine;

public class RotationFollower : MonoBehaviour
{
    public Transform target;

    private void LateUpdate()
    {
        transform.rotation = target.rotation;
    }
}
