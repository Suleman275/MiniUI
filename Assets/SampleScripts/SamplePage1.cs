using System.Collections;
using UnityEngine.UIElements;

public class SamplePage1 : MiniPage {
    public override IEnumerator RenderPage() {
        yield return null;

        CreateAndAddElement<Label>().text = "This is sample page 1";
        CreateAndAddButton("Navigate to sample page 2", () => {
            MiniRouter.Instance.NavigateTo(this, "S2");
        });
    }
}
