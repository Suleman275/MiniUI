using AYellowpaper.SerializedCollections;
using System.Collections.Generic;
using UnityEngine;

public class MiniComponentRouter : MonoBehaviour {
    public static MiniComponentRouter Instance;
    public Dictionary<string, MiniPage> routes;

    private void Awake() {
        routes = new Dictionary<string, MiniPage>();
        Instance = this;
    }

    private void Start() {
        RegisterRoutesFromArray(GetPages());
    }

    private MiniPage[] GetPages() {
        MiniPage[] pages = GetComponents<MiniPage>();
        return pages;
    }

    private void RegisterRoutesFromArray(MiniPage[] pages) {
        foreach (MiniPage page in pages) {
            routes.Add(page.GetType().ToString(), page);
        }
    }

    public void NavigateTo(MiniPage from, string identifier) {
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
        routes[identifier].EnablePage();
    }

    public void DisablePage(string identifier) {
        if (!routes.ContainsKey(identifier)) {
            Debug.LogError("This page is not registered with router");
            return;
        }
        routes[identifier].DisablePage();
    }


}