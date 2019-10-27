using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rd2d;

    public float speed;
    public Text loseText;
    public Text score;
    public Text winText;
    private int scoreValue = 0;
    public Text liveText;
    private int liveValue;
    public GameObject enemy;
    public GameObject player;
    public AudioClip musicClipOne;

public AudioClip musicClipTwo;

public AudioSource musicSource;

    // Start is called before the first frame update
    void Start()
    {
        rd2d = GetComponent<Rigidbody2D>();
        score.text = scoreValue.ToString();
          winText.text = "";
        liveValue = 3;
       loseText.text ="";
        SetscoreValueText();
    }

    // Update is called once per frame
    void FixedUpdate()
    { 
        float hozMovement = Input.GetAxis("Horizontal");
        float vertMovement = Input.GetAxis("Vertical");
        rd2d.AddForce(new Vector2(hozMovement * speed, vertMovement * speed));
        if (Input.GetKey("escape"))
     Application.Quit();
    
      
    }
     


    private void OnCollisionEnter2D(Collision2D collision)
    {
       
           
       
        if (liveValue <= 0)
        
         
            Destroy(player);
            if (liveValue <= 0)
        loseText.text = "You Lose";
    
       if (collision.collider.tag == "Coin")
        {
            scoreValue += 1;
            score.text = scoreValue.ToString();
            Destroy(collision.collider.gameObject);
             SetscoreValueText();
        }
        if (collision.collider.tag == "Final Coin")
        {
            scoreValue += 1;
            score.text = scoreValue.ToString();
            Destroy(collision.collider.gameObject);
             SetscoreValueText();
        }
        if (collision.collider.tag== "enemy")
        {liveValue = liveValue - 1;
        liveText.text = liveValue.ToString();
        Destroy(collision.collider.gameObject);
        }
        
    
    }
      void SetscoreValueText()
      {
           if (scoreValue==0)
        {
          musicSource.clip = musicClipOne;
          musicSource.Play();
        }
          if(scoreValue==8)
       {
           musicSource.Stop();
       }
       if(scoreValue==8)
       {
           musicSource.clip =musicClipTwo;
           musicSource.Play();
       }
             if (scoreValue == 4)
           {
             
              liveValue = 3;
           }
              if (scoreValue == 4)
             transform.position = new Vector2(-5.34f, -11.04f);
             
             if (scoreValue == 8)
            winText.text = "You win! Game created by Daniel Vanderbrink";
         
            }
      

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                rd2d.AddForce(new Vector2(0, 3), ForceMode2D.Impulse);
            }
        }
    }
}
