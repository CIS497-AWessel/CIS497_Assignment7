/*
 * Anthony Wessel
 * Assignment 7 - Prototype 4
 * Chases the player
 */

using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    Rigidbody rb;
    Transform player;
    public float speed = 3;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 lookDirection = (player.position - transform.position).normalized;

        rb.AddForce(lookDirection * speed);

        if (transform.position.y < -10)
            Destroy(gameObject);
    }
}
