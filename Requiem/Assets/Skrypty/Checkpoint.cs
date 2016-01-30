using UnityEngine;
using System.Collections;

public class CheckPointScript : MonoBehaviour 
{
	void OnTriggerExit2D(Collider2D other) {

		Debug.Log ("TRIGERUJE TO GUWNOD:");
		if (other.tag == "Player") {

			Kontroler kontroler = other.gameObject.GetComponent<Kontroler> ();
			kontroler.CheckpointPosition = this.transform.position;
		}
	}
}