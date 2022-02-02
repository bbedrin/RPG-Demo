using System.Collections;
using RPG.Saving;
using UnityEngine;

namespace RPG.SceneManagement
{
    public class SavingWrapper : MonoBehaviour
    {
        private const string DefaultSaveFile = "save";

        [SerializeField] private float fadeInTime = 0.2f;
        
        private IEnumerator Start()
        {
            var fader = FindObjectOfType<Fader>();
            fader.FadeOutImmediate();
            yield return GetComponent<SavingSystem>().LoadLastScene(DefaultSaveFile);
            yield return fader.FadeIn(fadeInTime);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.L))
            {
                Load();
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                Save();
            } 
            else if (Input.GetKeyDown(KeyCode.Delete))
            {
                Delete();
            }
        }

        private void Delete()
        {
            GetComponent<SavingSystem>().Delete(DefaultSaveFile);
        }

        public void Save()
        {
            GetComponent<SavingSystem>().Save(DefaultSaveFile);
        }

        public void Load()
        {
            GetComponent<SavingSystem>().Load(DefaultSaveFile);
        }
    }
}