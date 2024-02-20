using System.Collections;
using UnityEngine.UIElements;

public class SamplePage5 : MiniPage {
    public override IEnumerator RenderPage() {
        yield return null;

        CreateAndAddElement<Label>().text = "This is sample page 5";
        CreateAndAddButton("Navigate to sample page 6", () => {
            MiniRouter.Instance.NavigateToComponent(this, "S6");
        });
    }
}