using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpYuubakubutu : MonoBehaviour
{
   [SerializeField] float hp = 80;

    [SerializeField] GameObject GameSystem;

    [SerializeField] int score;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void YuubakubutuDamage(float damage)
    {
        hp -= damage;

        Debug.Log("HPy:" + hp);
        
        if (hp < 0f)
        {
            GameSystem.GetComponent<Score>().PlusScore(score);
            Destroy(gameObject);
        }
    }
}
