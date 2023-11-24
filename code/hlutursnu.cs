using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hlutursnu : MonoBehaviour
{
    void Update()
    {
        // snúa hlut í hring
        transform.Rotate(new Vector3(0,80,0) * Time.deltaTime);
    }
}
