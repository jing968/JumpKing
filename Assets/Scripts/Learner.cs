using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Learner : MonoBehaviour
{
    [Serializable]
    public class jumpRecord {
        public float movement;
        public float jumpValue;
    }
    public GameObject playerObj;
    public GameObject playerPrefab;
    public GameObject playerContainer;
    private Vector3 spawnPos;
    public goodJumpRecorder recorder;
    public List<jumpRecord> jumpRecords;
    // Record class for the action
    

    // Start is called before the first frame update
    void Start()
    {
        // Initialize jump records arraylist
        jumpRecords = new List<jumpRecord>();

        // Storing initial player postion to players
        spawnPos = playerObj.transform.position;

        // Wipe recorder for a fresh start
        recorder.wipeRecord();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.H)) {
            spawnAndJump(1);
        }
    }

    void Learn() {

    }

    void spawnAndJump(int numPlayers){
        GameObject newPlayer = Instantiate(playerPrefab, spawnPos, new Quaternion(), playerContainer.transform);
        Player playerController = newPlayer.GetComponent<Player>();
        playerController.randomJump();
    }

    public void saveJumpInfo(float movement, float jumpValue){
        jumpRecord newRecord = new jumpRecord();
        newRecord.movement = movement;
        newRecord.jumpValue = jumpValue;
        jumpRecords.Add(newRecord);
        recorder.addRecord(newRecord);
    }

    public void updateSpawnPos(Vector3 newPosition){
        spawnPos = newPosition;
    }
}
