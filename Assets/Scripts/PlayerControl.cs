using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float horizontal;
    public float vertical;
    public float speedX;
    public float speedY;
    public Rigidbody2D _compRigidbody2D;
    public GameObject bulletPrefab;
    public AudioSource _compAudioSource;
    public float BulletSpeed;
    private void Awake()
    {
        _compRigidbody2D = GetComponent<Rigidbody2D>();
     
    }
    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        if (Input.GetButtonDown("Fire1") == true)
        {
            Instantiate(bulletPrefab,transform.position ,transform .rotation );
            _compAudioSource.Play();
        }
    }
    private void FixedUpdate()
    {
        _compRigidbody2D.velocity = new Vector2(speedX * horizontal, speedY * vertical);
    }
}
