using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Onclick_infin : MonoBehaviour {

	public int scene;
	public void Click()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene (scene);
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
