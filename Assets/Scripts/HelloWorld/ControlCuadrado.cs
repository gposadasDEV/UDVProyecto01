using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCuadrado : MonoBehaviour
{
    // Start is called before the first frame update
    HelloWorld hw;
    void Start()
    {
        hw = hw.GetComponent<HelloWorld>();
        hw.Saludar();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
