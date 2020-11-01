using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HealthScript), typeof(Collider2D), typeof(Rigidbody2D))]
public class LoseHealthOnCollision : MonoBehaviour
{
    HealthScript hpContr;
    Rigidbody2D rbEnt;

    public List<LayerMask> collidesWith;

    // Start is called before the first frame update
    void Start()
    {
        hpContr = this.GetComponent<HealthScript>();
        rbEnt = this.GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        //print(collidesWith.Contains(other.gameObject.layer));

        var axu = collidesWith.Find(lm => lm.value == other.gameObject.layer).value;
        //print(axu);

        if (axu <= collidesWith.Count)
        {
            hpContr.GetDamage(rbEnt.velocity.magnitude);
            //print("sending magnitude collision of " + rbEnt.velocity.magnitude);
        }
    }

}
