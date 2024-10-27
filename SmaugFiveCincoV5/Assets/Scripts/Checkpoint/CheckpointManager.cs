using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public Vector3 savedPosition;
    public PlayerData savedState;
    public bool checkpointReached = false;

    public void SaveCheckpoint(PlayerData state)
    {
        savedPosition = state.transform.position;
        savedState = state;
        checkpointReached = true;
    }
}