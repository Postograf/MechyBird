using System.Collections;

using UnityEngine;

namespace Assets.Scripts
{
    public class Pauser : MonoBehaviour
    {
        [SerializeField] private bool _pauseOnStart;

        private void Start()
        {
			if (_pauseOnStart)
				Pause();
        }

        public void Pause()
        {
            Time.timeScale = 0;
        }

        public void Unpause()
        {
            Time.timeScale = 1;
        }
    }
}