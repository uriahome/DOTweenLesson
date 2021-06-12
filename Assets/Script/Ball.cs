using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Ball : MonoBehaviour
{
    public Vector2 iniitialVelocity = new Vector2(1.0f,10.0f);
    public GameObject tilemapGameObject;
    Tilemap tilemap;
    public Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = iniitialVelocity.x * UnityEngine.Random.Range(-1f,1f) * Vector3.right + iniitialVelocity.y  * Vector3.down;
        if(tilemapGameObject != null){
            tilemap = tilemapGameObject.GetComponent<Tilemap>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Vector3 hitPosition = Vector3.zero;
        if(tilemap != null && tilemapGameObject == collision.gameObject){
            foreach(ContactPoint2D hit in collision.contacts){
                hitPosition.x = hit.point.x - 0.01f*hit.normal.x;
                hitPosition.y = hit.point.y - 0.01f*hit.normal.y;
                tilemap.SetTile(tilemap.WorldToCell(hitPosition),null);
            }

        }
    }
}
