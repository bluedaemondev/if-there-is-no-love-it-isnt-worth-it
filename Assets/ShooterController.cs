using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ShooterState { 
    idle, 
    shooting
}

[RequireComponent(typeof(Animator))]
public class ShooterController : MonoBehaviour
{
    public ShooterState currentState;

    public string isIdleParam = "isIdle";
    public string isShootingParam = "isShooting";

    public bool isIdle = true;
    public bool isShooting = false;

    //public Rigidbody2D rbSh;

    public List<Shooter> shootpoints;
    Animator animator;

    public Collider2D agroToShoot; //espacio para activarse , istrigger


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        foreach (var sp in shootpoints)
        {
            sp.particleSys.Stop();

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == GameInfo.PLAYER_LAYER)
        {
            SetCurrentState(ShooterState.shooting);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == GameInfo.PLAYER_LAYER)
        {
            SetCurrentState(ShooterState.idle);
        }
    }



    public void SetCurrentState(ShooterState state)
    {
        this.currentState = state;

        switch (state) {
            case ShooterState.idle:
                isShooting = false;
                foreach (var sp in shootpoints)
                {
                    sp.particleSys.Stop();

                }
                isIdle = true;
                break;
            case ShooterState.shooting:
                foreach (var sp in shootpoints)
                {
                    sp.particleSys.Play();

                }
                isIdle = false;
                isShooting = true;
                break;

        }

        animator.SetBool(isIdleParam, isIdle);
        animator.SetBool(isShootingParam, isIdle);

    }
}
