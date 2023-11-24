using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Vatn : MonoBehaviour
{
    // vatn collider
    private void OnTriggerEnter(Collider other)
    {
        // ef hlutur með tag Player fer í gegnum collider Þá deyr Player
        if (other.tag == "Player")
        {
            Cursor.lockState = CursorLockMode.None;
            Debug.Log("Drukknaði");
            SceneManager.LoadScene(2);

        }
    }
}
