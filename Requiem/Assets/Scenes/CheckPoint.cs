using UnityEngine;
using System.Collections;

using UnityEngine;

public class Checkpoint : MonoBehaviour 
{



		public Vector3 CheckpointPosition;

		void OnCollisionEnter2D(Collision2D collision)
		{
			if (collision.gameObject.tag == "Checkpoint")
			{
				CheckpointPosition = collision.gameObject.transform.position; 
				return;
			}

		if (collision.gameObject.tag == "Death") {

			//PlayerPosition = CheckpointPosition;
			return;
			}
			

		}




	void Start()
	{

	}


}