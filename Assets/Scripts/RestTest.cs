using UnityEngine;
using System.Collections;

public class RestTest : MonoBehaviour {
	/*
	 * https://github.com/andyburke/UnityHTTP
	 */

	private static string URL = "http://api.openweathermap.org/data/2.5/weather?q=London,uk";

	// Use this for initialization
	void Start () {
		StartCoroutine(SomeRoutine());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public IEnumerator SomeRoutine() {
		Debug.Log ("Test");
		HTTP.Request someRequest = new HTTP.Request( "get", URL);
		someRequest.Send();
		
		while( !someRequest.isDone )
		{
			yield return null;
		}
		Hashtable table = someRequest.response.Object;
		// parse some JSON, for example:
		Debug.Log (table.ContainsKey("base"));
		Debug.Log ((string)table["base"]);
	}
}
