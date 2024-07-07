using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementScript : MonoBehaviour
{
    public Transform[] transformers;
    private Transform targetTransformer;
    private int transformed_id;
    public float speed;
    private int stunSeconds;


    private void Start()
    {
        targetTransformer = transformers[0];
    }
    void Update()
    {
        if (stunSeconds <= 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetTransformer.position, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, targetTransformer.position) < 0.1f)
            {
                pickNextTransformer();
            }
        }
        else {
            stunSeconds -= (1 * Convert.ToInt16(Time.deltaTime));
        }
        
    }


    private Transform pickNextTransformer()
    {
        transformed_id++;
        if (transformed_id > transformers.Length) {
            transformed_id = 0;
        }
        return transformers[transformed_id];
    }

    public void setStunnedSeconds(int value)
    {
        this.stunSeconds = value;
    }

}
