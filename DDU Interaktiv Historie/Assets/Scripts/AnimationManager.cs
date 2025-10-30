using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    public List<Animator> ghostAnimations;
    public List<Animator> animations;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartAnimation(Random.Range(0, ghostAnimations.Count));
        }
    }

    public void StartAnimation(int nr)
    {
        ghostAnimations[nr].Play("Event");
    }
}
