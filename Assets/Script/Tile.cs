using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Tile : MonoBehaviour
{

    public Tilemap tilemap;
    public TileBase possibleTile;
    public Grid grid;
    public Camera camera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            Vector3 clickPos = Input.mousePosition;
            Vector3Int gridPos = grid.WorldToCell(camera.ScreenToWorldPoint(clickPos));

            CheckMoveRange(gridPos,3);
        }else if(Input.GetMouseButtonUp(0)){
            tilemap.ClearAllTiles();
        }
    }

    void CheckMoveRange(Vector3Int unitPos, int maxAmount){
        SearchPossible(unitPos,maxAmount);
    }
    void SearchPossible(Vector3Int pos,int remainAmount){
        if(remainAmount ==0){
            return;
        }
        tilemap.SetTile(pos,possibleTile);
        remainAmount--;

        SearchPossible(pos + Vector3Int.up,remainAmount);
        SearchPossible(pos + Vector3Int.down,remainAmount);
        SearchPossible(pos + Vector3Int.right,remainAmount);
        SearchPossible(pos + Vector3Int.left,remainAmount);
                
    }
}
