using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {

	//public GameObject player;
	//private float temp;
	public float x;
	public float y;
	public float z;

	void Update () 
	{
		//temp = player.transform.localScale.x;
		//transform.localScale = new Vector3 (temp / 2, temp / 2, temp / 2); 
		transform.Rotate (new Vector3 (x, y, z) * Time.deltaTime);
	}
}