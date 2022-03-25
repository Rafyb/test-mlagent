using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab = null;
    public Transform spawn = null; 
    public float minTime = 1.0f;
    public float maxTime = 3.0f;

    public MLPlayer player;
    
    private void Start()
    {
        Invoke("SpawnObstacle", Random.Range(minTime, maxTime));
    }
    private void SpawnObstacle()
    {
        GameObject go = Instantiate(prefab);
        go.transform.position = new Vector3(spawn.position.x, spawn.position.y, spawn.position.z);
        go.GetComponent<Obstacle>().player = player;
        Invoke("SpawnObstacle", Random.Range(minTime, maxTime));
    }
}