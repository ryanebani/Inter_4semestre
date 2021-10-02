using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemOS item;
    Inventario inventario;

    public void Start()
    {
        inventario = GameObject.FindObjectOfType<Inventario>();
    }

    public void OnValidate()
    {
        if (item != null)
        {
            gameObject.name = item.nome;
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            gameObject.GetComponent<SpriteRenderer>().sprite = item.icone;

        }
    }

    public void OnMouseDown()
    {
        inventario.AdicionarItem(item, gameObject);     

    }

    public void Inicializar()
    {
        if (item == null)
        {
            gameObject.name = "Item";
            gameObject.GetComponent<SpriteRenderer>().sprite = null;          

        }
        else
        {
            gameObject.name = item.nome;
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            gameObject.GetComponent<SpriteRenderer>().sprite = item.icone;
        }
    }

    
}