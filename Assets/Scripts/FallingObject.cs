using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class FallingObject : MonoBehaviour
{
    Rigidbody2D rbObject;
    Collider2D colAux;


    //[Header()]
    public float gravityScale = 1;
    public bool isGravityActive = false;


    // Start is called before the first frame update
    void Start()
    {
        rbObject = this.GetComponent<Rigidbody2D>();
    }

    public void MakeFall()
    {
        //this.rbObject.gravityScale = 1;
        this.rbObject.gravityScale = gravityScale;
        this.rbObject.constraints = RigidbodyConstraints2D.None;
        print("falling" + this.name);
    }
}
