using UnityEngine;

namespace MiniUI {
    public interface IMiniRouter {
        void NavigateTo();

        void EnablePage();

        void DisablePage();
    }
}
