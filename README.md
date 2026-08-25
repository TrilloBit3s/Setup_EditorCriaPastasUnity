# Setup_EditorCriaPastasUnity 

# Setup_EditorCriaPastasUnity com Markdown clássico

Script para criar pastas automaticamente no Unity. Todas as pastas necessárias para iniciar seu projeto são geradas com apenas um clique.

## Como Usar
Para abri-lo, procure na barra de ferramentas (toolbar) do Unity pelo caminho: 
**Tools > Setup > Create Default Folders**

---

## 🛠️ Instruções de Instalação

### 1. Criar o Arquivo do Script
1. Clique com o botão direito dentro da pasta **Editor** no painel *Project* do Unity.
2. Vá em **Create > C# Script**.
3. Nomeie o arquivo exatamente como **`CreateFolders`** (sem espaços).

### 2. Colocar o Código Corrigido
1. Dê um duplo clique no arquivo para abri-lo no seu editor de código (como Visual Studio ou VS Code).
2. Apague todo o código padrão que veio nele.
3. Copie o código abaixo e cole dentro do arquivo.
4. Salve o arquivo (`Ctrl + S` ou `Cmd + S`) e volte para o Unity.

### 3. Executar a Ferramenta
1. Espere o Unity carregar o script por alguns segundos.
2. Na barra de menus superior do Unity, clique em **Tools > Setup > Create Default Folders**.
3. Uma janela pop-up vai aparecer. Digite o nome do seu projeto e clique em **Generate!**.

As pastas serão criadas automaticamente dentro da estrutura correta que você planejou.

---

## ⚙️ Salvar e Carregar Configurações do Gerenciador
Use predefinições (Presets) para uma janela do Gerenciador para que as configurações possam ser reutilizadas. Por exemplo, se você planeja reaplicar as mesmas tags, camadas ou configurações de física, as predefinições podem reduzir o tempo de configuração para o seu próximo projeto.

---

## 📜 Normas de Código

```csharp
using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
using System.IO;

public class CreateFolders : EditorWindow 
{
    private static string projectName = "PROJECT_NAME";

    // Alterado para corresponder à toolbar descrita no README
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
```
<p>trillobit3s@gmail.com</p> 
