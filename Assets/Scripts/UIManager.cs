using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public Image[] lives;
    
    public void UpdateLives(int currentLives) {
        for (int i = 0; i < lives.Length; i++) {
            lives[i].color = currentLives > i ? Color.white : Color.black;
        }
    }
}
