using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    private Rigidbody2D rb2d;
    private int count;
    private int numCollectibles;

    public int speed;
    public Text countText;
    public Text winText;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        updateCount();
        numCollectibles = GameObject.FindGameObjectsWithTag("PickUp").Length;
        winText.text = "";
	}
	
	// Update is called once per frame
	void FixedUpdate() { 
        float horizontalMotion = Input.GetAxis("Horizontal");
        float verticalMotion = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontalMotion, verticalMotion);
        rb2d.AddForce(movement * speed);
        updateCount();
	}

    void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.collider.tag == "PickUp")
        {
            collision2D.collider.gameObject.SetActive(false);
            count++;
            if (count >= numCollectibles)
            {
                winText.text = "You Win!";
            }
        }
    }

    void updateCount()
    {
        countText.text = "Count: " + count.ToString();
    }
}
