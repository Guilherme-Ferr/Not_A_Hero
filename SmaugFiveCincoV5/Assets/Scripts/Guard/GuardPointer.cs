using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardPointer : MonoBehaviour
{
    public EnemyController enemyController;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Guard"))
        {
            enemyController.movingRight = !enemyController.movingRight;

            if (enemyController.data.facingSide == GuardData.FacingSide.right)
            {
                enemyController.data.facingSide = GuardData.FacingSide.left;
            }
            else
            {
                enemyController.data.facingSide = GuardData.FacingSide.right;
            }
        }
    }
}
