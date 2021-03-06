using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interagir : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem mascaraFX;

    public static string paraOndeVou;
    public static string itemSelecionado;
    static public bool itemNaMao;
    public static bool podeAndar = true;
    public static bool olharDireita = true;
    public int vel;
    public Transform posJogador;
    public bool mascara;
    [SerializeField] GameObject prefabAbel;
    [SerializeField] GameObject circ;
   
    public Vector2 alvo;    
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
        circAnimator = circ.GetComponent<Animator>();
        animator = prefabAbel.GetComponent<Animator>();
        posJogador = GetComponent<Transform>();

        prefabTransform = prefabAbel.transform;        
        posAtu = new Vector3(posJogador.position.x, posJogador.position.y, posJogador.position.z);
        alvo = posAtu;
    }

    void Update()
    {
        if (olharDireita)
        {
            prefabTransform.eulerAngles = new Vector3(0, 0, 0);
            mascaraFX.startSpeed = 0.9f;
        }
        else
        {
            prefabTransform.eulerAngles = new Vector3(0, 180, 0);
            mascaraFX.startSpeed = -0.9f;
        }

        if (Dialogo.mascara)
        {
            animator.SetBool("Mascara", true);
        }
        else
        {
            animator.SetBool("Mascara", false);
        }

        if(paraOndeVou == "")
        {
            alvo = posJogador.position;
        }

        if (posAtu != alvo)
        {
            CaixaIdle.cancelarTextoAbel = true;
            if (Dialogo.mascara)
            {
                animator.SetBool("AndandoMascara", true);
            }
            else
            {
                animator.SetBool("Andando", true);
            }


            if (posAtu.x > alvo.x)
            {
                olharDireita = false;
            }
            else
            {
                olharDireita = true;
            }

            posAtu = Vector3.MoveTowards(posAtu, alvo, vel * Time.deltaTime);
            posJogador.position = posAtu;

        }
        else
        {
            if (Dialogo.mascara)
            {
                animator.SetBool("AndandoMascara", false);

            }
            animator.SetBool("Andando", false);
        }

       
    }
    public void OffSet()
    {
        Vector2 offSet = new Vector2(0.005f, 0);
        posAtu = posAtu + offSet;
        alvo = alvo + offSet;
        posJogador.position = posAtu;
    }

    public void TeleportarJogador(Transform coordenada)
    {
        posAtu = coordenada.position;
        alvo = coordenada.position;
        posJogador.position = posAtu;
        paraOndeVou = "";
    }


    public void Andar(Vector3 destino, bool chao)
    {
        if (podeAndar)
        {
            /*
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                //Bolinha do toque
                if (touch.phase == TouchPhase.Began)
                {
                    mover = true;
                }

                //Movimento
                if (touch.phase == TouchPhase.Ended)
                {
                    ponto = Camera.main.ScreenToWorldPoint(touch.position);
                    circ.transform.position = new Vector2(ponto.x, ponto.y);

                    if (Physics2D.OverlapPoint(ponto, 1, -5, 5))
                    {
                        if (mover)
                        {
                            Indicar();
                            alvo = new Vector2(destino.x, posJogador.position.y);
                            if (chao)
                            {

                                alvo = new Vector2(ponto.x, posJogador.position.y);
                            }
                        }
                    }
                }
            }
            */
            if (Input.GetMouseButtonUp(0))
            {
                mover = true;
                ponto = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                circ.transform.position = new Vector2(ponto.x, ponto.y);
                if (Physics2D.OverlapPoint(ponto, 1, -5, 5))
                {
                    if (mover)
                    {
                        Indicar();
                        alvo = new Vector2(destino.x, posJogador.position.y);
                        if (chao)
                        {
                            alvo = new Vector2(ponto.x, posJogador.position.y);
                        }
                    }
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

    public void Mascara()
    {
        Dialogo.mascara = !Dialogo.mascara;
        paraOndeVou = "";
        alvo = posJogador.position;

        if (Dialogo.mascara)
        {
            mascaraFX.Play();
        }
        else
        {
            mascaraFX.Stop();
        }
    }
}
