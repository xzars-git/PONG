using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Control : MonoBehaviour
{
    // Tombol untuk menggerakan ke atas
    public KeyCode upButton = KeyCode.W;

    // Tombol untuk menggerakan ke bawah 
    public KeyCode downButton = KeyCode.S;

    // Kecepatan Gerak
    public float speed = 10.0f;

    // Batas atas dan bawah game scene (Batas Bawah Menggunakan Minus (-))
    public float yBoundary = 9.0f;

    // Rigidbody 2D Raket Ini
    private Rigidbody2D rigidbody2D;

    // Score Player
    private int score;

    // Menaikan Score Sebanyak 1 Poin
    public void IncermentScore()
    {
        score++;
    }

    // Mengembalikan skor menjadi 0
    public void ResetScore()
    {
        score = 0;
    }

    //Mendapatkan Nilai Score
    public int Score
    {
        get { return score; }
    }

    // Titik tumbukan terakhir dengan bola, untuk menampilkan variable - variable fisika terkait tumbukan tersebut
    private ContactPoint2D lastContactPoint;

    public ContactPoint2D LastContactPoint
    {
        get { return lastContactPoint; }
    }

    // Ketika terjadi tumbukan dengan bola, rekam titik kontaknya

    void OnCollisionEnter2D (Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Ball"))
        {
            lastContactPoint = collision.GetContact(0);
        }
    }

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        // Mendapatkan kecepatan raket sekarang.
        Vector2 velocity = rigidbody2D.velocity;

        // Jika pemain menekan tombol keatas, beri kecepatan positif ke komponen y (Ke Atas).
        if (Input.GetKey(upButton))
        {
            velocity.y = speed;
        }

        // Jika pemain menekan tombol ke bawah, beri kecepatan negatif ke komponen y (ke Bawah).
        else if (Input.GetKey(downButton))
        {
            velocity.y = -speed;
        }

        // Jika pemain tidak menekan tombol apa - apa, kecepatan nol
        else
        {
            velocity.y = 0.0f;
        }

        // Masukan kembali kecepatannya ke rigidBody2D.
        rigidbody2D.velocity = velocity;

        // Dapatkan posisi raket sekarang. 
        Vector3 position = transform.position;

        // Jika posisi raket melewati batas atas ( yBoundary), kembalikan ke batas atas tersebut.
        if (position.y > yBoundary)
        {
            position.y = yBoundary;
        }

        // Jika posisi raket melewati batas bawah (-yBoundary), kembalikan ke batas atas tersebut.
        else if (position.y < -yBoundary)
        {
            position.y = -yBoundary;
        }

        // Masukan kembali posisinya ke transform.
        transform.position = position;
    }
}
