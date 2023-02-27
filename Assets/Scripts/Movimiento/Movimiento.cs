using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    [SerializeField] private float rapidezCaminar = 4f;
    //[SerializeField] private float velInicialDeSalto = 5.0f;
    [SerializeField] private float alturaSaltoExtra = 1.0f;
    [SerializeField] private float numeroSaltosExtra = 1.0f;
    [SerializeField] private float alturaSalto = 2.0f;
    [SerializeField] private LayerMask capasSalto;
    private float SaltosHechos = 0;
    private Rigidbody2D rb;
    private BoxCollider2D boxCollider;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

 
    void Update()
    {
        ColisionSuelo();
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
                if (SaltosHechos < numeroSaltosExtra)
                {
                    rb.velocity = new Vector2(rb.velocity.x, Mathf.Sqrt((-2 * gravedad * alturaSaltoExtra)));
                    SaltosHechos += 1;
                }
            }
            else 
            { 
        // Si estoy tocando capas entonces "hacer Salto"

            rb.velocity = new Vector2(rb.velocity.x,velInicialDeSalto);
            }
        }
       
    }
    public void VoltearTransform(float movimientoX)
    {
        transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x) * Mathf.Sign(movimientoX), transform.localScale.y);
    }

    public void ColisionSuelo()
    {
        if (boxCollider.IsTouchingLayers(capasSalto))
        {
            SaltosHechos = 0;
        }
    }
}
