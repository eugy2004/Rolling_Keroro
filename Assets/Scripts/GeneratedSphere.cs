using System.Collections.Generic;
using UnityEngine;

public class GeneratedSphere : MonoBehaviour
{
    public List<SphereData> spherePositions;

    private SphereData currentData;

    public int index = 0;

    private void Start()
    {
        index = spherePositions.Count - 2;
        currentData = spherePositions[^1];
        transform.position = currentData.position;
    }

    private void Update()
    {
        if (spherePositions.Count > 0)
        {
            Vector3 targetPosition = spherePositions[index].position;
            transform.position = Vector3.Lerp(transform.position, targetPosition,
                currentData.time - spherePositions[index].time);
            if (Vector3.Distance(transform.position, targetPosition) < 0.2f)
            {
                currentData = spherePositions[index];
                index--;
                if (index < 0)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
