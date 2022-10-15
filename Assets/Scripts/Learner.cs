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
    public int numLearner;
    private Vector3 spawnPos;
    public goodJumpRecorder recorder;
    public float waitTimeBetweenJumps;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake() {
        print(recorder.getRecords().Count);
        GameManager gm = GameManager.gm;
        if (gm != null) {
            // Set up reference
            gm.learner = this;

            // Configurations for LEARNING
            if (gm.gameState == GameManager.GameStates.Learn) {
                // Storing initial player postion to players
                spawnPos = playerObj.transform.position;

                // Remover THE player
                Destroy(playerObj);

                // Wipe recorder for a fresh start
                recorder.wipeRecord();

            }

        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    ///////////////////////////////////////////
    // Learning related functions
    public void Learn() {
        spawnAndJump(numLearner);
    }

    void spawnAndJump(int numPlayers){
        for (int i = 0; i < numPlayers; i++){
            GameObject newPlayer = Instantiate(playerPrefab, spawnPos, new Quaternion(), playerContainer.transform);
            Player playerController = newPlayer.GetComponent<Player>();
            playerController.randomJump();
        }
    }

    public void saveJumpInfo(float movement, float jumpValue){
        jumpRecord newRecord = new jumpRecord();
        newRecord.movement = movement;
        newRecord.jumpValue = jumpValue;
        recorder.addRecord(newRecord);
    }

    public void updateSpawnPos(Vector3 newPosition){
        spawnPos = newPosition;
    }

    ///////////////////////////////////////////
    // Testing related functions
    public void reproduceGoodJumps() {
        if (GameManager.gm.gameState != GameManager.GameStates.Test) return;
        IEnumerator coroutine = reproduceGoodJump(0);
        StartCoroutine(coroutine);
    }

    IEnumerator reproduceGoodJump(int jumpIndex) {
        List<jumpRecord> records = recorder.getRecords();
        // Only reproduce if jumpIndex is within reasonable range
        if (jumpIndex < records.Count) {
            Player playerController = playerObj.GetComponent<Player>();
            float movement = records[jumpIndex].movement;
            float jumpValue = records[jumpIndex].jumpValue;
            // Trigger jump
            playerController.triggerJump(movement, jumpValue);
            // Wait for the jump to be finalised
            yield return new WaitForSeconds(waitTimeBetweenJumps);
            // Trigger next jump
            IEnumerator coroutine = reproduceGoodJump(jumpIndex + 1);
            StartCoroutine(coroutine);
        }
    }
}
