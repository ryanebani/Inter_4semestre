using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunctionsNPC : MonoBehaviour
{
    Inventario inventario;
    [SerializeField]
    Animator animator;
    Fade fade;
    Dialogo dialogo;
    bool itemDesejado;
    //bool infoDesejada;

    public string chave;
    public ItemOS item;


    void Start()
    {
        inventario = FindObjectOfType<Inventario>();
        fade = GetComponent<Fade>();
        dialogo = GetComponent<Dialogo>();   
    }

   
    void Update()
    {
        //DetectarItem();
    }

    public void SetarChave(string chave)
    {
        this.chave = chave;
    }

    public void SetarItem(ItemOS item)
    {
        this.item = item;
    }

    public void EntregarItem(bool receber)
    {
        if (receber && Interagir.itemSelecionado == chave)
        {
            ReceberItem();
        }

        if(Interagir.itemSelecionado == chave)
        {
            inventario.RemoverItem();
            dialogo.ProximaQuest();          
        }
        else
        {

        }
    }

    public void ReceberItem()
    {
        inventario.AdicionarItem(item);
    }

    /* public void InfoObtida()
    {
        infoDesejada = true;
    }

    public void darItem(bool precisaFade)
    {
        
        if (itemDesejado)
        {
            inventario.RemoverItem();
            dialogo.ProximaQuest();
            Debug.Log(Interagir.itemSelecionado);
            if (precisaFade)
            {
                fade.IniciarFade();
            }
        }
    }

    public void receberItem()
    {
        
        if (itemDesejado)
        {
            inventario.AdicionarItem(item, gameObject);
        }
    

    public void ItemPorInfo()
    {
        if (itemDesejado)
        {
            //liberaResposta = true;
            inventario.RemoverItem();
        }
    }


    public void InfoPorInfo()
    {
        if (infoDesejada)
        {
            liberaResposta = true;
        }
    }

    public void InfoPorItem()
    {
        if (infoDesejada)
            inventario.AdicionarItem(item, gameObject);
    }*/


    public void TriggarAnimacao(string trigger)
    {
        animator.SetTrigger(trigger);
    }
}
