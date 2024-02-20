using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class SamplePage4 : MiniPage {
    [SerializeField] MiniPage page3;
    public override IEnumerator RenderPage() {
        yield return null;

        CreateAndAddElement<Label>().text = "This is sample page 4";
        CreateAndAddButton("Navigate to sample page 3", () => {
            NavigateTo(page3);

        });
    }
}
