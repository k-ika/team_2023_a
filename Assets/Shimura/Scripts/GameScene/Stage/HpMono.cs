using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpMono : MonoBehaviour
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

    public void MonoDamage(float damage)
    {
        hp -= damage;

        Debug.Log("HPm:" + hp);
        
        if (hp < 0f)
        {
            GameSystem.GetComponent<Score>().PlusScore(score);
            Destroy(gameObject);
        }
    }
}
