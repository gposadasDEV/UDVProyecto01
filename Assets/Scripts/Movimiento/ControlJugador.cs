using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControlJugador : MonoBehaviour
{
    private Movimiento movimiento;
    private Vector2 entradaControlMov;
    void Start()
    {
        movimiento = GetComponent<Movimiento>();
    }

    
    void Update()
    {

        movimiento.MoverseEnX(entradaControlMov.x);
    }

    public void Almoverse(InputAction.CallbackContext context ) 
    {
        entradaControlMov = context.ReadValue<Vector2>();
    }
}
