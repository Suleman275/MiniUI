using System.Collections;
using UnityEngine.UIElements;

public class SamplePage6 : MiniPage {
    public override IEnumerator RenderPage() {
        yield return null;

        CreateAndAddElement<Label>().text = "This is sample page 6";
        CreateAndAddButton("Navigate to sample page 5", () => {
            MiniRouter.Instance.NavigateToComponent(this, "S5");
        });
    }
}