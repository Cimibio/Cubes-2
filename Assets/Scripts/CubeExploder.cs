using System.Collections.Generic;
using UnityEngine;

public class CubeExploder : MonoBehaviour
{
    public void ExplodeCubes(Cube cube)
    {
        foreach (Rigidbody affectedObject in GetAffectedObjects(cube))
        {
            float distance = Vector3.Distance(affectedObject.position, cube.transform.position);
            float forceMultiplier = CalculateForceMultiplier(distance, cube.ExplodeRadius);
            float finalForce = cube.ExplodeForce * forceMultiplier;

            affectedObject.AddExplosionForce(finalForce, cube.transform.position, cube.ExplodeRadius);
        }
    }

    private float CalculateForceMultiplier(float distance, float radius)
    {
        if (distance >= radius) return 0f;

        return 1f - (distance / radius);
    }

    private List<Rigidbody> GetAffectedObjects(Cube cube)
    {
        Collider[] hits = Physics.OverlapSphere(cube.transform.position, cube.ExplodeRadius);

        List<Rigidbody> cubes = new();

        foreach (Collider hit in hits)
            if (hit.attachedRigidbody != null)
                cubes.Add(hit.attachedRigidbody);

        return cubes;
    }
}
