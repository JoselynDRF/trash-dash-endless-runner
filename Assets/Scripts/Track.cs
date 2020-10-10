using System.Collections.Generic;
using UnityEngine;

public class Track : MonoBehaviour {

    public GameObject coin;
    public GameObject[] obstacles;
    public Vector2 coinsNumber;
    public Vector2 obstaclesNumber;

    private float trackEndPosition = 314f;

    void Start() {
        CreateCoins();
        CreateObstacles();
    }

    void CreateCoins() {
        CreateTrackItems(coinsNumber, coin);
    }

    void CreateObstacles() {
        GameObject obstacle = obstacles[Random.Range(0, obstacles.Length)];
        CreateTrackItems(obstaclesNumber, obstacle);
    }

    void CreateTrackItems(Vector2 itemsNumber, GameObject item) {
        List<GameObject> itemsList = new List<GameObject>();
        int newItemsNumber = (int) Random.Range(itemsNumber.x, itemsNumber.y);

        for (int i = 0; i < newItemsNumber; i++) {
            float itemPosition = (trackEndPosition / newItemsNumber) + (trackEndPosition / newItemsNumber) * i;
            float randomPosition = Random.Range(itemPosition, itemPosition + 1);

            itemsList.Add(Instantiate(item, transform));
            itemsList[i].transform.localPosition = new Vector3(transform.position.x, transform.position.y, randomPosition);

            if (itemsList[i].GetComponent<ChangeLane>() != null) {
                itemsList[i].GetComponent<ChangeLane>().PositionLane();
            }
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            other.GetComponent<Player>().IncreaseSpeed();
            transform.position = new Vector3(0, 0, transform.position.z + trackEndPosition * 2);
        }
    }
}
