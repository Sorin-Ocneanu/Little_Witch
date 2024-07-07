using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarPointScript : MonoBehaviour
{
    public LogicScript logic;
    public BoxCollider2D feet;

    private void Start()
    {
        if (logic == null) {
            logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();       
        }
        if (feet == null)
        {
            feet = GameObject.FindGameObjectWithTag("Player").GetComponent<BoxCollider2D>();
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 0 && feet.transform == collision.transform)
        {
            Destroy(gameObject);
            logic.addStar(1);

        }
    }
}
