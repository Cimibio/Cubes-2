using System.Collections.Generic;
using UnityEngine;

public class CubeExploder : MonoBehaviour
{
    public void ExplodeCubes(Cube cube)
    {
        foreach (Rigidbody affectedObjects in GetAffectedObjects(cube))
            affectedObjects.AddExplosionForce(cube.ExplodeForce, cube.transform.position, cube.ExplodeRadius);
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
