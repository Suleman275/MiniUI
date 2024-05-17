using UnityEditor;

namespace MiniUI {
    public static class TemplateCreator {
        static string templatePath = "Assets/MiniUI/ScriptTemplates/NewMiniPage.cs.txt";

        [MenuItem("Assets/Create/MiniUI/MiniPage", priority = 1)]
        public static void CreateMiniPageMenuItem() {
            ProjectWindowUtil.CreateScriptAssetFromTemplateFile(templatePath, "NewMiniPage.cs");
        }
    }
}