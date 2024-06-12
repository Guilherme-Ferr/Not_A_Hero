using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NPC : MonoBehaviour
{

    public float speed;
    private float initialSpeed;
    private int index;

    private Animator anim;

    public List<Transform> paths = new List<Transform>();


    private void Start()
    {
        initialSpeed = speed;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Vector2 direction = paths[index].position - transform.position;

        if (DialogueControl.instance.isShowing)
        {
            if (direction.x > 0)
            {
                transform.eulerAngles = new Vector2(0, 0);
                speed = 0f;
                anim.SetBool("isWalking", false);
                anim.SetInteger("transition", 1);
            }
            else if (direction.x < 0)
            {
                transform.eulerAngles = new Vector2(0, 180);
                speed = 0f;
                anim.SetBool("isWalking", false);
                anim.SetInteger("transition", 1);
            }

        }
        else
        {
            speed = initialSpeed;
            anim.SetInteger("transition", 0);
            anim.SetBool("isWalking", true);
        }


        transform.position = Vector2.MoveTowards(transform.position, paths[index].position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, paths[index].position) < 0.001f)
        {
            if (index < paths.Count - 1)
            {
                index++;
            }
            else
            {
                index = 0;
            }
        }


        if (direction.x > 0)
        {
            transform.eulerAngles = new Vector2(0, 0);
        }
        else if (direction.x < 0)
        {
            transform.eulerAngles = new Vector2(0, 180);
        }
    }
}
