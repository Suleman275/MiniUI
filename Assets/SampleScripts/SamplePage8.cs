using System.Collections;
using UnityEngine.UIElements;

public class SamplePage8 : MiniPage {
    public override IEnumerator RenderPage() {
        yield return null;

        CreateAndAddElement<Label>().text = "This is sample page 8";
        CreateAndAddButton("Navigate to sample page 7", () => {
            MiniPage page = (MiniPage)GetComponent("SamplePage7");
            ReplacePage(page);
        });
    }
}
