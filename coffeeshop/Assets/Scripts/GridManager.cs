using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public static GridManager instance;
    public GameObject grid, tile;
    public int ySize, xSize;
    public List<GameObject> tileType = new List<GameObject>();
    public GameObject selectedTile;

    private GameObject[,] gridTiles;
    private List<Color> tileColor = new List<Color>()
    {
         Color.red,
         Color.green,
         Color.blue,
         Color.yellow
     };

    // Use this for initialization
    void Start()
    {
        instance = GetComponent<GridManager>();
        Vector2 offset = tile.GetComponent<SpriteRenderer>().bounds.size;
        CreateGrid(offset.x, offset.y);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CreateGrid(float xOff, float yOff)
    {
        gridTiles = new GameObject[xSize, ySize];

        float startX = transform.position.x;
        float startY = transform.position.y;

        for (int x = 0; x < xSize; x++)
        {
            for (int y = 0; y < ySize; y++)
            {
                //Decides on the Type/Color of Tile to Use
                int colorNum = Random.Range(0, tileColor.Count);
                int typeNum = Random.Range(0, tileType.Count);

                //Check whether this selection would make 3 in a row and if so prevent it - TBD


                //Makes the Next Tile of the Randomly Chosen Type
                GameObject newTile = Instantiate(tileType[typeNum], new Vector3(startX + (xOff * x), startY + (yOff * y), -3), tile.transform.rotation);

                //Assigns a color to the tile
                newTile.GetComponent<SpriteRenderer>().color = tileColor[colorNum];

                //Makes the Tile a Child of the Grid Object
                newTile.transform.parent = grid.transform;
                gridTiles[x, y] = newTile;
            }
        }
    }
}