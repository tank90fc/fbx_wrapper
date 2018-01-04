using UnityEngine;
using System.Collections;
using UnityEditor;
using System.IO;

public class Copy
{
    static AssetBundleController s_controller = new AssetBundleController();
    [MenuItem("Assets/Copy")]
    static void AssetCopy()
    {

        s_controller.OpenFromFile(Application.streamingAssetsPath, "pose");
        RuntimeAnimatorController rac = s_controller.LoadAsset<RuntimeAnimatorController>("AC_Edit_F");
        AnimationClip amiclip = rac.animationClips[1];
        //anime.runtimeAnimatorController = s_controller.LoadAsset<RuntimeAnimatorController>("AC_Edit_F");
        //Runt
        //anime.runtimeAnimatorController.animationClips
        //ami.clip = anime.runtimeAnimatorController.animationClips[1];
        string tempExportedClip = "Assets/tempClip.anim";
        string exportPath = "Assets/Clone.anim";
        var copyClip = Object.Instantiate(amiclip);
        AssetDatabase.CreateAsset(copyClip, tempExportedClip);
        File.Copy(tempExportedClip, exportPath, true);
        File.Delete(tempExportedClip);

        // AssetDatabaseリフレッシュ
        AssetDatabase.Refresh();
    }
}