using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _asteroidPrefabs;
    [SerializeField] private float _secondsBetweenAsteroids = 1.5f;
    [SerializeField] private Vector2 _forceRange;

    private Camera _mainCamera;
    private float _timer;

    private void Awake()
    {
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        _timer -= Time.deltaTime;

        if(_timer <= 0)
        {
            SpawnAsteroid();

            _timer += _secondsBetweenAsteroids;
        }
    }

    private void SpawnAsteroid()
    {
        int side = Random.Range(0, 4);

        Vector2 spawnPoint = Vector2.zero;
        Vector2 direction = Vector2.zero;

        switch (side)
        {
            case 0:
                // Left
                spawnPoint.x = 0;
                spawnPoint.y = Random.value;
                direction = new Vector2(1f, Random.Range(-1f, 1f));
                break;
            case 1:
                // Right
                spawnPoint.x = 1;
                spawnPoint.y = Random.value;
                direction = new Vector2(-1f, Random.Range(-1f, 1f));
                break;
            case 2:
                // Bottom
                spawnPoint.x = Random.value;
                spawnPoint.y = 0;
                direction = new Vector2(Random.Range(-1f, 1f),1f);
                break;
            case 3:
                // Top
                spawnPoint.x = Random.value;
                spawnPoint.y = 1;
                direction = new Vector2(Random.Range(-1f, 1f), -1f);
                break;
        }

        Vector3 worldSpawnPoint =  _mainCamera.ViewportToWorldPoint(spawnPoint);
        worldSpawnPoint.z = 0;

        GameObject selectedAsteroid = _asteroidPrefabs[Random.Range(0, _asteroidPrefabs.Length)];

        GameObject asteroidInstance =  Instantiate(selectedAsteroid,
            worldSpawnPoint,
            Quaternion.Euler(0f, 0f, Random.Range(0f, 360f)));

        Rigidbody rb = asteroidInstance.GetComponent<Rigidbody>();

        rb.velocity = direction.normalized * Random.Range(_forceRange.x, _forceRange.y) ;
    }
}
