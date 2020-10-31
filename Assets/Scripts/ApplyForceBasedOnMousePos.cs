using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ApplyForceBasedOnMousePos : MonoBehaviour
{
    private Rigidbody2D rbObject;
    public float forceToApply = 10f;
    //public float maxForce 

    private Vector2 mousePosition;

    // Start is called before the first frame update
    void Start()
    {
        rbObject = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Input.GetMouseButton(0))
            return;

        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 force = mousePosition - (Vector2)transform.position;
        force = force.normalized * forceToApply;

        print("Force " + force +"  ||   Mag : "+force.magnitude);

        rbObject.AddForce(-force * Time.deltaTime, ForceMode2D.Impulse);

        //rbObject.velocity.magnitude > 

    }
}
