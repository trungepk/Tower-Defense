using System;
using System.IO;
using UnityEditor;
using UnityEngine;

public class ProjectInfo
{

    [MenuItem("CustomEditor/ExportProjectProperties")]
    static void ExportProjectProperties()
    {
        DirectoryInfo directoryInfo = new DirectoryInfo(Directory.GetCurrentDirectory());
        long byteCount = GetProjectSize(directoryInfo);
        Debug.Log("Project size is " + byteCount + " byte");
        float mbCount = ByteToMb(byteCount);
        mbCount = (float)Math.Round(mbCount, 2);
        Debug.Log("Project size is " + mbCount + " Mb");
    }

    private static long GetProjectSize(DirectoryInfo directoryInfo)
    {
        long size = 0;
        FileInfo[] files = directoryInfo.GetFiles();
        foreach (var item in files)
        {
            size += item.Length;
        }
        DirectoryInfo[] subdirectories = directoryInfo.GetDirectories();
        foreach (var item in subdirectories)
        {
            size += GetProjectSize(item);
        }
        return size;
    }

    private static float ByteToMb(long byteCount)
    {
        return byteCount / Mathf.Pow(1024, 2);
    }
}
