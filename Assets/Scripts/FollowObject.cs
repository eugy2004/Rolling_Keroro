using UnityEngine;

public class FollowObject : MonoBehaviour
{
    public Transform target; // The object to follow

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position; // Set the position of this object to the target's position
    }
}
