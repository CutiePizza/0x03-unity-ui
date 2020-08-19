﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private int score;
    public float speed;
    public Rigidbody rb;
    public int health;
    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
       score = 0;
       health = 5;
    }

    void FixedUpdate()
    {
    
     if (Input.GetKey("d") || Input.GetKey("right"))
     {
        rb.AddForce(speed * Time.deltaTime, 0, 0);
     }

     if (Input.GetKey("a") || Input.GetKey("left"))
     {
        rb.AddForce(-speed * Time.deltaTime, 0, 0);
     }

     if (Input.GetKey("s") || Input.GetKey("down"))
     {
        rb.AddForce(0, 0, -speed * Time.deltaTime);
     }

     if (Input.GetKey("w") || Input.GetKey("up"))
     {
        rb.AddForce(0, 0, speed * Time.deltaTime);
     }     
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0)
        {
           Debug.Log("Game Over!");
           SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex,LoadSceneMode.Single);

        }
    }
   void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }
    void OnTriggerEnter(Collider other)
    {
       if (other.gameObject.tag == "Pickup")
       {
          score++;
          Destroy(other.gameObject);
          SetScoreText();
         // Debug.Log($"Score: {score}");
       }
       if (other.gameObject.tag == "Trap")
       {
          health--;
          Debug.Log($"Health {health}");
       }

       if (other.gameObject.tag == "Goal")
       {
          Debug.Log("You win!");
       }
    }

}
