using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

namespace MiniUI {
    public class MiniPage : MonoBehaviour {
        private UIDocument document;
        private VisualElement root;

        [SerializeField] bool showPreview;

        public virtual void OnEnable() {
            Init();
            StartCoroutine(RenderPage());
        }

        private void OnValidate() {
            if (Application.isPlaying)
                return;
            if (showPreview) {
                Init();
                StartCoroutine(RenderPage());
            }
        }

        protected void Init() {
            document = GetComponent<UIDocument>();

            if (document == null) {
                Debug.LogError("UI Document component could not be found");
                return;
            }

            root = document.rootVisualElement;
            root.Clear();
        }

        public virtual IEnumerator RenderPage() {
            throw new NotImplementedException();
        }


        public void addElement<T>(T element) where T : VisualElement {
            root.Add(element);
        }

        public T CreateElement<T>() where T : VisualElement, new() {
            var element = new T();
            return element;
        }

        public T CreateElement<T>(params string[] classes) where T : VisualElement, new() {
            var element = new T();

            foreach (var c in classes) {
                element.AddToClassList(c);
            }

            return element;
        }

        public T CreateAndAddElement<T>() where T : VisualElement, new() {
            var element = new T();
            root.Add(element);
            return element;
        }

        public T CreateAndAddElement<T>(params string[] classes) where T : VisualElement, new() {
            var element = new T();

            foreach (var c in classes) {
                element.AddToClassList(c);
            }

            root.Add(element);
            return element;
        }

        public void AddStylesheet(StyleSheet styleSheet) {
            root.styleSheets.Add(styleSheet);
        }


        public void RemoveStyleSheet(StyleSheet styleSheet) {
            root.styleSheets.Remove(styleSheet);
        }

        public void Enable() {
            //root.SetEnabled(true);
            gameObject.SetActive(true);
        }

        public void EnablePage() {
            enabled = true;
        }

        public void Disable() {
            //root.SetEnabled(false);
            gameObject.SetActive(false);
        }

        public void DisablePage() {
            enabled = false;
        }

        public void SetBackGroundColor(Color color) {
            root.style.backgroundColor = color;
        }

        public void NavigateTo(MiniPage page) {
            if (page == this) {
                Debug.LogError("This page is already active");
                return;
            }

            Disable();
            page.Enable();
        }

        public void ReplacePage(MiniPage page) {
            if (page == this) {
                Debug.LogError("This page is already active");
                return;
            }

            DisablePage();
            page.EnablePage();
        }

        public Button CreateAndAddButton() {
            Button btn = new Button();
            root.Add(btn);

            return btn;
        }

        public Button CreateAndAddButton(string buttonText) {
            Button btn = new Button();
            btn.text = buttonText;
            root.Add(btn);

            return btn;
        }

        public Button CreateAndAddButton(string buttonText, params string[] classes) {
            Button btn = CreateAndAddElement<Button>(classes);
            btn.text = buttonText;

            return btn;
        }

        public Button CreateAndAddButton(string buttonText, Action clickHandler, params string[] classes) {
            Button btn = CreateAndAddElement<Button>(classes);
            btn.text = buttonText;
            btn.clicked += clickHandler;

            return btn;
        }

        public Button CreateAndAddButton(string buttonText, Action clickHandler) {
            Button btn = CreateAndAddElement<Button>();
            btn.text = buttonText;
            btn.clicked += clickHandler;

            return btn;
        }
    }
}