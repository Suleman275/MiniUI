using System.Collections;
using UnityEngine.UIElements;

public class SamplePage2 : MiniPage {
    public override IEnumerator RenderPage() {
        yield return null;

        CreateAndAddElement<Label>().text = "This is sample page 2";
        CreateAndAddButton("Navigate to sample page 1", () => {
            MiniRouter.Instance.NavigateTo(this, "S1");
        });
    }
}

