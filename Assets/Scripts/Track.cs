using System.Collections.Generic;
using UnityEngine;

public class Track : MonoBehaviour {

    public GameObject coin;
    public Vector2 coinsNumber;

    private float trackEndPosition = 314f;

    void Start() {
        CreateCoins();
    }

    void CreateCoins() {
        List<GameObject> cointsList = new List<GameObject>();
        int newCoinsNumber = (int) Random.Range(coinsNumber.x, coinsNumber.y);
        float minPosition = 10f;

        for (int i = 0; i < newCoinsNumber; i++) {
            float maxPosition = minPosition + 8f;
            float randomPosition = Random.Range(minPosition, maxPosition);

            cointsList.Add(Instantiate(coin, transform));
            cointsList[i].transform.localPosition = new Vector3(transform.position.x, transform.position.y, randomPosition);
            minPosition = randomPosition + 1;
            PositionLane(cointsList[i]);
        }
    }

    void PositionLane(GameObject coint) {
        int randomLane = Random.Range(-1, 2);
        coint.transform.position = new Vector3(randomLane, coint.transform.position.y, coint.transform.position.z);
    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            transform.position = new Vector3(0, 0, transform.position.z + trackEndPosition * 2);
        }
    }
}
