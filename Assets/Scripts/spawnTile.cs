using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnTile : MonoBehaviour {
	
	public int[] weights;
    public int weightTotal;
	public GameObject TileWithTriggers;
	public GameObject EnemyBoat;
	public GameObject island;
	public GameObject whirlpool;
	public GameObject rocks;
	public GameObject sunkenboat;
    public static List<GameObject> decorations = new List<GameObject>();
	
	void Start(){
		
		decorations.Add(null);
		decorations.Add(EnemyBoat);
		decorations.Add(island);
		decorations.Add(whirlpool);
		decorations.Add(rocks);
		decorations.Add(sunkenboat);
		
		weights = new int[decorations.Count + 1]; //number of things
 
        //weighting of each thing, high number means more occurrance
		weights[0] = 100;
		weights[1] = 25;
		weights[2] = 20;
		weights[3] = 15;
		weights[4] = 10;
		weights[5] = 5;
 
        weightTotal = 0;
        foreach ( int w in weights ) {
            weightTotal += w;
        }
    }
	
	int RandomWeighted() {
        int result = 0, total = 0;
        int randVal = Random.Range( 0, weightTotal );
        for (result = 0; result < weights.Length; result++) {
            total += weights[result];
            if (total > randVal) break;
        }
        return result;
    }
	
	void OnTriggerEnter (Collider other){
		Destroy(this);
		
		Vector3 originPos = this.transform.position;
		
		//adjust origin pos to be center of tile, not trigger position
		if(originPos.x > 0){
			originPos.x -= 8.75f;
		}
		if(originPos.x < 0){
			originPos.x += 8.75f;
		}
		if(originPos.z > 0){
			originPos.z -= 8.75f;
		}
		if(originPos.z < 0){
			originPos.z += 8.75f;
		}
		
		Vector3 newPos = originPos;
		newPos.y = 0f;
		
		float adjust = 17.5f;
		
		
		//new top left
		newPos.x -= adjust;
		newPos.z += adjust;
		if (CheckForTile(newPos)){
			
			int ranVar = RandomWeighted();
			Debug.Log(ranVar);
			if(decorations[ranVar] != null){
				GameObject decoration = Instantiate<GameObject>(decorations[ranVar]);
				decoration.transform.position = newPos;
			}
			else {
				GameObject newTile1 = Instantiate<GameObject>(TileWithTriggers);
				newTile1.transform.position = newPos;
			}
            
		}
		newPos = originPos;
		
		
		//new top center
		newPos.z += adjust;
		newPos.y = 0f;
		if (CheckForTile(newPos)){
            int ranVar = RandomWeighted();
			if(decorations[ranVar] != null){
				GameObject decoration2 = Instantiate<GameObject>(decorations[ranVar]);
				decoration2.transform.position = newPos;
			}
			else {
				GameObject newTile2 = Instantiate<GameObject>(TileWithTriggers);
				newTile2.transform.position = newPos;
			}
		}
		newPos = originPos;
		
		//new top right
		newPos.x += adjust;
		newPos.z += adjust;
		if (CheckForTile(newPos)){
            int ranVar = RandomWeighted();
			if(decorations[ranVar] != null){
				GameObject decoration3 = Instantiate<GameObject>(decorations[ranVar]);
				decoration3.transform.position = newPos;
			}
			else {
				GameObject newTile3 = Instantiate<GameObject>(TileWithTriggers);
				newTile3.transform.position = newPos;
			}
		}
		newPos = originPos;
		
		//new middle left
		newPos.x -= adjust;
		if (CheckForTile(newPos)){
            int ranVar = RandomWeighted();
			if(decorations[ranVar] != null){
				GameObject decoration4 = Instantiate<GameObject>(decorations[ranVar]);
				decoration4.transform.position = newPos;
			}
			else {
				GameObject newTile4 = Instantiate<GameObject>(TileWithTriggers);
				newTile4.transform.position = newPos;
			}
		}
		newPos = originPos;
		
		//new middle right
		newPos.x += adjust;
		if (CheckForTile(newPos)){
            int ranVar = RandomWeighted();
			if(decorations[ranVar] != null){
				GameObject decoration5 = Instantiate<GameObject>(decorations[ranVar]);
				decoration5.transform.position = newPos;
			}
			else {
				GameObject newTile5 = Instantiate<GameObject>(TileWithTriggers);
				newTile5.transform.position = newPos;
			}
		}
		newPos = originPos;
		
		
		//new bottom left
		newPos.x -= adjust;
		newPos.z -= adjust;
		if (CheckForTile(newPos)){
            int ranVar = RandomWeighted();
			if(decorations[ranVar] != null){
				GameObject decoration6 = Instantiate<GameObject>(decorations[ranVar]);
				decoration6.transform.position = newPos;
			}
			else {
				GameObject newTile6 = Instantiate<GameObject>(TileWithTriggers);
				newTile6.transform.position = newPos;
			}
		}
		newPos = originPos;
		
		//new bottom middle
		newPos.z -= adjust;
		if (CheckForTile(newPos)){
			int ranVar = RandomWeighted();
            if(decorations[ranVar] != null){
				GameObject decoration7 = Instantiate<GameObject>(decorations[ranVar]);
				decoration7.transform.position = newPos;
			}
			else {
				GameObject newTile7 = Instantiate<GameObject>(TileWithTriggers);
				newTile7.transform.position = newPos;
			}
		}
		newPos = originPos;
		
		//new bottom right
		newPos.x += adjust;
		newPos.z -= adjust;
		if (CheckForTile(newPos)){
            int ranVar = RandomWeighted();
            if(decorations[ranVar] != null){
				GameObject decoration8 = Instantiate<GameObject>(decorations[ranVar]);
				decoration8.transform.position = newPos;
			}
			else {
				GameObject newTile8 = Instantiate<GameObject>(TileWithTriggers);
				newTile8.transform.position = newPos;
			}
		}
		newPos = originPos;
		
	}
	
	bool CheckForTile(Vector3 pos){
		GameObject[] existingTiles = GameObject.FindGameObjectsWithTag("Tile");
		
		for(int i = 0; i < existingTiles.Length; i++){
			if(existingTiles[i].transform.position == pos){
				return false;
			}
		}
		return true;
	}
	
	
 
}
