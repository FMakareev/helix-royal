using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random=UnityEngine.Random;

public class TowerBuilder : MonoBehaviour
{

    [SerializeField] private int _levelCount;
    [SerializeField] private float _additionalScale;
    [SerializeField] private float _offsetBeatweenPlatform = 5;
    [SerializeField] private GameObject _beam;
    [SerializeField] private SpawnPlatform _spawnPlatform;
    [SerializeField] private FinishPlatform _finishPlatform;
    [SerializeField] private Platform[] _platforms;
    [SerializeField] private BallTracking _ballTracking;

    
    private float _startAndFinishAdditionalScale = 1f;

    public float BeamScaleY => _levelCount * _offsetBeatweenPlatform / 2f + _startAndFinishAdditionalScale + _additionalScale / 2f;

    private void Start()
    {
        ReBuild();
    }

    private void Clear()
    {
        foreach (Transform child in transform) {
            GameObject.Destroy(child.gameObject);
        }
    }

    public void ReBuild()
    {
        Clear();
        Build();
        _ballTracking.Setup();
    }
    
    private void Build()
    {
        List<Platform> platformList = new List<Platform>(); 
        GameObject beam = BuildBeam();

        Vector3 spawnPosition = beam.transform.position;

        spawnPosition.y += beam.transform.localScale.y - _additionalScale;
        
        platformList.Add(SpawnPlatform<SpawnPlatform>(_spawnPlatform, ref spawnPosition, transform));
        
        
        for (int i = 0; i < _levelCount; i += 1)
        {
            platformList.Add(SpawnPlatform<Platform>(_platforms[Random.Range(0, _platforms.Length)], ref spawnPosition,
                transform));
        }

        platformList.Add(SpawnPlatform<Platform>(_finishPlatform, ref spawnPosition, transform));
        
        
        List<NavMeshSurface> navMeshSurfaceList = new List<NavMeshSurface>();
        foreach (Platform platform in platformList)
        {
            foreach (DegEntity componentsInChild in platform.GetComponentsInChildren<DegEntity>())
            {
                navMeshSurfaceList.Add(componentsInChild.GetComponent<NavMeshSurface>());
            }
        }

        GetComponent<TowerNavigationBaker>().BuildNavMesh(navMeshSurfaceList);
    }


    private T SpawnPlatform<T>(Platform platform, ref Vector3 spawnPosition, Transform parent)
    {
        T platformInstance = (T)(object)Instantiate(platform, spawnPosition, Quaternion.Euler(0,Random.Range(0, 360),0), parent);
        spawnPosition.y -= _offsetBeatweenPlatform;
        return platformInstance;
    }

    private GameObject BuildBeam()
    {
        GameObject beam = Instantiate(_beam, transform);
        beam.transform.localScale = new Vector3(1, BeamScaleY, 1);

        return beam;
    }
    
    
}
