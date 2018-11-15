using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTile : MonoBehaviour
{
    public bool selected;
    public GridManager manager;
    // Use this for initialization
    void Start()
    {
        selected = false;
        manager = GameObject.Find("GridManager").GetComponent<GridManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (selected)
            this.transform.localScale = new Vector3(6, 6, 6);
        else
            this.transform.localScale = new Vector3(5, 5, 5);
    }

    public void TileSelected()
    {
        Debug.Log("Didit2");
        GameObject prevObject = manager.selectedTile;
        if (prevObject != null)
        {
            GameTile prevGameTile = manager.selectedTile.GetComponent<GameTile>();
            if (manager.selectedTile == this.gameObject)
            {
                selected = false;
                prevObject = null;
            }
            else
            {
                //Gets the distance between tiles
                Vector2 offset = this.gameObject.GetComponent<SpriteRenderer>().bounds.size;

                //Saves the positions of the tiles surrounding the previously selected tile
                Vector3 tileAbove = new Vector3(prevObject.transform.position.x, prevObject.transform.position.y + offset.y, prevObject.transform.position.z);
                Vector3 tileBelow = new Vector3(prevObject.transform.position.x, prevObject.transform.position.y - offset.y, prevObject.transform.position.z);
                Vector3 tileRight = new Vector3(prevObject.transform.position.x + offset.x, prevObject.transform.position.y, prevObject.transform.position.z);
                Vector3 tileLeft = new Vector3(prevObject.transform.position.x - offset.x, prevObject.transform.position.y, prevObject.transform.position.z);

                //If this tile is one of the surrounding tiles
                if (transform.position == tileAbove || transform.position == tileBelow || transform.position == tileRight || transform.position == tileLeft)
                {
                    //Saves the current positions for later use
                    Vector3 currentPos = transform.position;
                    Vector3 tempPos = prevObject.transform.position;

                    //Swaps the position of the pair of tiles 
                    prevObject.transform.position = currentPos;
                    transform.position = tempPos;

                    //Deselects all the tiles
                    selected = false;
                    prevGameTile.selected = false;
                    manager.selectedTile = null;

                    CheckMatches();
                    prevGameTile.CheckMatches();
                    SpecialEffect();
                }
            }
        }
        else
        {
            selected = true;
            manager.selectedTile = this.gameObject;
        }
    }
    
    //Contains the code for specific Tile's special effect
    protected virtual void SpecialEffect(){}

    //Checks Whether or not this tile is matched by three or more in a row.
    public void CheckMatches()
    {

    }

    void OnMouseDown()
    {
        //Debug.Log("Didit"); ;
        //RaycastHit2D hit = Physics2D.Raycast(new Vector2(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position).x, Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position).y), Vector2.zero, 0);
        //
        //if (hit)
        //{
        //    if (hit.collider.CompareTag("Tile"))
        //    {
        //        GameObject clickedTile = hit.transform.gameObject;
        //        clickedTile.GetComponent<GameTile>().TileSelected();
        //    }
        //}

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.CompareTag("Tile"))
            {
            
                Debug.Log("Didit"); 
                TileSelected();
            }
        }
    }
}
