using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {

    private MakeGrid makeGrid;
	// Use this for initialization
	void Start () {
        makeGrid = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MakeGrid>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown() {
        //makeGrid.tileMoveDown(gameObject);    
    }
}
