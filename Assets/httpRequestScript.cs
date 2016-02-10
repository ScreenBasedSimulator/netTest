using UnityEngine;
using System.Collections;
using UnityEngine.Experimental.Networking;
using UnityEngine.UI;

public class httpRequestScript : MonoBehaviour {

	private static readonly string URL = "http://localhost:26666/unity/status";
	private Text txtRef;
	private int counter = 0;

	// Use this for initialization
	void Start () {
		txtRef = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		if (counter >= 20) {
			StartCoroutine (getText ());
			counter = 0;
		} else {
			counter++;
		}
	}

	IEnumerator getText() {
		using(UnityWebRequest request = UnityWebRequest.Get(URL)) {
			yield return request.Send();
			
			if(request.isError) {
				Debug.Log(request.error);
			}
			else {
				// Show results as text
				Debug.Log(request.downloadHandler.text);
				txtRef.text = request.downloadHandler.text;
			}
		}
	}
}
