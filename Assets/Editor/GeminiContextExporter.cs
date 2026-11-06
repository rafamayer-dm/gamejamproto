using UnityEngine;
using UnityEditor;
using System.IO;
using System.Text;
using UnityEngine.SceneManagement;

public class GeminiContextExporter
{
    [MenuItem("Tools/Export Context for Gemini")]
    public static void ExportContext()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine("=== UNITY PROJECT CONTEXT ===");
        sb.AppendLine("Scene: " + SceneManager.GetActiveScene().name);
        sb.AppendLine("\n--- SCENE HIERARCHY & COMPONENTS ---");

        // Pega todos os objetos raiz da cena
        GameObject[] rootObjects = SceneManager.GetActiveScene().GetRootGameObjects();
        foreach (GameObject obj in rootObjects)
        {
            DumpGameObject(obj, sb, "");
        }

        sb.AppendLine("\n--- C# SCRIPTS (ASSETS) ---");

        // Busca todos os scripts, ignorando pacotes nativos da Unity
        string[] guids = AssetDatabase.FindAssets("t:MonoScript");
        foreach (string guid in guids)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            if (!path.Contains("Packages/") && !path.Contains("Plugins/"))
            {
                sb.AppendLine(path);
            }
        }

        // Salva o arquivo na raiz do projeto (fora da pasta Assets)
        string filePath = Path.Combine(Application.dataPath, "../GeminiContext.txt");
        File.WriteAllText(filePath, sb.ToString());

        Debug.Log("Contexto exportado com sucesso! Arquivo salvo em: " + filePath);
        EditorUtility.RevealInFinder(filePath); // Abre a pasta do arquivo automaticamente (Windows/Mac)
    }

    private static void DumpGameObject(GameObject obj, StringBuilder sb, string indent)
    {
        sb.AppendLine(indent + "- " + obj.name);

        // Lista os componentes anexados ao GameObject (ignorando o Transform padrão)
        Component[] components = obj.GetComponents<Component>();
        foreach (Component comp in components)
        {
            if (comp != null && !(comp is Transform))
            {
                sb.AppendLine(indent + "  [C] " + comp.GetType().Name);
            }
        }

        // Faz a recursão para os filhos
        foreach (Transform child in obj.transform)
        {
            DumpGameObject(child.gameObject, sb, indent + "  ");
        }
    }
}
