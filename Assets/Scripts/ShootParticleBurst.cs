using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootParticleBurst : MonoBehaviour
{
    public float burstInterval = 1f;
    public float count = 10f;

    public bool activatedByMouse = true;
    private bool emitting;

    private ParticleSystem.Burst[] bursts;

    ParticleSystem particleEmmitter;


    private void Start()
    {
        particleEmmitter = this.GetComponentInChildren<ParticleSystem>();
        bursts = new ParticleSystem.Burst[1] { new ParticleSystem.Burst(burstInterval, count) };

        particleEmmitter.emission.SetBursts(bursts);


    }

    private void Update()
    {

        bool activated = Input.GetMouseButton(0) && activatedByMouse || (emitting && !activatedByMouse);

        if (activated)
        {
            if (!particleEmmitter.isPlaying)
                particleEmmitter.Play();
            //particleEmmitter.gameObject.SetActive(true);
        }
        else
        {
            if (particleEmmitter.isPlaying)
                particleEmmitter.Stop();
            //particleEmmitter.gameObject.SetActive(false);
        }
    }
}
