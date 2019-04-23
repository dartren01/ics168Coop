﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class H_Ghost_Player : D_PlayerAbstract
{
    public float P2Speed = 5f;
    public float P2Jump = 5f;
    public float P2Health = 3f;

    Rigidbody2D rbody;
    BoxCollider2D bcollider;

    public LayerMask GroundLayer;
    public string GoThroughTag = "PassThrough";
    public Vector2 orginial_size;
    //float jumpTime = 0f;
    //float maxJump = 0.2f;

    //public GhostInventory ghostInventory;
    //public LivingInventory livingInventory;
    public Inventory ghostInventory;
    public Inventory livingInventory;

    // Start is called before the first frame update
    void Start()
    {
        rbody = this.GetComponent<Rigidbody2D>();
        bcollider = this.GetComponent<BoxCollider2D>();
        orginial_size = new Vector2(bcollider.size.x, bcollider.size.y);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Debug.DrawRay(transform.position, Vector2.down, Color.green);
    }

    protected override void Move()
    {
        if (Input.GetKey("right"))
        {
            //transform.Translate(Vector2.right * Time.deltaTime * P1Speed);
            rbody.AddForce(new Vector2(P2Speed * Time.deltaTime, 0), ForceMode2D.Impulse);

        }
        else if (Input.GetKey("left"))
        {
            //transform.Translate(Vector2.left * Time.deltaTime * P1Speed);
            rbody.AddForce(new Vector2(-P2Speed * Time.deltaTime, 0), ForceMode2D.Impulse);
        }
        if (Input.GetKeyDown("up"))
        {
            //transform.Translate(Vector2.up * Time.deltaTime * P1Jump);
            //if (base.CheckGround(GroundLayer) && jumpTime <= 0)
            //{
            rbody.AddForce(new Vector2(0, P2Jump), ForceMode2D.Impulse);
            //jumpTime = maxJump;
            //}
        }
        if (Input.GetKeyDown("down"))
        {
            rbody.AddForce(new Vector2(0, -P2Jump), ForceMode2D.Impulse);
        }
        if (Input.GetKeyDown("space"))
        {
            //Swap Items
            Debug.Log("Swapping Items");
            IInventoryItem ghostItem = ghostInventory.mItems[0];
            //IInventoryItem livingItem = livingInventory.mItems[0];
            //ghostInventory.SwapItem(livingItem);
            livingInventory.SwapItem(ghostItem);
            //IInventoryItem ghostItem = ghostInventory.mItems[0];
            //IInventoryItem livingItem = livingInventory.mItems[0];

            //Debug.LogFormat("livingItem is {0} ", livingitem.Name);
            //IInventoryItem temp = ghostItem;
            //ghostItem = livingItem;
            //livingItem = temp;
            //LivingInventory.AddItem(livingInventory.mItems[0]);


            //go ahead and swap
            //ghostInventory.SwapItem(item);
            //Inventory temp = ghostInventory;
            //ghostInventory = livingInventory;
            //livingInventory = temp;
            //Debug.LogFormat("gh {0} and li {1}", ghostInventory.transform.name, livingInventory.transform.name);
            //Debug.Log("Swapped Items");
        }
        //if (jumpTime > 0)
        //{
        //    jumpTime -= Time.deltaTime;
        //}
        //throw new System.NotImplementedException();
    }

    public override void TakeDamage(float dmg)
    {
        throw new System.NotImplementedException();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.LogFormat("Collided with {0}", collision.name);
        IInventoryItem item = collision.GetComponent<IInventoryItem>();
        //Debug.LogFormat("Item is {0}", item);
        if (item != null)
        {
            ghostInventory.AddItem(item);
        }
    }
}