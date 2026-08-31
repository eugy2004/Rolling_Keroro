using UnityEngine;

public class Finish : MonoBehaviour
{
    public ReproduceSphere reproduceSphere;

    public RegisterSphere registerSphere;

    public bool isFinished = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<SphereController>(out var sphereController))
        {
            if (isFinished) return;
            isFinished = true;
            reproduceSphere.IncrementIndex();
            reproduceSphere.OnFinish();
            reproduceSphere.sphereSpawnStart = true;
            reproduceSphere.GenerateSpheres();
            sphereController.transform.position = sphereController.startPos;
            sphereController.gameObject.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
            registerSphere.IncrementIndex();
            isFinished = false;
        }
    }
}
