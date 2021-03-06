using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEditor;

[CreateAssetMenu]
public class FalaNPC : ScriptableObject
{
    public string fala;

    public Resposta[] respostas;

    public Sequencia sequencia;

    public bool npcFalando;

    public string falaNode;

    public Personagem jogador;
    public Personagem NPC;

    public NPCOS dadosNpc;

    public bool recomecar;
    public bool NPCNode;

    public bool proximaQuest;

    public bool acaoSequencial;

    public bool proximaCutscene;

    public Cutscene cutscene;
    
}
