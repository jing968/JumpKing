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
    

    // Default camera height: 4.4
    // Increment depth: 


    void Start()
    {
        float diff = level * 11f;
        lowerBound = low + diff;
        upperBound = high + diff;
    }

    // Update is called once per frame
    void Update() 
    {
        manageCamera();
    }

    void manageCamera(){
        GameManager gm = GameManager.gm;
        
        if (gm.gameState == GameManager.GameStates.Learn) {
            // If LEARNING, manaually update camera position according to keyboard inputs
            
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
