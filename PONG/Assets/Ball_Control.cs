﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Control : MonoBehaviour
{

    // Rigid 2D Bola
    private Rigidbody2D rigidBody2D;

    // Besarnya gaya awal yang diberikan untuk mendorong bola
    public float xInitialForce;
    public float yInitialForce;

    public float speed = 100;

    // Titik asal lintasan bola saat ini
    private Vector2 trajectoryOrigin;

    void ResetBall()
    {
        // Reset Posisi menjadi (0, 0)
        transform.position = Vector2.zero;

        // Reset Kecepatan menjadi (0, 0)
        rigidBody2D.velocity = Vector2.zero;
    }

    void PushBall()
    {
        // Tentukan nilai komponen y dari gaya dorong antara -yInitialForce dan yInitialForce
        float y = Random.Range(-yInitialForce, yInitialForce);

        float x = Mathf.Sqrt(speed * speed - y * y);

        // Tentukan nilai acak antara 0 (inklusif) dan 2 (eksklusif)
        float randomDirection = Random.Range(0, 2);

        // Jika nilainya dibawah 1, bola bergerak ke kiri
        // Jika tidak, bola bergerak ke kanan.
        if(randomDirection < 1.0f)
        {
            // Gunakan gaya untuk menggerakan bola ini.
            rigidBody2D.AddForce(new Vector2(-x, y));
        }
        else
        {
            rigidBody2D.AddForce(new Vector2(x, y));
        }
    }

    void RestartGame()
    {
        // Kembalikan bola ke posisi semula
        ResetBall();

        // Setelah 2 detik, berikan gaya ke bola
        Invoke("PushBall", 2);
       
    }

    // Ketika bola beranjak dari sebuah tumbukan, rekam titik tumbukan tersebut
    private void OnCollisionExit2D(Collision2D collision)
    {
        trajectoryOrigin = transform.position;
    }

    // Untuk mengakses informasi titik asal lintasan

    public Vector2 TrajectoryOrigin
    {
        get { return trajectoryOrigin; }
    }

    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        // Mulai Game
        RestartGame();
        trajectoryOrigin = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
