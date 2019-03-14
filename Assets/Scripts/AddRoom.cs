using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRoom : MonoBehaviour {

	private RoomDirectionHolder templates;

	void Start(){

		templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomDirectionHolder>();
		templates.rooms.Add(this.gameObject);
	}
}
