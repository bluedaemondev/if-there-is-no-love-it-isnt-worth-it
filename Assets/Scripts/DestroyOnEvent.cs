using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnEvent : MonoBehaviour
{
    public void Destroy()
    {
        Destroy(this.gameObject, 0.3f);
    }
}
