using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class Shooter : MonoBehaviour
{

    public ParticleSystem particleSys;


    // Start is called before the first frame update
    void Start()
    {
        this.particleSys = GetComponent<ParticleSystem>();


    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.layer == GameInfo.PLAYER_LAYER)
        {
            HealthScript hs;
            other.TryGetComponent(out hs);

            if (hs)
            {
                hs.GetDamage(hs.minVelocityToGetHit);
            }
        }
    }
}
