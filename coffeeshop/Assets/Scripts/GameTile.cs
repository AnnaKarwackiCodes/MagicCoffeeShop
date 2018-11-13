using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTile : MonoBehaviour {
    bool selected;
    public GridManager manager;
	// Use this for initialization
	void Start () {
        selected = false;
        manager = GameObject.Find("GridManager").GetComponent<GridManager>();
    }
	
	// Update is called once per frame
	void Update () {
        if (selected)
            this.transform.localScale = new Vector3(6, 6, 6);
        else
            this.transform.localScale = new Vector3(5, 5, 5);
    }

    void TileSelected()
    {
     
    }
}
