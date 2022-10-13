using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Learner : MonoBehaviour
{
    public GameObject playerObj;
    public GameObject playerPrefab;
    private Rigidbody2D playerRB;
    private Player playerController;
    private Vector3 playerPos;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = playerObj.GetComponent<Rigidbody2D>();
        playerController = playerObj.GetComponent<Player>();

        // Storing initial player postion to players
        playerPos = playerObj.transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.H)) {
            // randomJump();
        }
    }

    void Learn() {

    }

    void spawnAndJump(int numPlayers){

    }



    void test(){
        float currentPos = playerObj.transform.position.y;
        print("Current y: " + Mathf.Round(currentPos * 100.0f) * 0.1f);
    }


    bool validateJump() {

        return true;
    }
}
