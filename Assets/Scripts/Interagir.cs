using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interagir : MonoBehaviour
{
    public string paraOndeVou;
    public static string itemSelecionado;
    public static bool podeAndar = true;
    public static bool olharDireita = true;

    public Transform posJogador;

    [SerializeField] GameObject prefabAbel;
    [SerializeField] GameObject circ;
   
    Vector2 alvo;    
    Vector2 posAtu;
    Vector3 ponto;

    CaixaIdle caixaIdle;
    Animator animator;
    Animator circAnimator;
    Transform prefabTransform;
    bool mover;
    public bool chaoCheck;


    void Start()
    {
        Application.targetFrameRate = 60;
        itemSelecionado = null;
        caixaIdle = GetComponentInChildren<CaixaIdle>();

        animator = prefabAbel.GetComponent<Animator>();
        prefabTransform = prefabAbel.transform;

        posJogador = GetComponent<Transform>();
        posAtu = new Vector3(posJogador.position.x, posJogador.position.y, posJogador.position.z);
        alvo = posAtu;
        circAnimator = circ.GetComponent<Animator>();
    }

    void Update()
    {  
        if (olharDireita)
            prefabTransform.eulerAngles = new Vector3(0, 0, 0);
        else
            prefabTransform.eulerAngles = new Vector3(0, 180, 0);
                

        if (posAtu != alvo)
        {
            CaixaIdle.cancelarTextoAbel = true;
            animator.SetBool("Andando", true);
            
            if (posAtu.x > alvo.x)
            {
                olharDireita = false;
            }
            else
            {
                olharDireita = true;
            }

            posAtu = Vector3.MoveTowards(posAtu, alvo, 5 * Time.deltaTime);
            posJogador.position = posAtu;

        }
        else
        {
            animator.SetBool("Andando", false);
        }

       
    }

    public void TeleportarJogador(Transform coordenada)
    {
        posAtu = coordenada.position;
        alvo = coordenada.position;
        posJogador.position = posAtu;
        paraOndeVou = "";
    }


    public void Andar(Vector3 alvoObj, bool chao)
    {
       
        if (Input.touchCount > 0 && podeAndar)
        {
            Touch touch = Input.GetTouch(0);

            //Bolinha do toque
            if (touch.phase == TouchPhase.Began )
            {                
                ponto = Camera.main.ScreenToWorldPoint(touch.position);
                circ.transform.position = new Vector2(ponto.x, ponto.y);
                mover = true;
                chaoCheck = true;
            }

            //Movimento
            if (touch.phase == TouchPhase.Ended)
            {
                Debug.Log(Physics2D.OverlapPoint(ponto));
                ponto = Camera.main.ScreenToWorldPoint(touch.position);
                circ.transform.position = new Vector2(ponto.x, ponto.y);
                
                
                if (mover && Physics2D.OverlapPoint(ponto, 5))
                {
                    if (chao)
                    {                        
                        alvo = new Vector2(ponto.x, posJogador.position.y);
                        chaoCheck = false;
                    }
                    else
                    {
                        
                        alvo = new Vector2(alvoObj.x, posJogador.position.y);
                    }
                    Indicar();

                    mover = false;
                }
            }
        }
        
    }

    public void Indicar()
    {
        circAnimator.SetTrigger("Indicar");
    }
    public void PodeIdle(string falasIdle)
    {
        caixaIdle.LigarTexto();
        caixaIdle.SetFala(falasIdle);
    }

    public void ResetarParaOndeVou()
    {
        paraOndeVou = "";
    }

    public void PodeAndar(bool ligar)
    {
        podeAndar = ligar;
    }
}
