using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;

public class DublicatAssetChecker : EditorWindow
{
    [MenuItem("Tools/Duplicate Assets Checker")]
    public static void ShowWindow()
    {
        var window = GetWindow<DublicatAssetChecker>();
        window.titleContent = new GUIContent("Duplicate Assets Checker");
        window.Show();
    }

    private string folderPath = "Assets/YourFolder";

    void OnGUI()
    {
        GUILayout.Label("Duplicate Assets Checker", EditorStyles.boldLabel);
        folderPath = EditorGUILayout.TextField("Folder Path", folderPath);

        if (GUILayout.Button("Check for Duplicates"))
        {
            CheckForDuplicateAssets(folderPath);
        }
    }

    private void CheckForDuplicateAssets(string path)
    {
        if (!Directory.Exists(path))
        {
            Debug.LogError("Path does not exist: " + path);
            return;
        }

        Dictionary<string, List<string>> fileHashes = new Dictionary<string, List<string>>();

        string[] files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);
        foreach (string file in files)
        {
            if (file.EndsWith(".meta")) continue;

            string hash = GetFileHash(file);

            if (!fileHashes.ContainsKey(hash))
            {
                fileHashes[hash] = new List<string>();
            }

            fileHashes[hash].Add(file);
        }

        foreach (var kvp in fileHashes)
        {
            if (kvp.Value.Count > 1)
            {
                Debug.Log("Duplicate files found with hash " + kvp.Key + ":");
                foreach (var file in kvp.Value)
                {
                    Debug.Log(file);
                }
            }
        }
    }

    private string GetFileHash(string filePath)
    {
        using (var md5 = MD5.Create())
        {
            using (var stream = File.OpenRead(filePath))
            {
                byte[] hash = md5.ComputeHash(stream);
                return System.BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
            }
        }
    }
}