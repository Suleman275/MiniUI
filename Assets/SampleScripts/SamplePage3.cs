using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class SamplePage3 : MiniPage {
    [SerializeField] MiniPage page4;
    public override IEnumerator RenderPage() {
        yield return null;

        CreateAndAddElement<Label>().text = "This is sample page 3";
        CreateAndAddButton("Navigate to sample page 4", () => {
            NavigateTo(page4);
        });
    }
}
