using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
using System.IO;

namespace TrilloBit3sIndieGames
{
    public class CreateFolders : EditorWindow 
    {
        private static string projectName = "PROJECT_NAME";

        [MenuItem("Tools/Setup/Create Default Folders")]
        private static void SetUpFolders()
        {
            CreateFolders window = ScriptableObject.CreateInstance<CreateFolders>();
            // Centraliza a janela pop-up na tela
            window.position = new Rect(Screen.width / 2f, Screen.height / 2f, 400, 150);
            window.ShowPopup();
        }

        private static void CreateAllFolders()
        {
            // Define o caminho relativo à pasta raiz do projeto
            string rootPath = Path.Combine("Assets", projectName);

            // Garante que a pasta raiz do projeto exista primeiro
            if (!Directory.Exists(rootPath))
            {
                Directory.CreateDirectory(rootPath);
            }

            List<string> folders = new List<string>
            {
                "Animations",
                "Audio",
                "Editor",
                "Materials",
                "Meshes",
                "Prefabs",
                "Scripts",
                "Scenes",
                "Shaders",
                "Textures",
                "UI"
            };

            foreach (string folder in folders)
            {
                string targetPath = Path.Combine(rootPath, folder);
                if (!Directory.Exists(targetPath))
                {
                    Directory.CreateDirectory(targetPath);
                }
            }

            List<string> uiFolders = new List<string>
            {
                "Assets",
                "Fonts",
                "Icon"
            };

            foreach (string subfolder in uiFolders)
            {
                string targetUIPath = Path.Combine(rootPath, "UI", subfolder);
                if (!Directory.Exists(targetUIPath))
                {
                    Directory.CreateDirectory(targetUIPath);
                }
            }

            // Atualiza o banco de dados do Unity para refletir as pastas imediatamente
            AssetDatabase.Refresh();
        }

        void OnGUI()
        {
            EditorGUILayout.LabelField("Insert the Project name used as the root folder:", EditorStyles.boldLabel);
            projectName = EditorGUILayout.TextField("Project Name: ", projectName);
            
            GUILayout.Space(20);

            if (GUILayout.Button("Generate!", GUILayout.Height(30))) 
            {
                CreateAllFolders();
                this.Close();
            }
        }
    }
}