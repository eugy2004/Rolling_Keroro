using System.Collections.Generic;
using UnityEngine;

public class ReproduceSphere : MonoBehaviour
{
    public RegisterSphere registerSphere; // Reference to the RegisterSphere script
    public GeneratedSphere spherePrefab; // Prefab of the sphere to be generated

    public bool sphereSpawnStart = false; // Flag to control sphere spawning

    public List<GeneratedSphere> generatedSpheres = new List<GeneratedSphere>();

    public int index = 0;

    public void GenerateSpheres()
    {
        if (!sphereSpawnStart) return;

        for (int i = 0; i < index; i++)
        {
            GeneratedSphere newSphere = Instantiate(spherePrefab, transform.position, Quaternion.identity);
            newSphere.spherePositions = registerSphere.spheres[i];
            generatedSpheres.Add(newSphere);
        }
        sphereSpawnStart = false; // Reset the flag after spawning spheres
    }

    public void OnFinish()
    {
        foreach (var sphere in generatedSpheres)
        {
            if (sphere != null)
            {
                Destroy(sphere.gameObject);
            }
        }
        generatedSpheres.Clear();
    }

    public void IncrementIndex()
    {
        index++;
    }
}
