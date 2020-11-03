/*
 * Anthony Wessel
 * Assignment 7 - Prototype 4
 * Takes in player input and controls the player
 */

using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 1;
    float forwardInput;

    bool hasPowerup;
    float powerupStrength = 15f;

    public GameObject powerupIndicator;

    private Transform focalPoint;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        focalPoint = GameObject.FindGameObjectWithTag("FocalPoint").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.gameInProgress) return;

        forwardInput = Input.GetAxis("Vertical");
        powerupIndicator.transform.position = transform.position + Vector3.down * 0.5f;

        if (transform.position.y < -10) GameManager.Lose();
    }

    private void FixedUpdate()
    {
        rb.AddForce(focalPoint.forward * speed * forwardInput);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
            powerupIndicator.gameObject.SetActive(true);
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        powerupIndicator.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (hasPowerup && collision.collider.CompareTag("Enemy"))
        {
            Rigidbody enemyRB = collision.rigidbody;

            Vector3 awayFromPlayer = (enemyRB.transform.position-transform.position).normalized;
            enemyRB.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
        }
    }
}
