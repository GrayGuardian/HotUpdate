using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

public class FileUtil : Singleton<FileUtil>
{
    /// <summary>
    /// 读取文件 字节流
    /// </summary>
    /// <param name="path">文件路径</param>
    /// <returns></returns>
    public byte[] ReadBytes(string path)
    {
        if (!File.Exists(path))
            return new byte[] { };
        return File.ReadAllBytes(path);
    }
    /// <summary>
    /// 读取文件 字符串
    /// </summary>
    /// <param name="path">文件路径</param>
    /// <param name="encoding">编码</param>
    /// <returns></returns>
    public string ReadString(string path, Encoding encoding = null)
    {
        encoding = encoding == null ? Encoding.UTF8 : encoding;
        return encoding.GetString(ReadBytes(path));
    }
    /// <summary>
    /// 写到文件 字节流
    /// </summary>
    /// <param name="path">文件路径</param>
    /// <param name="data">数据</param>
    /// <returns></returns>
    public void WriteBytes(string path, byte[] data)
    {
        FileInfo fileInfo = new FileInfo(path);
        DirectoryInfo directoryInfo = fileInfo.Directory;
        if (!Directory.Exists(directoryInfo.ToString()))
        {
            Directory.CreateDirectory(directoryInfo.ToString());
        }
        if (!File.Exists(path))
        {
            File.Create(path).Dispose();
        }
        File.WriteAllBytes(path, data);
    }
    /// <summary>
    /// 写到文件 字符串
    /// </summary>
    /// <param name="path">文件路径</param>
    /// <param name="data">数据</param>
    /// <param name="encoding">编码</param>
    /// <returns></returns>
    public void WriteString(string path, string data, Encoding encoding = null)
    {
        encoding = encoding == null ? Encoding.UTF8 : encoding;
        WriteBytes(path, encoding.GetBytes(data));
    }
    /// <summary>
    /// 获取所有子文件（包括子文件夹内）
    /// </summary>
    /// <param name="rootPath"></param>
    /// <param name="searchPattern"></param>
    /// <returns></returns>
    public FileInfo[] GetChildFiles(string rootPath, string searchPattern = "*")
    {

        searchPattern = new DirectoryInfo(searchPattern).Name;
        if (!Directory.Exists(rootPath))
        {
            return new FileInfo[] { };
        }
        Action<string, List<FileInfo>> getFiles = null;
        getFiles = (path, list) =>
        {
            if (list == null) list = new List<FileInfo>();

            DirectoryInfo root = new DirectoryInfo(path);

            foreach (var val in root.GetFiles(searchPattern))
            {
                list.Add(val);
            }
            foreach (var val in root.GetDirectories("*"))
            {
                getFiles(val.FullName, list);
            }
        };
        List<FileInfo> fileInfos = new List<FileInfo>();
        getFiles(rootPath, fileInfos);
        return fileInfos.ToArray();
    }
    /// <summary>
    /// 获取子文件（包括子文件夹内）
    /// </summary>
    /// <param name="rootPath"></param>
    /// <param name="searchPattern"></param>
    /// <returns></returns>
    public FileInfo GetChildFile(string rootPath, string searchPattern)
    {
        FileInfo[] fileInfos = GetChildFiles(rootPath, searchPattern);
        if (fileInfos.Length > 0)
        {
            return fileInfos[0];
        }
        return null;
    }
    /// <summary>
    /// 获取字节集哈希值
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    public string ComputeHash(byte[] buffer)
    {
        if (buffer == null || buffer.Length < 1)
            return "";
        MD5 md5 = MD5.Create();
        byte[] hash = md5.ComputeHash(buffer);
        StringBuilder sb = new StringBuilder();
        foreach (var b in hash)
            sb.Append(b.ToString("x2"));
        return sb.ToString();
    }
    /// <summary>
    /// 获取文件哈希值
    /// </summary>
    /// <returns></returns>
    public string ComputeHash(string filePath)
    {
        try
        {
            return ComputeHash(ReadBytes(filePath));
        }
        catch (Exception e)
        {
            return "";
        }
    }
    /// <summary>
    /// 移动文件，路径不存在则创建目录
    /// </summary>
    /// <returns></returns>
    public bool MoveTo(string filePath, string savePath, bool overwrite = true)
    {
        if (!File.Exists(filePath)) return false;
        FileInfo fileInfo = new FileInfo(filePath);
        FileInfo saveInfo = new FileInfo(savePath);
        if (saveInfo.Name == "")
        {
            savePath += fileInfo.Name;
            saveInfo = new FileInfo(savePath);
        }
        if (fileInfo.FullName == saveInfo.FullName)
        {
            return false;
        }
        if (!File.Exists(saveInfo.DirectoryName))
        {
            Directory.CreateDirectory(saveInfo.DirectoryName);
        }
        //移动位置文件是否存在
        bool isExists;
        isExists = File.Exists(saveInfo.FullName) || Directory.Exists(saveInfo.FullName);
        if (isExists && !overwrite) return false;
        if (isExists && overwrite)
        {
            if (File.Exists(saveInfo.FullName))
                File.Delete(saveInfo.FullName);
            else
                Directory.Delete(saveInfo.FullName, true);
        }
        fileInfo.MoveTo(saveInfo.FullName);
        return true;
    }
    /// <summary>
    /// 复制文件，路径不存在则创建目录
    /// </summary>
    /// <returns></returns>
    public bool CopyTo(string filePath, string savePath, bool overwrite = true)
    {
        if (!File.Exists(filePath)) return false;
        if (File.Exists(savePath) && !overwrite) return false;
        string dirPath = Path.GetDirectoryName(savePath);
        if (!File.Exists(dirPath))
        {
            //UnityEngine.Debug.Log("目录不存在，创建目录：" + dirPath);
            Directory.CreateDirectory(dirPath);
        }
        File.Copy(filePath, savePath, overwrite);
        return true;
    }
    /// <summary>
    /// 创建目录
    /// </summary>
    /// <param name="path"></param>
    public void CreateDirectory(string path)
    {
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
    }
    public void DeleteFileInfo(FileInfo fileInfo)
    {
        fileInfo.Delete();
    }
    public void DeleteFile(string filePath)
    {
        new FileInfo(filePath).Delete();
    }
}