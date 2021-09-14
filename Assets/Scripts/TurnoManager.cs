using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FormigaWar.Jogadores;

public static class TurnoManager
{
    public static Tabuleiro tabuleiro;
    public static bool ConquistouUmTerritorio; // se o jogador da vez conquistou um territorio este turno
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
        tabuleiro.DeselecionarTodosTerritorios();
        tabuleiro.NormalizarTerritoriosDoJogador(GetJogadorDaVez());

        if (TurnoManager.faseAtual == 3) tabuleiro.AplicarMovimento();

        TurnoManager.faseAtual += 1;
        if (TurnoManager.faseAtual >= 4) // se esta eh a ultima fase do turno, vai para o proximo jogador
        {
            TurnoManager.ConquistouUmTerritorio = false;
            
            TurnoManager.faseAtual = 0;
            TurnoManager.jogadorDaVez += 1; 
            if (TurnoManager.jogadorDaVez >= TurnoManager.jogadoresNaMesa.Length) // se este eh o ultimo jogador na mesa, volte para o primeiro
            {
                TurnoManager.jogadorDaVez = 0;
            }

            TurnoManager.GetJogadorDaVez().CalcularReservas();
            //Debug.Log(TurnoManager.GetJogadorDaVez().reservas);
        }
    }
    public static Jogador GetJogadorDaVez() // Pega o jogador da vez como readonly
    {
        return jogadoresNaMesa[jogadorDaVez];
    }

}
