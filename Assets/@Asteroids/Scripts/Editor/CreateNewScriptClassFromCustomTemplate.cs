using UnityEditor;

public class CreateNewScriptClassFromCustomTemplate
{
    private const string pathToModelTemplate = "Assets/@Asteroids/Scripts/ScriptTemplates/ModelTemplate.cs.txt";
    private const string pathToViewTemplate = "Assets/@Asteroids/Scripts/ScriptTemplates/ViewTemplate.cs.txt";
    private const string pathToControllerTemplate = "Assets/@Asteroids/Scripts/ScriptTemplates/ControllerTemplate.cs.txt";

    [MenuItem(itemName: "Assets/Create/Create New Model Script", isValidateFunction: false, priority: 51)]
    public static void CreateModelScript()
    {
        ProjectWindowUtil.CreateScriptAssetFromTemplateFile(pathToModelTemplate, "Model.cs");
    }

    [MenuItem(itemName: "Assets/Create/Create New View Script", isValidateFunction: false, priority: 51)]
    public static void CreateViewScript()
    {
        ProjectWindowUtil.CreateScriptAssetFromTemplateFile(pathToViewTemplate, "View.cs");
    }

    [MenuItem(itemName: "Assets/Create/Create New Controller Script", isValidateFunction: false, priority: 51)]
    public static void CreateControllerScript()
    {
        ProjectWindowUtil.CreateScriptAssetFromTemplateFile(pathToControllerTemplate, "Controller.cs");
    }
}