using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;//TileMap用
//https://qiita.com/kako_vail/items/57c574629fcaf4d9787f
//参考
public class TileDelete : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        var hitPos = Vector3.zero;

        foreach(var point in collisionInfo.contacts){
            hitPos = point.point;
        }

        var position = collisionInfo.gameObject.GetComponent<Tilemap>().cellBounds.allPositionsWithin;
        var minPosition = 0;
        var allPosition = new List<Vector3>();

        foreach(var variable in position){
            if(collisionInfo.gameObject.GetComponent<Tilemap>().GetTile(variable) != null){
                allPosition.Add(variable);
                Debug.Log(variable.ToString());

            }
        }

        for(var i=1;i<allPosition.Count;i++){
            if((hitPos - allPosition[i]).magnitude < (hitPos- allPosition[minPosition]).magnitude){
                minPosition = i;
            }
        }

        var finalPosition = Vector3Int.RoundToInt(allPosition[minPosition]);

        var tiletmp = collisionInfo.gameObject.GetComponent<Tilemap>().GetTile(finalPosition);

        if(tiletmp != null){
            var map = collisionInfo.gameObject.GetComponent<Tilemap>();
            var tileCol = collisionInfo.gameObject.GetComponent<TilemapCollider2D>();
            map.SetTile(finalPosition,null);
            tileCol.enabled = false;
            tileCol.enabled = true;
        }
    }
}
