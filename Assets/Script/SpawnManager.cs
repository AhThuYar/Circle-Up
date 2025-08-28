using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] PlacePrefeb;
    public float YSpawn;
    public float PlaceLength = 7f;
    public int numberofPlace = 2;
    public Transform PlayerTransform;
    public float StartPoint = 10f;
    private static List<GameObject> ActivePlace = new List<GameObject>();
    private bool firstPlatformSpawned = false;

    void Start()
    {
        if (PlayerTransform == null)
        {
            PlayerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        }

        YSpawn = PlayerTransform.position.y + StartPoint;
        SpawnFirstPlatform();

        for (int i = 0; i < numberofPlace; i++)
        {
            SpawnPlatform();
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerTransform.position.y > YSpawn - (numberofPlace * PlaceLength))
        {
            SpawnPlatform();
            DeletePlace();
        }
    }

    void SpawnFirstPlatform()
    {
        if (PlacePrefeb.Length > 0 && PlacePrefeb[0] != null)
        {
            GameObject firstPlatform = Instantiate(PlacePrefeb[0], new Vector3(0, YSpawn, 0), Quaternion.identity);
            ActivePlace.Add(firstPlatform);
            YSpawn += GetPlatformHeight(firstPlatform) + PlaceLength;
            firstPlatformSpawned = true;
        }
    }

    void SpawnPlatform()
    {
        if (PlacePrefeb.Length <= 1) return;

        int randomIndex = Random.Range(1, PlacePrefeb.Length);
        GameObject platformPrefab = PlacePrefeb[randomIndex];

        Vector3 spawnPosition = new Vector3(0, YSpawn, 0);
        GameObject newPlatform = Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
        ActivePlace.Add(newPlatform);

        YSpawn += GetPlatformHeight(newPlatform) + PlaceLength;
    }

    float GetPlatformHeight(GameObject platform)
    {
        Collider collider = platform.GetComponent<Collider>();
        if (collider != null) return collider.bounds.size.y;

        Renderer renderer = platform.GetComponent<Renderer>();
        if (renderer != null) return renderer.bounds.size.y;

        return PlaceLength;
    }
    private void DeletePlace()
    {
        Destroy(ActivePlace[0]);
        ActivePlace.RemoveAt(0);
    }
}
