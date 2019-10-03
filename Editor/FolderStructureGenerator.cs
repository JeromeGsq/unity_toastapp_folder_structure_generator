#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public static class FolderStructureGenerator
{
    [MenuItem("Tools/FolderStructureGenerator/Generate folder structure")]
    private static void GenerateFolderStructure()
    {
        GenerateFolder("Plugins");
        GenerateFolder("Editor");
        GenerateFolder("Project");
        GenerateFolder("Resources/Prefabs/UI/Views");
        GenerateFolder("Scenes");

        GenerateFolder("Project/Fonts/Raws");

        GenerateFolder("Project/Graphics/2D/UI");
        GenerateFolder("Project/Graphics/3D");
        GenerateFolder("Project/Graphics/Animations");
        GenerateFolder("Project/Graphics/Materials/Particles");

        GenerateFolder("Project/ScriptableObjects/UnityWeld/AdaptersOptions");

        GenerateFolder("Project/Scripts/UI");
        GenerateFolder("Project/Scripts/Utils");
        GenerateFolder("Project/Scripts/ScriptableObjects");
    }

    private static void GenerateFolder(string link)
    {
        var root = "Assets";

        var folders = link.Split('/');

        if (folders.Length == 0)
        {
            folders = new string[] { link };
        }

        for (int i = 0; i < folders.Length; i++)
        {
            if (!AssetDatabase.IsValidFolder(root + "/" + folders[i]))
            {
                AssetDatabase.CreateFolder(root, folders[i]);
            }

            root += "/" + folders[i];
        }
    }
}
#endif