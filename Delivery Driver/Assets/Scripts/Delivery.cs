using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor= new Color32(1,1,1,1);
    [SerializeField] Color32 noPackageColor = new Color32(185, 102, 102, 255);
    bool hasPackage;
    SpriteRenderer spriteRenderer;
    [SerializeField] float delayTime= 0.6f;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Bonk");   
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Package")&& !hasPackage)
        {
            Debug.Log("Package is picked up");
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;
            Destroy(collision.gameObject, delayTime);
        }
        if (collision.CompareTag("Customer") && hasPackage )
        {
            Debug.Log("Deliverd the package");
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
        }
    }
}
