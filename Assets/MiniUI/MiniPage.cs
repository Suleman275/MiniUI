using UnityEngine;
using UnityEngine.UIElements;

public class MiniPage {
    public UIDocument document;
    public VisualElement root;

    public MiniPage() {

    }

    public MiniPage(MonoBehaviour context) {
        Init(context);
    }

    public bool Init(MonoBehaviour context) {
        document = context.gameObject.GetComponent<UIDocument>();
        if (document == null) {
            Debug.LogError("UIDocument could not be found on this GameObject");
            return false;
        }
        else {
            root = document.rootVisualElement;

            if (root == null) {
                Debug.Log("Root Visual Element could not be found");
                return false;
            }
        }

        return true;
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

    public MiniPage AddStylesheet(StyleSheet styleSheet) {
        root.styleSheets.Add(styleSheet);

        return this;
    }

    public bool RemoveStyleSheet(StyleSheet styleSheet) {
        root.styleSheets.Remove(styleSheet);

        return !root.styleSheets.Contains(styleSheet);
    }


    public void Enable() {
        root.SetEnabled(true);
    }

    public void Disable() {
        root.SetEnabled(false);
    }

    public MiniPage SetBackGroundColor(Color color) {
        root.style.backgroundColor = color;

        return this;
    }
}
