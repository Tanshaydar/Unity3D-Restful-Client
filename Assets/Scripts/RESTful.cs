using UnityEngine;
using System.Collections;

public class RESTful : MonoBehaviour {

	private string URL;
	private string API;
	private Device device;

	void Awake() {
		URL = "http://localhost:80/zaman";
		API = URL + "/api/";
		device = new Device ();
	}

	// Use this for initialization
	void Start () {
		checkDevice ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public bool checkDevice(){
		HTTP.Request checkDevice = new HTTP.Request("get", API + "device/123sdgas64");
		checkDevice.Send( (request) => {
			Debug.Log(request.response.Text);
		});
		return false;
	}
}
