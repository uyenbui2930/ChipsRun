using UnityEngine;

public class Spawner : MonoBehaviour
{
    [System.Serializable]
    public struct SpawnableObject
    {
        public GameObject prefab;
        [Range(0f, 1f)]
        public float spawnChance;
    }

    public SpawnableObject[] obstacles; // Obstacles list
    public GameObject acornPrefab;      // Acorn prefab
    public float minSpawnRate = 1f;
    public float maxSpawnRate = 2f;
    public float acornSpawnRate = 0.3f; // Chance to spawn acorns

    private void OnEnable()
    {
        Invoke(nameof(SpawnObstacle), Random.Range(minSpawnRate, maxSpawnRate));
        Invoke(nameof(SpawnAcorn), Random.Range(minSpawnRate, maxSpawnRate));
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    private void SpawnObstacle()
{
    float spawnChance = Random.value;

    // Set the fixed Y position for obstacles (same as acorns)
    float obstacleYPosition = 1f; // Adjust this value based on your ground level

    foreach (SpawnableObject obj in obstacles)
    {
        if (spawnChance < obj.spawnChance)
        {
            GameObject obstacle = Instantiate(obj.prefab);

            // Randomize X position and set the fixed Y position
            float randomX = Random.Range(-2f, 2f); // Adjust X-range as needed

            obstacle.transform.position = new Vector3(transform.position.x + randomX, obstacleYPosition, transform.position.z);
            break;
        }

        spawnChance -= obj.spawnChance;
    }

    Invoke(nameof(SpawnObstacle), Random.Range(minSpawnRate, maxSpawnRate));
}


    private void SpawnAcorn()
{
    if (Random.value < acornSpawnRate) // Adjust spawn chance
    {
        GameObject acorn = Instantiate(acornPrefab);

        // Randomize X position and set a fixed Y position (adjust as necessary)
        float randomX = Random.Range(-2f, 2f); // Adjust X-range based on your game
        float fixedY = 1f; // Set a fixed Y position for the acorn

        acorn.transform.position = new Vector3(transform.position.x + randomX, fixedY, transform.position.z);
    }

    Invoke(nameof(SpawnAcorn), Random.Range(minSpawnRate, maxSpawnRate));
}




}
