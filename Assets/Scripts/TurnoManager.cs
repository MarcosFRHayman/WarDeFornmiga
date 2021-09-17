using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using FormigaWar;
using FormigaWar.Jogadores;
using FormigaWar.Territorios;
using System.Linq;

public static class TurnoManager
{
    public static Tabuleiro tabuleiro;
    public static BotaoDeAvancar bda;
    public static DialogoMsg dialogoMsg;
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
    public static int faseAtual = 4;
    public static int continenteAtual = 0;

    public static void InicializarManager(Jogador[] j)
    {
        TurnoManager.jogadoresNaMesa = j;
    }
    public static void AvancarTurno() // avanca o faseAtual, se fase atual tiver em 4, pega o proximo jogador e faz fasAtual = 0
    {
        

        if(TurnoManager.faseAtual == 0) // se a fase for de fortificação continental, passe por todos os continentes antes de avançar
        {
            AvancarContinente();
            return;
        }
        else if(TurnoManager.faseAtual == 1)
        {
            if(GetJogadorDaVez().GetMao().Length >= 5)
                bda.GetComponent<MaoUI>().AbrirMao(GetJogadorDaVez());
        }
        
        TurnoManager.faseAtual += 1;
        if (TurnoManager.faseAtual >= 4) // se esta eh a ultima fase do turno, vai para o proximo jogador
        {
            TurnoManager.ConquistouUmTerritorio = false; // reseta a flag para cartas
            tabuleiro.AplicarMovimento();
            TurnoManager.faseAtual = 0;
            TurnoManager.continenteAtual = -1;
            
            TurnoManager.jogadorDaVez += 1;
            if (TurnoManager.jogadorDaVez >= TurnoManager.jogadoresNaMesa.Length) // se este eh o ultimo jogador na mesa, volte para o primeiro
            {
                TurnoManager.jogadorDaVez = 0;
                
            }
            AvancarContinente();
            /* 
            //############################################################### Checa se o jogador da vez eh IA.
            if(GetJogadorDaVez() is JogadorIA)
            {
                // executa o turno da IA, com os metodos do jogador;
            }
            // ############################################################### Executa o turno, e avança. 
            */

            MsgReservas();
        }
        else 
        {
            tabuleiro.DeselecionarTodosTerritorios();
            tabuleiro.NormalizarTerritoriosDoJogador(GetJogadorDaVez());
        }
        bda.AtualizaTexto();
    }
    private static void AvancarContinente()
    {   
        continenteAtual += 1;
        
        if(continenteAtual >= tabuleiro.Continentes.Length){
            TurnoManager.faseAtual += 1;
            tabuleiro.DeselecionarTodosTerritorios();
            tabuleiro.NormalizarTerritoriosDoJogador(GetJogadorDaVez());
            GetJogadorDaVez().CalcularReservas(0);
            return;
        }
        else
        {
            tabuleiro.DesabilitarContinentesMenosUm(tabuleiro.Continentes[continenteAtual]);
            GetJogadorDaVez().CalcularReservas(tabuleiro.Continentes[continenteAtual].TropaBonus); 
        } 
        if(!GetJogadorDaVez().continentes.Contains(tabuleiro.Continentes[continenteAtual]))AvancarContinente(); // se o jogador n conquistou o continente, pula pro proximo
        bda.AtualizaTexto();
    }
    public static Jogador GetJogadorDaVez() // Pega o jogador da vez como readonly
    {
        return jogadoresNaMesa[jogadorDaVez];
    }
    private static void MsgReservas()
    {
        int c = GetJogadorDaVez().Territorios.Count;
        string msg = "Você ganhou " + (int)c/2 + " tropas por ter " + c + " territórios. \n ";
        if(GetJogadorDaVez().continentes.Count > 0) msg += "Além de mais";
        foreach(Continente cont in GetJogadorDaVez().continentes)msg += cont.TropaBonus + " por conquistar " + cont.nome + "\n";
        dialogoMsg.MostraDiag(msg);
    }
    public static void ChecarVitoria(Jogador jogador, TerritorioDisplay td)
    {
        if(jogador.objetivo.Checar())dialogoMsg.MostraDiag("O jogador " +jogador+ " venceu!");
    }

    public static void EliminaJogador(Jogador j)
    {
        int index = -1;
        for(int i = 0; i < jogadoresNaMesa.Length; i++)
        {
            if(j == jogadoresNaMesa[i])
            {
                index = i;
                break;                
            }
        }
        if(index != -1)
            jogadoresNaMesa = jogadoresNaMesa.Where(val => val != j).ToArray();
    }

}
