using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Kassi : MonoBehaviour
{
    // stiga teljari
    public static int count = 0;
    // sprenging
    public GameObject sprenging;
    // stiga teljara texti
    private TextMeshProUGUI countText;
    void Start()
    {
        // finnur hvar á að setja texta
        countText = GameObject.Find("Text").GetComponent<TextMeshProUGUI>();
        // byrjar að telja frá 0
        count = 0;
        // og setur stig á skjá
        SetCountText();

    }
    private void Update()
    {
        SetCountText();

        // stiginn eru kominn uppi 30
        if (count == 30)
        {
            // bendill gerður sjáanlegur aftur
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            // stig endurstill í 0
            count = 0;
            // þú vannst senan kemur upp
            SceneManager.LoadScene(3); // þú vannst
        }
    }
    private void OnCollisionEnter(Collision collision)
    {   
        // ef Kassi verður fyrir kulu þá er kassanum eytt
        if (collision.collider.tag == "kula")
        {
            Destroy(gameObject);
            gameObject.SetActive(false);

            Debug.Log("varð fyrir kúlu");

            // ef þetta er stori kassinn á eyjunni færðu 4 stig annars 1 stig
            if (this.tag == "storKassi")
            {
                count +=  4;
            }
            else
            {
                count += 1;
            }
            // setur stiginn á skjá
            SetCountText();
            // spilar sprengingu
            Sprengin();
        }
    }
    // aðferð sem skrifað stiginn á skjá
    public void SetCountText()
    {
        countText.text = "Stig: " + count.ToString() + "/30";
    }

    //keyrir sprenginguna
    void Sprengin()
    {
        Instantiate(sprenging, transform.position, transform.rotation);
    }
}
