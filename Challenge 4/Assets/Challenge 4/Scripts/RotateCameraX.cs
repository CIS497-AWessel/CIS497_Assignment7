/*
 * Anthony Wessel
 * Assignment 7 - Challenge 4
 * Rotates the camera based on player input
 */

using UnityEngine;

public class RotateCameraX : MonoBehaviour
{
    private float speed = 200;
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, horizontalInput * speed * Time.deltaTime);

        transform.position = player.transform.position; // Move focal point with player

    }
}
