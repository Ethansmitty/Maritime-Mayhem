﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class workerBehavior : MonoBehaviour
{
	public GameObject worker;
	public GameObject worker2;
	
    void Update()
    {
		worker2.transform.Translate(1 * Time.deltaTime ,0,0);
		
		if(worker2.transform.position.z >= 0.0f) {
			worker2.transform.Rotate(0f,0f,180f);
		}
		
		if(worker2.transform.position.z <= -2.3f){
			worker2.transform.Rotate(0f,0f,-180f);
		}
		
		if(Time.fixedTime % 1 == 0){
			worker.transform.Rotate(0f,180f,0f,Space.Self);
		}
    }
}
