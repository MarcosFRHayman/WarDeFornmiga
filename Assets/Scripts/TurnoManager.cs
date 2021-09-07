using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FormigaWar.Jogadores;

public static class TurnoManager
{
    public static Tabuleiro tabuleiro;
    public enum Fase
    {
        FortificacaoContinental = 0,    // quando a fortificacao lhe restringe para botar as tropas do continente conquistado
        Fortificacao = 1,               // fortificacao normal
        Ataque = 2,                     // ataque
        Movimentacao = 3                // movimentacao
    }

    public static Jogador[] jogadoresNaMesa; // jogadores na mesa
    public static int jogadorDaVez = 0;
    public static int faseAtual = 0;

    public static void InicializarManager(Jogador[] j)
    {
        TurnoManager.jogadoresNaMesa = j;
    }

    public static void AvancarTurno() // avanca o fase atual, se fase atual tiver em 4, pega o proximo jogador e faz fase atual 0
    {
        if(TurnoManager.faseAtual == 3)tabuleiro.AplicarMovimento();
    }
    public static Jogador GetJogadorDaVez() // Pega o jogador da vez como readonly
    {
        return jogadoresNaMesa[jogadorDaVez];
    }
}
