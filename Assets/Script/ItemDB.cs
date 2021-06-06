using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDB : MonoBehaviour
{
    public List<Item> ItemList = new List<Item>();

    public Dictionary<int, Item> ItemDictionary  = new Dictionary<int,Item>();

    private void Start()
    {
        Item sword = new Item();
        sword.name ="Sword";
        sword.id = 0;

        ItemList.Add(sword);
        ItemDictionary.Add(0,sword);

        Item shield = new Item();
        shield.name ="Shield";
        shield.id = 1;
        ItemDictionary.Add(1,shield);

        Item Armor = new Item();
        Armor.name = "Armor";
        Armor.id = 2;
        ItemDictionary.Add(2,Armor);

        foreach(var key in ItemDictionary.Keys){
            Debug.Log(key + ":" + ItemDictionary[key].id + ":" + ItemDictionary[key].name);
        }

    }

}
