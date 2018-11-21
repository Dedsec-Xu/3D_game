using UnityEngine;
using System.Collections;

public class Camera_Controller : MonoBehaviour {

	public GameObject player;

	private Vector3 turnback;

	void Start ()
	{
		turnback = transform.position - player.transform.position;
	}

	void LateUpdate ()
	{
		transform.position = player.transform.position + turnback;
	}
}