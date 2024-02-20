using System.Collections;
using UnityEngine.UIElements;

public class SamplePage7 : MiniPage {
    public override IEnumerator RenderPage() {
        yield return null;

        CreateAndAddElement<Label>().text = "This is sample page 7";
        CreateAndAddButton("Navigate to sample page 8", () => {
            MiniPage page = (MiniPage) GetComponent("SamplePage8");
            ReplacePage(page);
        });
    }
}
