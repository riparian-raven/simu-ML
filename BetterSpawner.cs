using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterSpawner : MonoBehaviour
{
    public int boysToPlace = 5;
    public  int girlsToPlace = 5;
    [SerializeField] private GameObject girlToSpawn;
    //public GameObject[] Obstacles = new GameObject[0];
    //GameObject Obstacle;

    public float obstacleCheckRadius = 3f;
    [SerializeField] private GameObject boyToSpawn;
    public int maxSpawnAttemptsPerObstacle = 10;

    void Awake()
    {

        for (int i = 0; i < boysToPlace; i++)
        {
            //boyToSpawn = Obstacles[Random.Range(0, Obstacles.Length)];

            // Create a position variable
            Vector3 position = Vector3.zero;

            // whether or not we can spawn in this position
            bool validPosition = false;

            // How many times we've attempted to spawn this obstacle
            int spawnAttempts = 0;

            // While we don't have a valid position 
            //  and we haven't tried spawning this obstable too many times
            while (!validPosition && spawnAttempts < maxSpawnAttemptsPerObstacle)
            {
                // Increase our spawn attempts
                spawnAttempts++;

                // Pick a random position
                position = new Vector3(Random.Range(-25f, 25.0f), 0, Random.Range(-25.0f, 25.0f));

                // This position is valid until proven invalid
                validPosition = true;

                // Collect all colliders within our Obstacle Check Radius
                Collider[] colliders = Physics.OverlapSphere(position, obstacleCheckRadius);

                // Go through each collider collected
                foreach (Collider col in colliders)
                {
                    // If this collider is tagged "Obstacle"
                    if (col.tag == "Obstacle")
                    {
                        // Then this position is not a valid spawn position
                        validPosition = false;
                    }
                }
            }

            // If we exited the loop with a valid position
            if (validPosition)
            {
                // Spawn the obstacle here
                Vector3 randoPos = transform.localPosition + new Vector3(Random.Range(-25, 25), 0, Random.Range(-25, 25));
               GameObject boyClone = Instantiate(boyToSpawn, randoPos, Quaternion.identity);
                mindHead.prespawnBoys += 1;
                //Instantiate(boyClone, position + boyClone.transform.position, Quaternion.identity);

            }
        }
    
    
        
    
    

        for (int i = 0; i < girlsToPlace; i++)
        {
            //boyToSpawn = Obstacles[Random.Range(0, Obstacles.Length)];

            // Create a position variable
            Vector3 position = Vector3.zero;

            // whether or not we can spawn in this position
            bool validPosition = false;

            // How many times we've attempted to spawn this obstacle
            int spawnAttempts = 0;

            // While we don't have a valid position 
            //  and we haven't tried spawning this obstable too many times
            while (!validPosition && spawnAttempts < maxSpawnAttemptsPerObstacle)
            {
                // Increase our spawn attempts
                spawnAttempts++;

                // Pick a random position
                position = new Vector3(Random.Range(-25f, 25.0f), 0, Random.Range(-25.0f, 25.0f));

                // This position is valid until proven invalid
                validPosition = true;

                // Collect all colliders within our Obstacle Check Radius
                Collider[] colliders = Physics.OverlapSphere(position, obstacleCheckRadius);

                // Go through each collider collected
                foreach (Collider col in colliders)
                {
                    // If this collider is tagged "Obstacle"
                    if (col.tag == "Obstacle")
                    {
                        // Then this position is not a valid spawn position
                        validPosition = false;
                    }
                }
            }

            // If we exited the loop with a valid position
            if (validPosition)
            {
                // Spawn the obstacle here
                Vector3 randoPos = transform.localPosition + new Vector3(Random.Range(-25, 25), 0, Random.Range(-25, 25));
                GameObject boyClone = Instantiate(girlToSpawn, randoPos, Quaternion.identity);
                mindHead.prespawnGirls += 1;
            }
        }
    }
}