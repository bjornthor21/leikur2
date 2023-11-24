using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Klikk : MonoBehaviour
{
    // þegar ýtt er á takka þá byrjar leikurinn
    public void OnButtonPress()
    {
        SceneManager.LoadScene(1);
    }
}
