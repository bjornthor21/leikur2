using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Ovinur : MonoBehaviour
{
    // breyta fyrir líf, staðsetningu player, breyta til að geyma stefnu players, líf texta rigidbody óvins og hraða óvins
    public static int health = 30;
    private Transform player;
    public TextMeshProUGUI texti;
    private Rigidbody rb;
    private Vector3 movement;
    public float hradi = 4f;
    // Start is called before the first frame update
    void Start()
    {
        // nær í capsule mesh players
        player = GameObject.Find("First Person Controller").transform.GetChild(1);
        // líf texti
        texti = GameObject.Find("lif").GetComponent<TextMeshProUGUI>();
        // rigidbod óvins
        rb = this.GetComponent<Rigidbody>();
        // frumstillir Líf texta
        texti.text = "Líf " + health.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        // reiknar stefnu players og geymir í movement 
        Vector3 stefna = player.position - transform.position;
        stefna.Normalize();
        movement = stefna;
        // athugar hvort player er dauður notað til að drepa player þegar hann fer útúr mappinu
        TakeDamage(0);
    }
    private void FixedUpdate()
    {
        // kallar í hreyfing
        Hreyfing(movement);
    }
    // lætur Óvin fara í áttina að player
    void Hreyfing(Vector3 stefna)
    {
        rb.MovePosition(transform.position + (stefna * hradi * Time.deltaTime));
    }

    // collisions
    private void OnCollisionEnter(Collision collision)
    {
        // ef Player snertir óvin fær hann -10
        if (collision.collider.tag == "Player")
        {
            Debug.Log("Leikmaður fær í sig óvin");
            // af einhverri ástæðu virkar TakeDamage þannig að gildið tvöfaldast 5 = -10 health
            TakeDamage(5);
            // óvinur hverfur
            gameObject.SetActive(false);

        }

        // ef kúla hittir óvin þá hverfur hann
        if (collision.collider.tag == "kula")
        {
            Debug.Log("óvinur skotinn");
            gameObject.SetActive(false);
        }
    }

    // tekur damage af player og athugar hvort hann sé dauður
    public void TakeDamage(int damage)
    {
        Debug.Log("health er núna" + health.ToString());
        health -= damage;
        texti.text = "Líf " + health.ToString();
        if (health <= 0)
        {

            // ef hann er dauður þá endursetjist leikurinn og þú ert dauður skjárinn kemur upp
            Cursor.lockState = CursorLockMode.None;
            health = 30;
            Kassi.count = 0;//núll stilli stigin 
            texti.text = "Líf " + health.ToString();
            SceneManager.LoadScene(2);
            
        }

    }
    

}
