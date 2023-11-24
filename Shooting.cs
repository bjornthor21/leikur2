using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    // Bullet og hraði
    public GameObject bullet;
    public float speed = 4000f;
    
    // Update is called once per frame
    void Update()
    {
        // Þegar ýtt er á Z þá skýst kúla
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log("skotið");       
            
            // býr til nýtt gameobject kúlu
            GameObject instBullet = Instantiate(bullet, transform.position, transform.rotation) as GameObject;
            // bætir rigidbody við
            Rigidbody instBulletRigidbody = instBullet.GetComponent<Rigidbody>();
            // látið kúlluna fljúga áfram með hraða
            instBulletRigidbody.AddForce(transform.forward * speed);
            // eytt kúluni eftir 2 sek
            Destroy(instBullet, 2f);//þessu var breytt frá 0.5 sek uppi 2 til að hitta í kassan á eyjunni
           
        }
    }
}
