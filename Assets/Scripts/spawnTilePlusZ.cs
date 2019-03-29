using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnTilePlusZ : MonoBehaviour {
	public GameObject TileWithTriggers;
	//add new tiles with enemy/land/gold here
	List<GameObject> tiles = new List<GameObject>();
	void Start(){
		tiles.Add(TileWithTriggers);
		//add new tiles to list here
	}
	
	void OnTriggerEnter (Collider other){
		Destroy(this);
		
		Vector3 newPos = this.transform.position;
		newPos.z += 8.75f;
		newPos.y = 0f;
		if(CheckForTile(newPos)){
			GameObject newTile = Instantiate<GameObject>(tiles[(int) Random.Range(0f,tiles.Count)]);
			newTile.transform.position = newPos;
			newTile.transform.localScale = new Vector3(1.0f,1.0f,1.0f);
		}
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