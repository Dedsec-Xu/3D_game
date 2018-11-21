using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float jumpspeed;
	public float jumprelatetocount;
	public float speed;
	public float step;
	public float sizeforce;
	public float camerastep;
	public float level2;
	public float level3;
	public float towin;
	public float inispeed;

	public Text countText;
	public Text winText;
	public GameObject player;
	public GameObject Camera;

	private Rigidbody rb;
	private int count;
	private int decount;
	private float prev;
	private float level1;
	private float camex;
	private float camey;
	private float camez;
	private Vector3 turnback;
	private Vector3 Camerswift;



	void Start ()
	{
		rb = GetComponent<Rigidbody>();
		Vector3 inimovement = new Vector3 (1, 0.0f, 1);
		rb.AddForce (inimovement * inispeed);
		count = 0;
		SetCountText ();
		winText.text = "Eat more & Jump higher";
		level1 = player.transform.localScale.x;
		turnback = Camera.transform.position - player.transform.position;
	}

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		float Jump = Input.GetAxis ("Jump");
		float multi = 1 + sizeforce * count;

		if (transform.position.y - transform.localScale.y / 2 < 0.5)
			{
			Vector3 upmovement = new Vector3 (0.0f, (Jump * (jumpspeed + (float)0.5 * count * jumprelatetocount)), 0.0f);
		rb.AddForce (upmovement * multi);
			}
		Vector3 movement = new Vector3 (moveHorizontal * speed, 0.0f, moveVertical * speed);

		rb.AddForce (movement * multi);
		if (player.transform.position.y > level1 / 2 - 0.1)
		{
			Seteat ();
		}
		if (player.transform.position.y < level1 / 2 - 0.1 && player.transform.position.y > level2) 
		{
			Setcareful();
		}
		if (player.transform.position.y < level2 && player.transform.position.y > level3)
		{
			Setlosing();
		}
		if (player.transform.position.y < level3) 
		{
			Setlost();
			SetCountText ();
		}

		Camerswift = new Vector3 (0, (float)count, - (float)count);
	}

	void LateUpdate ()
	{
		Camera.transform.position = player.transform.position + turnback + Camerswift * camerastep;
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("Pick Up"))
		{
			other.gameObject.SetActive (false);
			count = count + 1;
			prev = player.transform.localScale.x;
			player.transform.localScale = new Vector3 (prev + step, prev + step, prev + step);
			level1 = player.transform.localScale.x;
			SetCountText ();
		}

			
	}


	void SetCountText ()
	{
		if (count >= towin) 
		{
			winText.text = "You Win!";
		}
		if (player.transform.position.y < level3) {
			countText.text = "Count: " + decount.ToString ();
			decount = decount - 13;
		} 
		else 
		{
			countText.text = "Count: " + count.ToString ();
			decount = count;
		}
	}

	void Setlost()
	{
		winText.text = "You Lose!";
	}
	void Seteat()
	{
		if (count >= towin) 
		{
			winText.text = "You Win!";
		}
		if (count < towin) 
		{
			winText.text = "Eat more & Jump higher";
		}
	}

	void Setcareful()
	{
		if (count >= towin) 
		{
			winText.text = "You Win!";
		}
		else
		{
			winText.text = "Be careful!";
		}
	}

	void Setlosing()
	{
		winText.text = "What a shame...";
	}
}