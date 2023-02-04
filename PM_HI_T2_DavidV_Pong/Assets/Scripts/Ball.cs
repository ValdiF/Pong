using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float initialVelocity = 4f;
    [SerializeField] private float velocityMultiplier = 1.1f;
    private Rigidbody ballRb;
    public AudioClip hitSound;
    public AudioClip fail;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        ballRb = GetComponent<Rigidbody>();
        Launch();
    }

    void Launch()
    {
        float xVelocity = Random.Range(0, 2) == 0 ? 1 : -1;
        float yVelocity = Random.Range(0, 2) == 0 ? 1 : -1;
        ballRb.velocity = new Vector2(xVelocity, yVelocity) * initialVelocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ballRb.velocity *= velocityMultiplier;
        }

        if (collision.gameObject.CompareTag("BORDERS"))
        {
            ballRb.velocity *= velocityMultiplier;
        }
        audioSource.PlayOneShot(hitSound);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Limit2"))
        {
            GameManager.Instance.Player1Scored();
        }
        else
        {
            GameManager.Instance.Player2Scored();
        }
        audioSource.PlayOneShot(fail);
        GameManager.Instance.Restart();
        Launch();
    }
   
}
