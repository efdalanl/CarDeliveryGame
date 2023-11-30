using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32(0, 255, 255, 255);
    [SerializeField] Color32 noPackageColor = new Color32(255, 255, 255, 255);
    [SerializeField] float DestroyDelay = 0.5f;
    bool hasPackage;

    SpriteRenderer spriterenderer;

    private void Start()
    {
        spriterenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Çarptın");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Package" && !hasPackage)
        {
            Debug.Log("Package picked up");
            hasPackage = true;
            spriterenderer.color = hasPackageColor;
            Destroy(other.gameObject, DestroyDelay);
        }

        if (other.tag == "Customer" && hasPackage)
        {
            Debug.Log("Package Delivered");
            hasPackage = false;
            spriterenderer.color = noPackageColor;
        }


    }
}
