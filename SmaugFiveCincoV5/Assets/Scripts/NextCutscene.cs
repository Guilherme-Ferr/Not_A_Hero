using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextCutscene : MonoBehaviour
{
    private Animator anim;

    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            anim = GetComponent<Animator>();
            anim.Play("CeneOneDefault");
        }
    }

    public void GoToPrison()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
