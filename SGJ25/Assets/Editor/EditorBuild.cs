using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;
using System.IO;

public class MyBuildPostprocessor
{
    [PostProcessBuildAttribute(10000)]
    public static void OnPostprocessBuild(BuildTarget target, string pathToBuiltProject)
    {
        FileUtil.DeleteFileOrDirectory(Path.GetDirectoryName(pathToBuiltProject) + "/Sound");
        FileUtil.CopyFileOrDirectory(Application.dataPath + "/../Sound", Path.GetDirectoryName(pathToBuiltProject) + "/Sound");
    }
}
