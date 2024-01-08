using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject enemies;
    private float ranx;
    private float ranz;

    private int stage = 1;
    private int aux = 0;

    private void Awake()
    {
        Spawn();
    }

    private void Spawn()
    {
        ranx = Random.Range(-8, 8);
        ranz = Random.Range(-8, 8);
        Instantiate(enemies, new Vector3(ranx, 0, ranz), Quaternion.identity);
    }

    private void Update()
    {
        
    }
}
