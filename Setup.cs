//script para criar pastas automaticamente
//para abri-lo procure na toolbar o nome (Tool-Setup-Creat Default Folders)
//todas as pastas foram criadas
//trillobit3s@gmail.com 

using System.IO;
using UnityEngine;
using static Syatem.IO.Path;
using static UnityEditor.AssetDatabase;

public static class Setup
{
	public static void CreateDefaultFolders()
	{
		Folders.CreateDefault("_Project", "Animations", "Art", "Materials", "Prefabs", "ScriptableObjects", "Scripts", "Settings");
		Refresh();
	}
			
	static class Folders
	{
		public static void CreateDefault(string root, params string[] folders)
		{
			var fullpath = Combine(Application.dataPath, root);
			foreach(var folder in folders)
			{
				var path = Combine(fullpath, folder);
				if(!Directory.Exits(path))
				{
					CreateDictory(path);	
				}
			}
		}
	}		
}