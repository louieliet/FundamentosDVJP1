using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject player;
    public float speed;
    void Update()
    {
        Vector2 direction = player.transform.position - transform.position;
        if(direction.x >= 0.0f){
            transform.localScale = new Vector2(-5.0f, 5.0f);
            transform.Translate(Vector2.left * Time.deltaTime * speed);
        }
        else{
            transform.localScale = new Vector2(5.0f, 5.0f);
            transform.Translate(Vector2.right * Time.deltaTime * speed);
        }


    }
}
