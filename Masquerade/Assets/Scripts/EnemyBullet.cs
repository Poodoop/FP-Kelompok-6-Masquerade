using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {

    private Player_Movement playerScript;
    private Vector2 targetPosition;

    public float speed;
    public int damage;

    private void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Movement>();
        targetPosition = playerScript.transform.position;
    }



    private void Update()
    {
         
        if (Vector2.Distance(transform.position, targetPosition) > .0001f)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        } else {
            Destroy(gameObject);
        }

    }


    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {
            playerScript.TakeDamage(damage);
            Destroy(gameObject);
        }
        else if (other.tag == "Wall")
        {
            Destroy(gameObject);
        }

    }

}