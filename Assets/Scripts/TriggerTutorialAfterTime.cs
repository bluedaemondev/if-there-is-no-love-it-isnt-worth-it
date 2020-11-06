using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTutorialAfterTime : MonoBehaviour
{
    public float afterTime = 2f;
    public bool keepSpawnedObject;
    public float killTimeSpawnedObject;

    public GameObject prefabToInstantiate;

    private IEnumerator SpawnObjectAfterT(float t)
    {
        yield return new WaitForSeconds(t);
        var tVec = transform.position;
        tVec.z = 0;

        var goSpawned = Instantiate(prefabToInstantiate, tVec, Quaternion.identity,
            keepSpawnedObject ? GameInfo.instance.guiContainer : GameInfo.instance.deadPool);

        if (!keepSpawnedObject)
            Destroy(goSpawned, killTimeSpawnedObject);

        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == GameInfo.PLAYER_LAYER)
        {
            StartCoroutine(SpawnObjectAfterT(afterTime));
        }

    }
}
