using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracker : MonoBehaviour
{
    // Hardcoded values that reflects how the map is configured 
    // DO NOT CHANGE THESE
    private float low = -0.6f;
    private float high = 9.4f;
    

    public GameObject camera;
    public GameObject player;
    public float level;
    private float lowerBound, upperBound;
    

    public Learner learner;

    // Default camera height: 4.4
    // Increment depth: 


    void Start()
    {
        float diff = level * 11f;
        lowerBound = low + diff;
        upperBound = high + diff;
        print(GameManager.gm.gameState);
    }

    // Update is called once per frame
    void Update() 
    {
        manageCamera();
    }

    void manageCamera(){
        GameManager gm = GameManager.gm;
        
        if (gm.gameState == GameManager.GameStates.Learn) {
            // If LEARNING, update camera position according to spawn position
            float posY = learner.spawnPos.y;
            if (lowerBound <= posY && posY < upperBound) {
                // Move camera accordingly
                float newY = 4.4f + (level * 11);
                camera.transform.position = new Vector3(camera.transform.position.x, newY, -10);
            }
        } else {
            // If PLAYING || TESTING, update camera according to player position
            float playerY = player.transform.position.y;
            if (lowerBound <= playerY && playerY < upperBound) {
                // Move camera accordingly
                float newY = 4.4f + (level * 11);
                camera.transform.position = new Vector3(camera.transform.position.x, newY, -10);
            }
        }
    }
}
