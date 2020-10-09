using UnityEngine;

public class Track : MonoBehaviour {

    private float endPosition = 314f;

    void Start() {
        
    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            transform.position = new Vector3(0, 0, transform.position.z + endPosition * 2);
        }
    }

}
