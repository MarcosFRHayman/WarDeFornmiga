using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FormigaWar
{
    public class ChangeScene : MonoBehaviour
    {
        public string nomeDaCena;

        public void ChangeS() {
            SceneManager.LoadScene(nomeDaCena);
        }

        public void Quit() {
            Application.Quit();
        }
    }
}
