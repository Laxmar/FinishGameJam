using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {


	public void Cont1(Kontroler kontroler) {
		
			kontroler.isShowing = !kontroler.isShowing;
	

		}

	
public void Cont2(GameObject menu) {

	menu.gameObject.SetActive(false);

	}
}

