using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FormigaWar.Territorios;

namespace FormigaWar.Jogadores.IA
{
    public class JogadorIA : Jogador
    {
        private readonly int minimoParaSerCandidato = UnityEngine.Random.Range(2, 4);
        private readonly int deixaParaTras = UnityEngine.Random.Range(1, 3);
        private readonly int desvioPadrao = UnityEngine.Random.Range(-1, 3);
        private readonly float mediaPreferida = UnityEngine.Random.Range(1.2f, 3f);
        private readonly int dificuldade;
        private ObjetivoBehaviour behaviour;

        public JogadorIA(int dificuldade)
        {
            this.dificuldade = dificuldade;
        }
        public override void recebeObjetivo(Objetivo objetivo)
        {
            base.recebeObjetivo(objetivo);
            behaviour = objetivo.behaviourFactory.criaBehaviour(dificuldade);
        }
        private Tabuleiro tabuleiro { get => objetivo.tabuleiro; }
        public void RealizaFortificacao(Continente continente)
        {
            int reservas = continente.TropaBonus;
            var ordenadosPorPrioridade =
                tabuleiro.ContinentesDisplay[continente]
                    .OrderBy(territorio => behaviour.GetPrioridade(territorio));
            var peso = reservas / (float)ordenadosPorPrioridade
                .Sum(territorio => behaviour.GetPrioridade(territorio));
            ordenadosPorPrioridade.ToList()
                .ForEach(territorio => Fortificar(
                    Mathf.CeilToInt(behaviour.GetPrioridade(territorio) * peso),
                    territorio
                ));
        }
        public void RealizaFortificacao()
        {
            var fortificaveis = Territorios.Where(territorio => territorio.NumTropas <= 2 * minimoParaSerCandidato)
                .OrderBy(territorio => behaviour.GetPrioridade(territorio));
            var prioridadeTotal = fortificaveis.Sum(territorio => behaviour.GetPrioridade(territorio));
            var peso = reservas / (float)prioridadeTotal;
            fortificaveis.ToList()
                .ForEach(fortificavel =>
                {
                    Fortificar(
                        Mathf.CeilToInt(behaviour.GetPrioridade(fortificavel) * peso), fortificavel);
                });
        }

        /// <summary>Determina os ataques</summary>
        /// <returns>
        /// Lista de funcoes cujo retorno é o numero de tropas movidas para o territorio conquistado.<br/>
        /// Caso retorno seja 0, ele não conquistou o território atacado.
        ///</returns>
        public List<Func<int>> AcoesDeAtaque()
        {
            var acoesDoTurno = new List<Func<int>>();
            var media = Territorios.Average(territorio => territorio.NumTropas);
            var totalDeTerritorios = Territorios.Count;
            var alvos =
                behaviour.DecideAlvos(
                    Territorios.Where(territorio =>
                        territorio.NumTropas >= minimoParaSerCandidato)
                        .OrderBy(territorio => territorio.NumTropas)
                        .ToList()).ToList();
            alvos.ForEach(alvo =>
            {
                alvo.Value.ForEach(destino =>
                acoesDoTurno.Add(() =>
                {
                    bool conquistou = false;
                    var partida = alvo.Key;
                    if (media >= mediaPreferida)
                    {
                        while (partida.NumTropas >= minimoParaSerCandidato && !conquistou)
                        {
                            conquistou = Atacar(partida, destino);
                        }
                    }
                    var atacaCom = partida.NumTropas - Math.Abs(deixaParaTras + UnityEngine.Random.Range(-1, desvioPadrao));
                    if (atacaCom >= partida.NumTropas) atacaCom = partida.NumTropas - 1;
                    if (atacaCom < 0 || !conquistou) atacaCom = 0;
                    return atacaCom;
                }));
            });
            return acoesDoTurno;
        }
        public void RealizaMovimentos()
        {
            var alvos =
                behaviour.DecideAlvos(
                    Territorios.Where(territorio =>
                        territorio.NumTropas >= minimoParaSerCandidato)
                        .OrderBy(territorio => territorio.NumTropas)
                        .ToList()).ToList();
            alvos.ForEach(alvoMap =>
            {
                var partida = alvoMap.Key;
                Mover((partida.numtropas_to_move + 1) / 2,
                    partida,
                    alvoMap.Value.Where(territorio =>
                        behaviour.GetPrioridade(territorio) >= dificuldade / 2)
                        .OrderBy(territorio => behaviour.GetPrioridade(territorio))
                        .FirstOrDefault());
            });
        }

    }

}