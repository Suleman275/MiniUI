using AYellowpaper.SerializedCollections;
using UnityEngine;

public class MiniRouter : MonoBehaviour {

    public static MiniRouter Instance;
    
    [SerializedDictionary("Page Identfier", "Page Reference")]
    public SerializedDictionary<string, MiniPage> routes;

    private void Awake() {
        Instance = this;
    }

    public void NavigateTo(MiniPage from, string identifier) {
        if (!routes.ContainsKey(identifier)) {
            Debug.LogError("This page is not registered with router");
            return;
        }
        from.NavigateTo(routes[identifier]);
    }

    public void NavigateToComponent(MiniPage from, string identifier) {
        if (!routes.ContainsKey(identifier)) {
            Debug.LogError("This page is not registered with router");
            return;
        }
        from.ReplacePage(routes[identifier]);
    }



    public void EnablePage(string identifier) {
        if (!routes.ContainsKey(identifier)) {
            Debug.LogError("This page is not registered with router");
            return;
        }
        routes[identifier].Enable();
    }

    public void DisablePage(string identifier) {
        if (!routes.ContainsKey(identifier)) {
            Debug.LogError("This page is not registered with router");
            return;
        }
        routes[identifier].Disable();
    }
}
