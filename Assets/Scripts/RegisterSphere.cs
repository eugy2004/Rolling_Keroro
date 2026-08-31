using System.Collections.Generic;
using UnityEngine;

public class RegisterSphere : MonoBehaviour
{
    public List<SphereData>[] spheres;

    public int index;

    private void Start()
    {
        index = 0;
        spheres = new List<SphereData>[10];
        for (int i = 0; i < spheres.Length; i++)
        {
            spheres[i] = new List<SphereData>();
        }
    }

    public void RegisterSpherePosition(SphereData data)
    {
        spheres[index].Add(data);
    }

    public void IncrementIndex()
    {
        index++;
        if (index >= spheres.Length)
        {
            index = 0;
        }
    }
}

[System.Serializable]
public struct SphereData
{
    public Vector3 position;
    public float time;
}