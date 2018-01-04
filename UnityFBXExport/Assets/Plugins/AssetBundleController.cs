using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

public class AssetBundleController
{
    public AssetBundle assetBundle;

    public AssetBundleController()
    {
        this.assetBundleName = string.Empty;
        this.directory = string.Empty;
        this.isSimulate = false;
    }

    public AssetBundleController(bool isSimulate)
    {
        this.assetBundleName = string.Empty;
        this.directory = string.Empty;
        this.isSimulate = isSimulate;
    }

    public void Close(bool unloadAllLoadedObjects = false)
    {
        try
        {
            if (assetBundle != null)
            {
                assetBundle.Unload(unloadAllLoadedObjects);
            }
        }
        catch (Exception exception)
        {
            UnityEngine.Debug.LogError(this.assetBundleName + ":" + exception);
        }
    }

    ~AssetBundleController()
    {
        if (this.isOpened)
        {
            UnityEngine.Debug.LogError("can not close:" + this.assetBundleName);
        }
    }

    public T LoadAndInstantiate<T>(string assetName) where T : UnityEngine.Object
    {
        T original = this.LoadAsset<T>(assetName);
        if (original != null)
        {
            return UnityEngine.Object.Instantiate<T>(original);
        }
        return null;
    }

    public T LoadAsset<T>(string assetName) where T : UnityEngine.Object
    {
        if (this.assetBundle != null)
        {
            return this.assetBundle.LoadAsset<T>(assetName);
        }
        return null;
    }

    public static AssetBundleController New_OpenFromFile(string directory, string assetBundleName)
    {
        AssetBundleController controller = new AssetBundleController();
        if (controller.OpenFromFile(directory, assetBundleName))
        {
            return controller;
        }
        return null;
    }

    public bool OpenFromFile(string directory, string assetBundleName)
    {
        this.directory = directory;
        this.assetBundleName = assetBundleName;
        string str = string.Empty;
        int length = assetBundleName.LastIndexOf("/");
        if (length != -1)
        {
            str = "/" + assetBundleName.Substring(0, length);
            assetBundleName = assetBundleName.Remove(0, length + 1);
        }
        string path = this.directory + "/" + this.assetBundleName;
        this.assetBundle = null;
        if (File.Exists(path))
        {
            this.assetBundle = AssetBundle.LoadFromFile(path);
        }
        else
        {
            UnityEngine.Debug.Log("can not find assetbundle：" + path);
        }
        return (this.assetBundle != null);
    }

    public string assetBundleName { get; private set; }

    public string directory { get; private set; }

    public bool isOpened
    {
        get
        {
            return this.assetBundle != null;
        }
    } 

    public bool isSimulate { get; private set; }
}

