using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideWall : MonoBehaviour
{
    // Pemain yang akan bertambah skornya jika bola menyentuh dinding in
    public Player_Control player;

    [SerializeField]
    private GameManager gameManager;

    // Alam dipanggil ketikan objek lain ber-collider (bola) bersentuhan dengan dinding
    void OnTriggerEnter2D(Collider2D anotherCollider)
    {
        // Jika objek tersebut bernama "Ball":
        if (anotherCollider.name == "Ball")
        {
            // Tambahkan skor ke pemain
            player.IncermentScore();

            // Jika skor pemain belum mencapai skor maksimal...
          if(player.Score < gameManager.maxScore)
          {
                //...Start game setelah bola mengenai dinding.
              anotherCollider.gameObject.SendMessage("RestartGame", 2.0f, SendMessageOptions.RequireReceiver);
          }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
