﻿using System.Security.Policy;
using UnityEngine;
using System.Collections;

enum ItemType
{
    Health,
    Armor,
    HealthUp
}
public class Item : UnityObserver {
    public Material[] mats;
    public const string PICK_UP_ITEM = "PICK_UP_ITEM";
    private MazeCell currentCell;
    private MazeRoom currentRoom;
     ItemType itemType;

    public string GetItemType()
    {
        return itemType.ToString();
        
    }
    public override void OnNotify( Object sender, EventArguments e )
    {
        if ( e.eventMessage == PICK_UP_ITEM )
        {
            
        }
    }
    void Awake()
    {
        RandomItem();
    }
    public void SetInitialLocation( MazeCell cell )
    {
        currentRoom = cell.room;
        SetLocation( cell );
    }

    private void SetLocation( MazeCell cell )
    {
        if ( currentCell != null )
        {
            currentCell.OnPlayerExited( );
        }
        currentCell = cell;
        transform.localPosition = cell.transform.localPosition;
    }

    private void RandomItem()
    {
        int enumCount = ItemType.GetNames(typeof (ItemType)).Length;
        int selection = UnityEngine.Random.Range(0, 11);
       

        if (selection <= 6)
        {
            itemType = ItemType.Health;
            Material[] health = new Material[1];
            health[0] = mats[0];
            transform.GetChild(0).GetComponent<Renderer>().materials = health;
           
        }
        if (selection > 5 && selection <= 9)
        {
            itemType = ItemType.Armor;
            Material[] armour = new Material[1];
            armour[0] = mats[1];
            transform.GetChild(0).GetComponent<Renderer>().materials = armour;
           
        }
        else if(selection > 9)
        {
            itemType = ItemType.HealthUp;
            Material[] healthUp = new Material[1];
            healthUp[0] = mats[2];
            transform.GetChild(0).GetComponent<Renderer>().materials = healthUp;
            
        }      
    }
}