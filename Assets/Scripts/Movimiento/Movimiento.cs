using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    [SerializeField] private float rapidezCaminar = 4f;
    //[SerializeField] private float velInicialDeSalto = 5.0f;
    [SerializeField] private float LimiteSaltos = 1.0f;
    [SerializeField] private float alturaSalto = 2.0f;
    [SerializeField] private LayerMask capasSalto;
    private float CantidadSaltos = 0;
    private Rigidbody2D rb;
    private BoxCollider2D boxCollider;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

 
    void Update()
    {
        tocoSuelo();
    }

    public void MoverseEnX(float movimientoX)
    {
        rb.velocity = new Vector2(movimientoX * rapidezCaminar, rb.velocity.y);
    }

    public void Saltar(bool valor)
    {
        float gravedad = Physics2D.gravity.y * rb.gravityScale;
        float velInicialDeSalto = Mathf.Sqrt((-2 * gravedad * alturaSalto));
        if (valor)
        {
            // Si no estoy tocando las capas, "no hacer salto"
            if (!boxCollider.IsTouchingLayers(capasSalto))
            {
                if (CantidadSaltos < LimiteSaltos)
                {
                    rb.velocity = new Vector2(rb.velocity.x, Mathf.Sqrt((-2 * gravedad * alturaSalto)));
                    CantidadSaltos += 1;
                }
            }
            else 
            { 
        // Si estoy tocando capas entonces "hacer Salto"

            rb.velocity = new Vector2(rb.velocity.x,velInicialDeSalto);
            }
        }
       
    }
 

    public void tocoSuelo()
    {
        if (boxCollider.IsTouchingLayers(capasSalto))
        {
            CantidadSaltos = 0;
        }
    }
}
