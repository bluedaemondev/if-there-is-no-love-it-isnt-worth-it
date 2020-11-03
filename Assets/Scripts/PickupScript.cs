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

    public MakeFallOnAction fallHandler; // si tira piedras despues de recogerlo, tiene uno

    public GameObject playerCinematicaContainer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == playerLayer) // como dicen los que saben, 
            return;                                    //si anda, no se toca

        print("llamado");
        camSpawned = Instantiate(prefabCameraToSpawn, transform.position, Quaternion.identity);
        camSpawned.GetComponent<CinemachineVirtualCamera>().Follow = transform;
        FindObjectOfType<CamerasManager>()
            .SetCamera(camSpawned.GetComponent<CinemachineVirtualCamera>());

        StartCoroutine(PrepairFallingObjects());

        if (playerCinematicaContainer != null) // box collider para que no se me caiga para cualquier lado
            playerCinematicaContainer.SetActive(true);

        animator.SetTrigger("pickedUp");


        // importante que este abajo porque se cargan cosas de aca en el state enter
    }

    private IEnumerator PrepairFallingObjects()
    {

        CamerasManager.ShakeCameraNormal(1f, 3f);
        yield return new WaitForSeconds(3f);
        CamerasManager.ShakeCameraNormal(3f, 3f);
        yield return new WaitForSeconds(3f);
        CamerasManager.ShakeCameraNormal(5f, 2.4f);
        yield return new WaitForSeconds(2.4f);

        if (fallHandler != null)
            fallHandler.TriggerFall();
        
        yield return new WaitForSeconds(1.4f);

        if (playerCinematicaContainer != null)
            playerCinematicaContainer.SetActive(false);

        Destroy(this.gameObject);
    }

}
