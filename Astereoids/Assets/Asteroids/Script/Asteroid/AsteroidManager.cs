using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager : MonoBehaviour {

    public GameObject[] asteroidPrefabs; // Array of prefabs to spawn
    public float maxVelocity = 3f; // Max velocity an asteroid can move
    public float spawnRate = 1f; // Rate of spawn
    public float spawnPadding = 2f; // Padding to spawn

    public Color Colour = Color.cyan;

    // Singleton
    public static AsteroidManager Instance;
    void Awake()
    {
        Instance = this;        
    }

    // Spawns an asteroid at a position specified
    public static void Spawn(GameObject prefab, Vector3 position)
    {
        // Randomize a rotation for asteroid
        Quaternion randomRot = Quaternion.Euler(0, 0, Random.Range(0f, 360f));

        // Spawn random asteroid at random position and default Quaternion rotation
        GameObject asteroid = Instantiate(prefab, position, randomRot, Instance.transform);

        // Get Rigidbody2D from asteroid
        Rigidbody2D rigid = asteroid.GetComponent<Rigidbody2D>();

        // Apply random force to rigidbody
        Vector2 randomForce = Random.insideUnitCircle * Instance.maxVelocity;
        rigid.AddForce(randomForce, ForceMode2D.Impulse);
    }

    // Spawn a random asteroid in the array at a random postion
    void SpawnLoop()
    {
        // Generate random position inside sphere with spawn padding (radius)
        //Vector3 randomPos = Random.insideUnitCircle * spawnPadding;

        // Get camera's bounds using Extension Method
        Bounds camBounds = Camera.main.GetBounds(spawnPadding);

        // Randomize a position within a circle
        Vector2 randomPos = camBounds.GetRandomPosOnBounds();

        // Generate random index into asteroid prefabs array
        int randomIndex = Random.Range(0, asteroidPrefabs.Length);

        // Get random asteroid prefab from array using index
        GameObject randomAsteroid = asteroidPrefabs[randomIndex];

        // Spawn using random pos
        Spawn(randomAsteroid, randomPos);
    }

	// Use this for initialization
	void Start ()
    {
        // Repeatedly call the spawn fucntion
        InvokeRepeating("SpawnLoop", 0, spawnRate);
	}

    // Draws debug elements for testing
    private void OnDrawGizmos()
    {
        Bounds camBounds = Camera.main.GetBounds(spawnPadding);
        Gizmos.color = Colour;
        Gizmos.DrawWireCube(camBounds.center, camBounds.size);
    }
}
