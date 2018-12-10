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
		Debug.Log("Hello World!");
		rb = GetComponent<Rigidbody>();
		count = 0;
		SetCountText ();
		winText.text = "";
	}

	void Update () 
	{
		SetTimeText ();
		if (Input.GetKeyDown(KeyCode.R))
        {
            GetComponent<Renderer> ().material.color = Color.red;
        }
		if (Input.GetKeyDown(KeyCode.G))
        {
            GetComponent<Renderer> ().material.color = Color.green;
        }
		if (Input.GetKeyDown(KeyCode.B))
        {
            GetComponent<Renderer> ().material.color = Color.blue;
        }
		if (Input.GetKeyDown(KeyCode.L))
        {
            GetComponent<Renderer> ().material.color = Color.black;
        }
		if (Input.GetKeyDown(KeyCode.W))
        {
            GetComponent<Renderer> ().material.color = Color.white;
        }
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
		if (count >= 13) 
		{
			winText.text = "You Win!";
		}
	}

	void SetTimeText ()
	{
		timeLeft -= Time.deltaTime;
		timeText.text = "Time: " + timeLeft.ToString("0");
		if (timeLeft < 0)
		{
			timeText.text = "Game Over";
		}
	}
}
