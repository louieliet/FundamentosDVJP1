using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject player;
    public float speed;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    private void Start()
    {
        Vector2 direction = player.transform.position - transform.position;
        if(direction.x >= 0.0f){
            transform.localScale = new Vector2(3.2f, 3.2f);
        }
        else{
            transform.localScale = new Vector2(-3.2f, 3.2f);
        }
        
    }

    void Update()
    {
        transform.Translate(Mathf.Sign(transform.localScale.x) *
            Vector2.right * Time.deltaTime * speed);

        if(transform.position.x >= 10.0f || transform.position.x <= -20.0f){
            Destroy(gameObject);
        }
    }
}
