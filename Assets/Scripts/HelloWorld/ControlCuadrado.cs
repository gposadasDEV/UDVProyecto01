using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCuadrado : MonoBehaviour
{
    // Start is called before the first frame update
    HelloWorld hw;
    void Start()
    {
        hw = GetComponent<HelloWorld>();
        if (hw != null)
        { hw.Saludar(); }
        else { Debug.Log("No se encuentra archivo"); };
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
