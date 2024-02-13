using System.CodeDom.Compiler;
using UnityEngine;
using UnityEngine.UIElements;

public class MonoPage : MonoBehaviour {
    UIDocument document;
    protected VisualElement root;

    void Awake() {
        document = GetComponent<UIDocument>();
        root = document.rootVisualElement;
    }

    public virtual void BuildPage() {
        Button x = CreateAndAddElement<Button>();
        x.text = "ubs";
    }

    protected T CreateAndAddElement<T>() where T : VisualElement, new() {
        var element = new T();
        root.Add(element);
        return element;
    }
}
