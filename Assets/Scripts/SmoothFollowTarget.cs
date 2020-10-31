using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFollowTarget : MonoBehaviour
{
    [Range(0f,1f)]
    public float dampingRatio = 0.1f;
    public float dampingFactor = 1;

    public Transform target;
    public bool overrideAndFollowPlayer;


    // Start is called before the first frame update
    void Start()
    {
        if (overrideAndFollowPlayer)
            target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, target.position) < 0.2f)
            return;

        Vector3 mov = (target.position - transform.position).normalized;
        mov.z = 0;
        Vector3 vel = target.GetComponent<Rigidbody2D>().velocity;

        //Vector3 dampedMov = Vector3.SmoothDamp(transform.position, target.position, ref vel, dampingRatio*Time.deltaTime);


        //print(mov);
        //print(dampedMov);
        //transform.position += dampedMov;
    }
}
