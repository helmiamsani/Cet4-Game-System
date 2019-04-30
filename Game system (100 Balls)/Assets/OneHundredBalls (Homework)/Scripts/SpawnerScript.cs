using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    // Public
    public GameObject[] prefabs = null;
    public float spawnRadius = 5.0f;
    public float spawnRate = 1.0f;
    private float spawnFactor = 0.0f;

    // Update is called once per frame
	void Update ()
    {
        HandleSpawn();
	}
	
	// Handles spawning of objects
    void HandleSpawn()
    {
        spawnFactor += Time.deltaTime;
        if (spawnFactor > spawnRate) // When the spawn factor timer reaches the interval (rate)
        {
            int randomIndex = Random.Range(0, prefabs.Length); // Get a random index into the array
            Spawn(prefabs[randomIndex]); // Spawn a random prefab from the list
            spawnFactor = 0; // Reset spawn factor (timer)
        }   
    }

    // Spawns an object based off of the argument passed in "_object"
    void Spawn(GameObject _object)
    {
        GameObject newObject = Instantiate(_object); // Clone the object
        Vector3 randomPoint = Random.insideUnitCircle * spawnRadius; // Generate random spawn point
        newObject.transform.position = transform.position + randomPoint; //Set new object's position to random one
    }
}
