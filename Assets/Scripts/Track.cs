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
        List<GameObject> cointsList = new List<GameObject>();
        int newCoinsNumber = (int) Random.Range(coinsNumber.x, coinsNumber.y);

        for (int i = 0; i < newCoinsNumber; i++) {
            float coinPosition = (trackEndPosition / newCoinsNumber) + (trackEndPosition / newCoinsNumber) * i;
            float minPosition = coinPosition + 15f;
            float maxPosition = coinPosition + 1;
            float randomPosition = Random.Range(minPosition, maxPosition);

            cointsList.Add(Instantiate(coin, transform));
            cointsList[i].transform.localPosition = new Vector3(transform.position.x, transform.position.y, randomPosition);

            cointsList[i].GetComponent<ChangeLane>().PositionLane();
        }
    }

    void CreateObstacles() {
        List<GameObject> obstaclesList = new List<GameObject>();
        int newObstaclesNumber = (int) Random.Range(obstaclesNumber.x, obstaclesNumber.y);

        for (int i = 0; i < newObstaclesNumber; i++) {
            float obstaclePosition = (trackEndPosition / newObstaclesNumber) + (trackEndPosition / newObstaclesNumber) * i;
            float minPosition = obstaclePosition + 20f;
            float maxPosition = obstaclePosition + 1;
            float randomPosition = Random.Range(minPosition, maxPosition);

            obstaclesList.Add(Instantiate(obstacles[Random.Range(0, obstacles.Length)], transform));
            obstaclesList[i].transform.localPosition = new Vector3(transform.position.x, transform.position.y, randomPosition);
            minPosition = randomPosition + 1;

            if (obstaclesList[i].GetComponent<ChangeLane>() != null) {
                obstaclesList[i].GetComponent<ChangeLane>().PositionLane();
            }
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            transform.position = new Vector3(0, 0, transform.position.z + trackEndPosition * 2);
        }
    }
}
