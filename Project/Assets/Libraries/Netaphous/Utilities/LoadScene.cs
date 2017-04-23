using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace Netaphous.Utilities
{
    public class LoadScene : MonoBehaviour
    {
        static public LoadScene instance;

        void OnEnable()
        {
            instance = this;
        }

        public void LoadLevel(int level)
        {
            SceneManager.LoadSceneAsync(level);
        }

        public void LoadLevel(string name)
        {
            SceneManager.LoadSceneAsync(name);
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}