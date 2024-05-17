using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace MiniUI {
    public class MiniComponentRouter : MonoBehaviour {
        public List<StyleSheet> styles;

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

        public void EnablePageWithData(string pageName, System.Object data) {
            if (_pages.ContainsKey(pageName)) {
                _pages[pageName]._recievedData = data;
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

        public void NavigateWithData(MiniPage from, string to, System.Object data) {
            from.enabled = false;
            EnablePageWithData(to, data);
        }
    }
}