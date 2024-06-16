using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextCutscene : MonoBehaviour
{
    private Animator anim;

    void Start()
    {
        Debug.Log(SceneManager.GetActiveScene().buildIndex);
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            anim = GetComponent<Animator>();
            anim.Play("CeneTwo");
        }
    }

    public void GoToPrison()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
