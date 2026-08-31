using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<SphereController>(out _))
            Destroy(collision.gameObject);
    }
}
