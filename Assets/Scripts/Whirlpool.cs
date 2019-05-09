using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Whirlpool : MonoBehaviour
{
    public Config Config;
	public GameObject boat;
	private Rigidbody rb;
    
	
	void Start(){
		boat = GameObject.FindGameObjectsWithTag("Player")[0];
		rb = boat.GetComponent<Rigidbody>();
	}
    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player"))
        {
            rb.drag = 5f;
        }
	}
	
	void OnTriggerExit(Collider other){
        if (other.CompareTag("Player"))
        {
            rb.drag = Config.playerDefaultDrag;
        }
	}
}
