using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace MiniUI {
    public abstract class MiniPage : MonoBehaviour {
        [SerializeField] private bool showPreview;

        protected UIDocument _uiDocument;
        protected VisualElement _root;
        protected MiniComponentRouter _router;

        public System.Object _recievedData = new System.Object();

        private void OnEnable() {
            _uiDocument = GetComponent<UIDocument>();
            _root = _uiDocument.rootVisualElement;
            _root.Clear();

            _router = GetComponent<MiniComponentRouter>();

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

        protected void ReRenderPage() {
            _root.Clear();
            RenderPage();
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

        protected void AddStyleSheets(params StyleSheet[] styleSheets) {
            foreach (StyleSheet styleSheet in styleSheets) {
                _root.styleSheets.Add(styleSheet);
            }
        }

        protected void AddStyleSheet(StyleSheet styleSheet) {
            _root.styleSheets.Add(styleSheet);
        }

        protected void InheritStylesFromComponentRouter() {
            foreach (StyleSheet styleSheet in _router.styles) {
                AddStyleSheet(styleSheet);
            }
        }
    }
}