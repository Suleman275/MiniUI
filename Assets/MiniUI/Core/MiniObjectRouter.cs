using AYellowpaper.SerializedCollections;
using UnityEngine;

public class MiniObjectRouter : MonoBehaviour {
    public static MiniObjectRouter Instance;

    [SerializedDictionary("Page Identfier", "Page Reference")]
    public SerializedDictionary<string, MiniPage> routes;

    private void Awake() {
        Instance = this;
    }

    public void RegisterRoute(string identifier, MiniPage page) {
        routes.Add(identifier, page);
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

    public void NavigateTo(MiniPage from, string identifier) {
        if (!routes.ContainsKey(identifier)) {
            Debug.LogError("This page is not registered with router");
            return;
        }
        from.NavigateTo(routes[identifier]);
    }
}
