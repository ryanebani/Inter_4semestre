using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Snap : MonoBehaviour
{
    [SerializeField] bool correto;
    public string alternativo;
    [SerializeField] string tagCompare;
    [SerializeField] float snapX;
    [SerializeField] float snapY;

    RectTransform myRectT;
    

    public bool canSnap;
    public bool parentear;

    public UnityEvent OnTrigger;
    public UnityEvent OnAlternativo;
    public UnityEvent OnGanhar;

    void Start()
    {
        myRectT = GetComponent<RectTransform>();        
    }


    void Update()
    { 
    }

    public void OnCanSnap()
    {
        StartCoroutine(Timer());
    }
  
    public void OnCanSnap2()
    {
        canSnap = true;
    }

    public void CancelSnap()
    {
        canSnap = false;
    }

    public void Parentear(GameObject filho)
    {
        filho.transform.parent = gameObject.transform;
    }
    void OnTriggerStay2D(Collider2D colisor)
    {
        Snap snapado = colisor.GetComponent<Snap>();
        if (colisor.gameObject.tag == tagCompare && canSnap)
        {
                
            RectTransform colRectT = colisor.GetComponent<RectTransform>();
            myRectT.anchoredPosition = new Vector2(colRectT.anchoredPosition.x + snapX, colRectT.anchoredPosition.y + snapY);

            OnTrigger?.Invoke();

            if(snapado.alternativo == alternativo)
            {
                OnAlternativo?.Invoke();
            }
            else if (snapado.correto && alternativo == "")
            {
                OnGanhar?.Invoke();               
            }            
        }

    }

    IEnumerator Timer()
    {
        canSnap = true;
        yield return new WaitForSeconds(0.1f);
        canSnap = false;
    }
}
