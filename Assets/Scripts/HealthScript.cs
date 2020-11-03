using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    public UnityEngine.UI.Image imgLife;
    public float currentLifeAlpha = 0;

    public float minVelocityToGetHit = 14f;

    public Color colorLife;
    //magnitud hasta 18 tira el mouse

    // Start is called before the first frame update
    void Start()
    {
        imgLife.color = colorLife;
    }
    public void GetDamage(float speedCurrent)
    {
        //print(speedCurrent);
        if (speedCurrent >= minVelocityToGetHit)
        {
            //me pego
            print("ay!");
            currentLifeAlpha += Mathf.Clamp(speedCurrent, 0, 90);
            imgLife.color = new Color(imgLife.color.r, imgLife.color.g, imgLife.color.b, currentLifeAlpha / 100);
            CamerasManager.ShakeCameraNormal(5f, .1f);
        }
        //else
        //{
        //    print("nodmg");
        //}

        if (currentLifeAlpha >= 100)
        {
            imgLife.color = new Color(imgLife.color.r, imgLife.color.g, imgLife.color.b, 1);
        }

    }
}
