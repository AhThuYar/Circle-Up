using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] PlacePrefeb;
    public float YSpawn;
    public float PlaceLength;
    public int numberofPlace;
    public Transform PlayerTransform;
    private static List<GameObject> ActivePlace = new List<GameObject>();

    void Start()
    {
        for (int i = 0; i < numberofPlace; i++)
        {
            if (i == 0)
            {
                SpwanPlace(0);
            }
            else
            {
                SpwanPlace(Random.Range(0, PlacePrefeb.Length));
            }
        }
        PlayerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerTransform.position.y - 15 > YSpawn - (numberofPlace * PlaceLength))
        {
            SpwanPlace(Random.Range(0, PlacePrefeb.Length));
            DeletePlace();
        }
    }
    public void SpwanPlace(int PlaceIndex)
    {
        GameObject Place = Instantiate(PlacePrefeb[PlaceIndex], transform.up * YSpawn, transform.rotation);
        YSpawn += PlaceLength;
        ActivePlace.Add(Place);
    }
    private void DeletePlace()
    {
        Destroy(ActivePlace[0]);
        ActivePlace.RemoveAt(0);
    }
}
