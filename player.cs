using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    // Start is called before the first frame update

    // player byssan byssa sem er � player falin � byrjun
    private GameObject pGun;
    // audio source
    public AudioSource audioSource;


    void Start()
    {
        // finnur og felur svo byssu players � byrjun
        pGun = GameObject.Find("playersGun");
        pGun.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // athugar ef Player hefur dotti� �r heimi og setur health � 0
        if(gameObject.transform.position.y <= -1)
        {
            Ovinur.health = 0;
        }
    }

    void OnCollisionEnter(Collision collision)
    {

        // ef player snertir byssuna sem er � h�sinu
        if (collision.collider.tag == "Gun")
        {
            // �� hverfur s� byssa
            collision.gameObject.SetActive(false);
            // en birtist byssan sem var � playernum
            pGun.SetActive(true);

            // �etta l�tur l�ta �t eins og player er a� taka upp byssuna
        }

        // ef player snertir pening
        if (collision.collider.tag == "Coin")
        {
            // h�kkar stig um 2;
            Kassi.count += 2;
            // peningurinn hverfur
            collision.gameObject.SetActive(false);
            // hlj�� heyrist
            audioSource.Play();
        }
    }
}
