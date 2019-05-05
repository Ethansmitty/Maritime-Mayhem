using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class workerBehavior : MonoBehaviour
{
	public GameObject worker;
	public GameObject worker2;
	public bool forward;
	
	void Start(){
		forward = true;
		worker2.transform.Rotate(0f,0f,0f);
	}
	
    void Update()
    {
		
		worker2.transform.Translate(2 * Time.deltaTime ,0,0);
		
		if(Time.fixedTime % 1 == 0 && Time.fixedTime >= 1){
			worker.transform.Rotate(0f,180f,0f,Space.Self);
			worker2.transform.Rotate(0f,0f,180f);
		}
		
		/*
		if(Time.fixedTime % 2 == 0){
			if(forward) {
				forward = false;
				
			}
			else {
				forward = true;
				worker2.transform.Rotate(0f,0f,0f);
			}
		}*/
    }
}
