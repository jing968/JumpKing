using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "good jump recorder", menuName = "JumpKing/Good Jump Recorder"), System.Serializable]
public class goodJumpRecorder : ScriptableObject
{
    public List<Learner.jumpRecord> jumpRecords = new List<Learner.jumpRecord>();
    public void addRecord(Learner.jumpRecord record) {
        jumpRecords.Add(record);
    }

    public void wipeRecord() {
        jumpRecords.Clear();
    }

    public List<Learner.jumpRecord> getRecords() {
        return jumpRecords;
    }
}
