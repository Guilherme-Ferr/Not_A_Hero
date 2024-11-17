using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardLimits : MonoBehaviour
{
    public EnemyController enemyController;

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            enemyController.playerInActionArea = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            enemyController.playerInActionArea = false;
            enemyController.data.aggro = false;
        }
    }
}
