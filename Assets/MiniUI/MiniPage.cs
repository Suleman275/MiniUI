using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace MiniUI {
    public abstract class MiniPage : MonoBehaviour {
        [SerializeField] private bool showPreview;
        
        protected UIDocument _uiDocument;
        protected VisualElement _root;
        private void OnEnable() {
            _uiDocument = GetComponent<UIDocument>();
            _root = _uiDocument.rootVisualElement;
            _root.Clear();
            
            RenderPage();
        }

        private void OnDisable() {
            _root.Clear();
            _root.styleSheets.Clear();
        }

        private void OnValidate() {
            if (Application.isPlaying) return;
            if (showPreview) {
                _uiDocument = GetComponent<UIDocument>();
                _root = _uiDocument.rootVisualElement;
                _root.Clear();
            
                RenderPage();
            }
        }

        //override this method to render your UI
        protected virtual void RenderPage() {
            
        }

        protected T CreateAndAddElement<T>() where T : VisualElement, new() {
            T element = new T();
            
            _root.Add(element);

            return element;
        }
        
        protected T CreateAndAddElement<T>(params string[] classes) where T : VisualElement, new() {
            T element = new T();

            foreach (string className in classes) {
                element.AddToClassList(className);
            }
            _root.Add(element);
            
            return element;
        }

        protected T CreateElement<T>() where T : VisualElement, new() {
            return new T();
        }
        
        protected T CreateElement<T>(params string[] classes) where T : VisualElement, new() {
            T element = new T();

            foreach (string className in classes) {
                element.AddToClassList(className);
            }

            return element;
        }
        
        protected void AddStyleSheet(StyleSheet styleSheet) {
            _root.styleSheets.Add(styleSheet);
        }
    }
}