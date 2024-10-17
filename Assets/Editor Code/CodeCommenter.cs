using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using System.IO;
using System.Linq;

public class CodeCommenter : EditorWindow
{
    private string folderPath = "Assets"; // Default folder path
    private Label folderPathLabel; // Declare at class level
    private ScrollView resultsList; // Declare at class level
    private bool hasSelectedAFolder = false;
    private Button generateCommentsButton;

    [MenuItem("Tools/Code Commenter")]
    public static void ShowExample()
    {
        var wnd = GetWindow<CodeCommenter>();
        wnd.titleContent = new GUIContent("Code Commenter");
    }

    public void CreateGUI()
    {
        // Create a root container for all UI elements in a vertical layout.
        var root = new VisualElement
        {
            style =
            {
                paddingLeft = 10,
                paddingTop = 10,
                flexDirection = FlexDirection.Column
            }
        };

        // Add Title Label
        var titleLabel = new Label("Find C# Scripts")
        {
            style = { unityFontStyleAndWeight = FontStyle.Bold, marginBottom = 10 }
        };
        root.Add(titleLabel);

        // Add Button to Select Folder
        var selectFolderButton = new Button(() => SelectFolder()) { text = "Select Folder" };
        selectFolderButton.style.marginBottom = 5;
        root.Add(selectFolderButton);

        // Initialize folderPathLabel and add it to the root container
        folderPathLabel = new Label($"Selected Folder: {folderPath}")
        {
            style = { marginBottom = 5 }
        };
        root.Add(folderPathLabel);

        // Add Button to Find C# Files
        var findScriptsButton = new Button(() => FindCSharpFilesInFolder(folderPath)) { text = "Find C# Files" };
        root.Add(findScriptsButton);

        generateCommentsButton = new Button(() => GenerateComments()) { text = "Generate Comments" };
        generateCommentsButton.SetEnabled(false);
        root.Add(generateCommentsButton);

        // Initialize resultsList and add it to the root container
        resultsList = new ScrollView { style = { flexGrow = 1, marginTop = 10 } };
        root.Add(resultsList);

        // Attach the root container to the window's visual element.
        rootVisualElement.Add(root);
    }

    // Folder Selection Logic
    private void SelectFolder()
    {
        string selectedPath = EditorUtility.OpenFolderPanel("Select Folder", "Assets", "");
        if (!string.IsNullOrEmpty(selectedPath))
        {
            folderPath = "Assets" + selectedPath.Replace(Application.dataPath, "");
            folderPathLabel.text = $"Selected Folder: {folderPath}";
        }
    }

    // Find C# Files Logic
    private void FindCSharpFilesInFolder(string path)
    {
        resultsList.Clear();

        if (!Directory.Exists(path))
        {
            Debug.LogError("Folder does not exist: " + path);
            return;
        }

        var csharpFiles = Directory.GetFiles(path, "*.cs", SearchOption.AllDirectories);

        if (csharpFiles.Length == 0)
        {
            var noFilesLabel = new Label("No C# files found.");
            resultsList.Add(noFilesLabel);
            Debug.Log("No C# files found in folder: " + path);
        }
        else
        {
            Debug.Log($"Found {csharpFiles.Length} C# file(s) in folder: {path}");
            foreach (var file in csharpFiles)
            {
                var fileLabel = new Label(file);
                resultsList.Add(fileLabel);
            }
        }
        generateCommentsButton.SetEnabled(true);
        hasSelectedAFolder = true;
    }

    private void GenerateComments()
    {
        if (hasSelectedAFolder)
        {

        }
        else
        {
            Debug.LogError("No folder seleceted");
        }
    }
}
