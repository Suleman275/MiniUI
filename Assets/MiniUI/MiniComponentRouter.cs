using System;
using System.Collections.Generic;
using UnityEngine;

namespace MiniUI {
    public class MiniComponentRouter : MonoBehaviour {
        private Dictionary<string, MiniPage> _pages;
        
        private void Awake() {
            _pages = new Dictionary<string, MiniPage>();
        }

        private void Start() {
            MiniPage[] pages = GetComponents<MiniPage>();

            foreach (MiniPage page in pages) {
                _pages.Add(page.GetType().ToString(), page);
            }
        }

        public void EnablePage(string pageName) {
            if (_pages.ContainsKey(pageName)) {
                _pages[pageName].enabled = true;
            }
            else {
                Debug.LogError("This page does not exist on this GameObject");
            }
        }
        
        public void DisablePage(string pageName) {
            if (_pages.ContainsKey(pageName)) {
                _pages[pageName].enabled = false;
            }
            else {
                Debug.LogError("This page does not exist on this GameObject");
            }
        }

        public void Navigate(MiniPage from, string to) {
            from.enabled = false;
            EnablePage(to);
        }
    }
}