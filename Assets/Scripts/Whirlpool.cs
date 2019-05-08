using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Whirlpool : MonoBehaviour
{
	
	public GameObject boat;
	public Rigidbody rb;
    
	
	void Start(){
		boat = GameObject.FindGameObjectsWithTag("Player")[0];
		rb = boat.GetComponent<Rigidbody>();
	}
    void OnTriggerEnter(Collider other) {
		rb.drag = 5f;
	}
	
	void OnTriggerExit(Collider other){
		rb.drag = .75f;
	}
}
