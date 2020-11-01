using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupScript : MonoBehaviour
{
    public Animator animator;
    public GameObject prefabCameraToSpawn;
    public Collider2D colTrigg;

    public GameObject camSpawned;
    public int playerLayer = 9;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == playerLayer) // como dicen los que saben, 
            return;                                    //si anda, no se toca

        print("llamado");
        camSpawned = Instantiate(prefabCameraToSpawn, transform.position, Quaternion.identity);
        camSpawned.GetComponent<CinemachineVirtualCamera>().Follow = transform;

        animator.SetTrigger("pickedUp"); 
        // importante que este abajo porque se cargan cosas de aca en el state enter
    }

}
