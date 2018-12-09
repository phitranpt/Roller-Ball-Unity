using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public float speed;
	public Text countText;
	public Text winText;
	public float timeLeft = 10.0f;
	public Text timeText;
	private Rigidbody rb;
	private int count;

	// Use this for initialization
	void Start () 
	{
		rb = GetComponent<Rigidbody>();
		count = 0;
		SetCountText ();
		winText.text = "";
	}

	void Update () 
	{
		SetTimeText ();
	}

	// This is where our physics code will go
	void FixedUpdate () 
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed);
	}

	//Will deactive the object on contact and increment score +1
	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag("Pick Up")) 
		{
			other.gameObject.SetActive(false);
			count += 1;
			SetCountText ();
		}
	}

	//Display a win text if all cubes are collected
	void SetCountText () 
	{
		countText.text = "Count: " + count.ToString();
		if (count >= 12) 
		{
			winText.text = "You Win!";
		}
	}

	void SetTimeText ()
	{
		timeLeft -= Time.deltaTime;
		timeText.text = (timeLeft).ToString("0");
		if (timeLeft < 0)
		{
			timeText.text = "Game Over";
		}
	}
}
