using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleAnimation : MonoBehaviour
{
    [SerializeField] GameObject Title;
    void Start()
    {
        InvokeRepeating("AnimationTitle", 0, 1.0f);
        InvokeRepeating("Animation", 0.5f, 1.0f);
    }

    void AnimationTitle()
    {
        Title.SetActive(false);

    }
    void Animation()
    {
        Title.SetActive(true);

    }
}
