using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TowerNavigationBaker : MonoBehaviour
{
    public void BuildNavMesh(List<NavMeshSurface> surfaces)
    {
        Debug.Log(surfaces.Count);
        for (var i = 0; i < surfaces.Count; i++)
        {
            try
            {
                if (surfaces[i])
                {
                    surfaces[i].BuildNavMesh();
                }
            }
            catch (Exception e)
            {
                Debug.Log(i);
                Console.WriteLine(e);
                throw;
            }
        }
    }
}