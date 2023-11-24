using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    // Start is called before the first frame update

    // player byssan byssa sem er á player falin í byrjun
    private GameObject pGun;
    // audio source
    public AudioSource audioSource;


    void Start()
    {
        // finnur og felur svo byssu players í byrjun
        pGun = GameObject.Find("playersGun");
        pGun.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // athugar ef Player hefur dottið úr heimi og setur health í 0
        if(gameObject.transform.position.y <= -1)
        {
            Ovinur.health = 0;
        }
    }

    void OnCollisionEnter(Collision collision)
    {

        // ef player snertir byssuna sem er í húsinu
        if (collision.collider.tag == "Gun")
        {
            // þá hverfur sú byssa
            collision.gameObject.SetActive(false);
            // en birtist byssan sem var á playernum
            pGun.SetActive(true);

            // þetta lætur lýta út eins og player er að taka upp byssuna
        }

        // ef player snertir pening
        if (collision.collider.tag == "Coin")
        {
            // hækkar stig um 2;
            Kassi.count += 2;
            // peningurinn hverfur
            collision.gameObject.SetActive(false);
            // hljóð heyrist
            audioSource.Play();
        }
    }
}
