using UnityEngine;
using System.Collections;
using UnityEditor;
using System.IO;
using System.Collections.Generic;
using System;

public class UnityBoneTransform
{
    //public List<FMeshBoneInfo> SkeletonInfo = new List<FMeshBoneInfo>();
    //public List<List<FMeshBoneInfo>> animationFames;

    static void AddToSkeletonInfo(Transform tm, int InParentIndex, List<FMeshBoneInfo> SkeletonInfo)
    {
        for (int i = 0; i < tm.childCount; i++)
        {
            Transform ctm = tm.GetChild(i);
            FMeshBoneInfo aMeshBoneInfo = new FMeshBoneInfo();
            aMeshBoneInfo.BoneTransform.position = ctm.localPosition;
            aMeshBoneInfo.BoneTransform.rotation = ctm.localRotation.eulerAngles;
            aMeshBoneInfo.BoneTransform.scale = ctm.localScale;
            aMeshBoneInfo.ParentIndex = InParentIndex;
            aMeshBoneInfo.Name = ctm.gameObject.name;
            SkeletonInfo.Add(aMeshBoneInfo);
            AddToSkeletonInfo(ctm, SkeletonInfo.Count - 1, SkeletonInfo);
        }
    }

    public static void CacheSkeletonInfo(Transform root, List<FMeshBoneInfo> SkeletonInfo)
    {
        FMeshBoneInfo aMeshBoneInfo = new FMeshBoneInfo();
        aMeshBoneInfo.BoneTransform.position = root.localPosition;
        aMeshBoneInfo.BoneTransform.rotation = root.localRotation.eulerAngles;
        aMeshBoneInfo.BoneTransform.scale = root.localScale;
        aMeshBoneInfo.ParentIndex = 0;
        aMeshBoneInfo.Name = root.gameObject.name;
        SkeletonInfo.Add(aMeshBoneInfo);
        AddToSkeletonInfo(root, 0, SkeletonInfo);
    }

    static void CacheAnimationFrame(ref AnimSequence AnimSeq, Transform root)
    {
        List<FMeshBoneInfo> frame = new List<FMeshBoneInfo>();
        CacheSkeletonInfo(root, frame);
        AnimSeq.animationFames.Add(frame);
    }

    static public void CatchSkeleton(Transform root, ref List<FMeshBoneInfo> InOutSkeletonInfo)
    {
        CacheSkeletonInfo(root, InOutSkeletonInfo);
    }

    static public AnimSequence CatchAnimationClip(AnimationClip InClip, Transform root)
    {
        float InCliplength = InClip.length;
        //InCliplength = 0;
        AnimSequence retAnimSequence = new AnimSequence();
        retAnimSequence.NumFrames = (int)Mathf.Floor(InCliplength / (InClip.frameRate / 1000)) + 1;
        //if (retAnimSequence.NumFrames <= 1)
        //    return null;

        retAnimSequence.SequenceLength = InClip.length;
        if (retAnimSequence.NumFrames - 1 != 0)
            retAnimSequence.StepFrame = InClip.length / (retAnimSequence.NumFrames - 1);
        else
            retAnimSequence.StepFrame = 0;
        retAnimSequence.animationFames = new List<List<FMeshBoneInfo>>();
        
        for (int i = 0; i < retAnimSequence.NumFrames; i++)
        {
            float sampleTime = retAnimSequence.StepFrame * i;
            if(i == (retAnimSequence.NumFrames - 1))
            {
                sampleTime = InClip.length;
            }
            InClip.SampleAnimation(root.gameObject, sampleTime);
            CacheAnimationFrame(ref retAnimSequence, root);
        }
        return retAnimSequence;
    }
};

public class Assetload : MonoBehaviour {

    public Animator anime;
    public Animation ami;
    public GameObject temp;
    public SkinnedMeshRenderer skin;
    AssetBundleController controller = new AssetBundleController();
    AnimSequence AniSeq = new AnimSequence();
    public float fSampleTime = 0.0f;
    private bool bSampleAniamtion = false;
    public Vector3 DebugVector = new Vector3();

    public List<FMeshBoneInfo> orginSkeletonInfo;
    // Use this for initialization
    void Start ()
    {
	    anime = GetComponentInChildren<Animator>();
        //ami = temp.GetComponent<Animation>();
    }
	
	// Update is called once per frame
	void Update () {
        if (bSampleAniamtion)
        {
            List<AnimationClip> aniList = new List<AnimationClip>();
            foreach (var v in anime.runtimeAnimatorController.animationClips)
            {
                aniList.Add(v);
            }
            aniList[0].SampleAnimation(gameObject, fSampleTime);
        }
    }

    string file_path = "";
    StreamWriter statisticsStreamWriter;
    public bool bWriteStatisticsHead = true;
    Dictionary<string, List<string>> switchRoomStatisticInfo = new Dictionary<string, List<string>>();

    float filterFloat(float inValue)
    {
        if (inValue < 0.000001)
            return 0;
        return inValue;
    }
    void StatisticsGenerateDataBegin(List<FMeshBoneInfo> skeletonInfo)
    {

        file_path = "D:/geixiaoyandetongji" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".txt";
        if (!File.Exists(file_path))
        {
            statisticsStreamWriter = File.CreateText(file_path);
        }
        else
        {
            statisticsStreamWriter = File.AppendText(file_path);
        }

        foreach(var v in skeletonInfo)
        {
            string strline = "";
            strline += v.Name;
            strline += '\t';
            strline += "(" + filterFloat( v.BoneTransform.scale.x) + "," + filterFloat(v.BoneTransform.scale.y) + "," + filterFloat(v.BoneTransform.scale.z) + ")";
            statisticsStreamWriter.WriteLine(strline);
        }

        statisticsStreamWriter.Close();
    }

    void UpdateTransformFromMeshBoneList(List<FMeshBoneInfo> skeletonInfo)
    {
        foreach(var v in skeletonInfo)
        {
            GameObject obj = GameObject.Find(v.Name);
            obj.transform.localPosition = v.BoneTransform.position;
            obj.transform.localRotation = Quaternion.Euler(v.BoneTransform.rotation);
            obj.transform.localScale = v.BoneTransform.scale;

        }
    }

    private void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 150, 50), "动画加载"))
        {
            controller.OpenFromFile(Application.streamingAssetsPath, "pose");
            anime.runtimeAnimatorController = controller.LoadAsset<RuntimeAnimatorController>("AC_Edit_F");
            anime.Stop();

            List<FMeshBoneInfo> SkeletonInfo = new List<FMeshBoneInfo>();
            UnityBoneTransform.CatchSkeleton(gameObject.transform, ref SkeletonInfo);
            orginSkeletonInfo = SkeletonInfo;
            StatisticsGenerateDataBegin(SkeletonInfo);
        }

        if (GUI.Button(new Rect(170, 10, 150, 50), "动画导出"))
        {

            controller.OpenFromFile(Application.streamingAssetsPath, "pose");
            anime.runtimeAnimatorController = controller.LoadAsset<RuntimeAnimatorController>("AC_Edit_F");
            anime.Stop();
            //anime.Play("tachi_pose_12");
            AnimatorClipInfo [] acinfo = anime.GetCurrentAnimatorClipInfo(0);
            foreach(var v in acinfo)
            {
                Debug.Log(v.clip.name);
            }

            List<AnimationClip> aniList = new List<AnimationClip>();
            foreach (var v in anime.runtimeAnimatorController.animationClips)
            {
                aniList.Add(v);
                Debug.Log(v + " " + v.length + " " + v.frameRate);
            }

            AnimSequence anim = UnityBoneTransform.CatchAnimationClip(aniList[8], gameObject.transform);
            List<FMeshBoneInfo> SkeletonInfo = new List<FMeshBoneInfo>();
            UnityBoneTransform.CatchSkeleton(gameObject.transform, ref SkeletonInfo);
            MyExport aMyExport = new MyExport();
            aMyExport.CreateDocument();
            aMyExport.ExportAnimSequence(anim, SkeletonInfo);
            aMyExport.WriteToFile("E:/1.fbx");

        }

        if (GUI.Button(new Rect(350, 10, 150, 50), "动画采样"))
        {
            List<AnimationClip> aniList = new List<AnimationClip>();
            foreach (var v in anime.runtimeAnimatorController.animationClips)
            {
                aniList.Add(v);
                Debug.Log(v + " " + v.length + " " + v.frameRate);
            }

            aniList[0].SampleAnimation(gameObject, fSampleTime);

            List<FMeshBoneInfo> SkeletonInfo = new List<FMeshBoneInfo>();
            UnityBoneTransform.CatchSkeleton(gameObject.transform, ref SkeletonInfo);
            StatisticsGenerateDataBegin(SkeletonInfo);

            Debug.Log(GameObject.Find("cf_J_Hips").transform.localRotation.eulerAngles);
            bSampleAniamtion = true;
        }


        if (GUI.Button(new Rect(620, 10, 150, 50), "重置T-Pose"))
        {
            UpdateTransformFromMeshBoneList(orginSkeletonInfo);
        }
        
    }
}
