using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public bool gameOver;
    private bool _isLowEnough = true;
    private float _topBound;
    public float floatForce;
    private float gravityModifier = 1.5f;
    private Rigidbody _playerRb;
    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;
    private AudioSource _playerAudio;
    public AudioClip moneySound;
    public AudioClip explodeSound;
    // Start is called before the first frame update
    void Start()
    {
        _playerRb = GetComponent<Rigidbody>();
        _playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
        // Apply a small upward force at the start of the game
        _playerRb.AddForce(Vector3.up * 5, ForceMode.Impulse);
        _topBound = GameObject.Find("Background").GetComponent<BoxCollider>().size.y * 0.9f;
    }
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y >_topBound)
        {
            _isLowEnough = false;
            _playerRb.AddForce(Vector3.up * floatForce * -0.5f);
        }
        else
        {
            _isLowEnough = true;
        }
        // While space is pressed and player is low enough, float up
        if (Input.GetKeyDown(KeyCode.Space) && !gameOver && _isLowEnough)
        {
            _playerRb.AddForce(Vector3.up * floatForce);
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        // if player collides with bomb, explode and set gameOver to true
        if (other.gameObject.CompareTag("Bomb"))
        {
            explosionParticle.Play();
            _playerAudio.PlayOneShot(explodeSound, 1.0f);
            gameOver = true;
            Debug.Log("Game Over!");
            Destroy(other.gameObject);
        } 
        // if player collides with money, fireworks
        else if (other.gameObject.CompareTag("Money"))
        {
            fireworksParticle.Play();
            _playerAudio.PlayOneShot(moneySound, 1.0f);
            Destroy(other.gameObject);

        }
        else if (other.gameObject.CompareTag("Ground"))
        {
            _playerRb.AddForce(Vector3.up * floatForce * 2);
        }
    }
}