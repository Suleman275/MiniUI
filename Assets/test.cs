using UnityEngine.UIElements;
using UnityEngine;

public class test : MonoPage {
    private void Start() {
        BuildPage();
    }

    public override void BuildPage() {
        root.style.width = 300;
        root.style.height = 300;
        root.style.backgroundColor = Color.black;

        CreateAndAddElement<Button>().text = "woah";
    }
}