using System;
using System.Collections.Generic;
using Fbx;
using UnityEngine;

public struct FMeshBoneInfo
{
    // Bone's name.
    public string Name;
    public int ParentIndex;
    public BoneTransformInfo BoneTransform;
};

public struct BoneTransformInfo
{
    public Vector3 position;
    public Vector3 rotation;
    public Vector3 scale;
};


public class AnimSequence
{
    public int NumFrames = 0;
    public float FrameRate = 0;
    public float StepFrame = 0;
    public float SequenceLength = 0;
    public List<List<FMeshBoneInfo>> animationFames;
};

class MyExport
{
    public FbxManager SdkManager = null;
    public FbxScene Scene = null;
    public bool bForceFrontXAxis = false;
    public FbxAnimStack AnimStack;
    public FbxAnimLayer AnimLayer;
    public const float DEFAULT_SAMPLERATE = 30.0f;

    public MyExport()
    {
        Init();
    }

    void Init()
    {
        SdkManager = FbxManager.Create();
        FbxIOSettings ios = FbxIOSettings.Create(SdkManager, "IOSRoot");
        SdkManager.SetIOSettings(ios);
    //    EXP_FBX = "Material";
    //public string EXP_ADV_OPT_GRP = "Material";
    //public string IOSN_EXPORT = "Export";
    //public string IOSN_FBX = "Fbx";
    //public string IOSN_MATERIAL = "Material";
    //public string EXP_FBX_MATERIAL = EXP_FBX + " | " + IOSN_MATERIAL;

    }

public void Clear()
    {
        CloseDocument();
        SdkManager.Destroy();
    }

    public void CreateDocument()
    {
        Scene = FbxScene.Create(SdkManager, "");

        FbxDocumentInfo SceneInfo = FbxDocumentInfo.Create(SdkManager, "SceneInfo");

        SceneInfo.mTitle = new FbxString("Unreal FBX Exporter");
        SceneInfo.mSubject = new FbxString("Export FBX meshes from Unreal");
        SceneInfo.Original_ApplicationVendor.Set(new FbxString("Epic Games"));
        SceneInfo.Original_ApplicationName.Set(new FbxString("Unreal Engine"));
        SceneInfo.Original_ApplicationVersion.Set(new FbxString("4.18"));
        SceneInfo.LastSaved_ApplicationVendor.Set(new FbxString("Epic Games"));
        SceneInfo.LastSaved_ApplicationName.Set(new FbxString("Unreal Engine"));
        SceneInfo.LastSaved_ApplicationVersion.Set(new FbxString("4.18"));
        
        FbxAxisSystem.EFrontVector FrontVector = (FbxAxisSystem.EFrontVector)(0 - FbxAxisSystem.EFrontVector.eParityOdd);
        if (bForceFrontXAxis)
            FrontVector = FbxAxisSystem.EFrontVector.eParityEven;

        FbxAxisSystem UnrealZUp = new FbxAxisSystem(FbxAxisSystem.EUpVector.eZAxis, FrontVector, FbxAxisSystem.ECoordSystem.eRightHanded);
        //const FbxAxisSystem UnrealZUp(FbxAxisSystem.EUpVector, FrontVector, FbxAxisSystem::eRightHanded);
        Scene.GetGlobalSettings().SetAxisSystem(FbxAxisSystem.Max);
        Scene.GetGlobalSettings().SetOriginalUpAxis(FbxAxisSystem.Max);
        Scene.GetGlobalSettings().SetSystemUnit(FbxSystemUnit.cm);

        Scene.SetSceneInfo(SceneInfo);

        // setup anim stack
        AnimStack = FbxAnimStack.Create(Scene, "Unreal Take");
        //KFbxSet<KTime>(AnimStack.LocalStart, KTIME_ONE_SECOND);
        AnimStack.Description.Set((new FbxString("Animation Take for Unreal.")));

        // this take contains one base layer. In fact having at least one layer is mandatory.
        AnimLayer = FbxAnimLayer.Create(Scene, "Base Layer");
        AnimStack.AddMember(AnimLayer);
        //if(Mathf)

    }


    public FbxNode CreateSkeleton(List<FMeshBoneInfo> boneInfos, ref List<FbxNode> BoneNodes)
    {
        if (boneInfos == null ||boneInfos.Count == 0)
            return null;

        for(int BoneIndex = 0; BoneIndex < boneInfos.Count; BoneIndex++)
        {
            FMeshBoneInfo CurrentBone = boneInfos[BoneIndex];
            FbxSkeleton SkeletonAttribute = FbxSkeleton.Create(Scene, CurrentBone.Name);
            if (BoneIndex != 0)
            {
                SkeletonAttribute.SetSkeletonType(FbxSkeleton.EType.eLimbNode);
                //SkeletonAttribute.Size.Set(1.0);
            }
            else
            {
                SkeletonAttribute.SetSkeletonType(FbxSkeleton.EType.eRoot);
                //SkeletonAttribute.Size.Set(1.0);
            }

            // Create the node
            FbxNode BoneNode = FbxNode.Create(Scene, CurrentBone.Name);
            BoneNode.SetNodeAttribute(SkeletonAttribute);

            FbxDouble3 LocalPos = FbxDataConverter.ConvertToFbxPos(CurrentBone.BoneTransform.position);
            FbxDouble3 LocalRot = FbxDataConverter.ConvertToFbxRot(CurrentBone.BoneTransform.rotation);
            FbxDouble3 LocalScale = FbxDataConverter.ConvertToFbxScale(CurrentBone.BoneTransform.scale);

            BoneNode.LclTranslation.Set(LocalPos);
            BoneNode.LclRotation.Set(LocalRot);
            BoneNode.LclScaling.Set(LocalScale);

            if (BoneIndex != 0)
            {
                BoneNodes[CurrentBone.ParentIndex].AddChild(BoneNode);
            }

            BoneNodes.Add(BoneNode);
        }

        return BoneNodes[0];

    }

    public FbxNode ExportAnimSequence(AnimSequence AnimSeq, List<FMeshBoneInfo> boneInfos)
    {
        if (Scene == null)
        {
            return null;
        }
        List<FbxNode> BoneNodes = new List<FbxNode>();
        FbxNode RootNode = Scene.GetRootNode();
        FbxNode SkeletonRootNode = CreateSkeleton(boneInfos,ref BoneNodes);
        RootNode.AddChild(SkeletonRootNode);

        ExportAnimSequenceToFbx(AnimSeq, ref BoneNodes, AnimLayer, 0.0f, 0.0f, 1.0f, 0.0f);
        CorrectAnimTrackInterpolation(ref BoneNodes, AnimLayer);
        return SkeletonRootNode;

    }
    static bool IsNearlyEqual(float A, float B, float ErrorTolerance)
    {
        return Mathf.Abs(A - B) <= ErrorTolerance;
    }

    void CorrectAnimTrackInterpolation(ref List<FbxNode> BoneNodes, FbxAnimLayer InAnimLayer)
    {
        // Add the animation data to the bone nodes
        for (int BoneIndex = 0; BoneIndex < BoneNodes.Count; ++BoneIndex)
        {
            FbxNode CurrentBoneNode = BoneNodes[BoneIndex];

            // Fetch the AnimCurves
            FbxAnimCurve[] Curves = new FbxAnimCurve[3];
            Curves[0] = CurrentBoneNode.LclRotation.GetCurve(InAnimLayer, "X", true);
            Curves[1] = CurrentBoneNode.LclRotation.GetCurve(InAnimLayer, "Y", true);
            Curves[2] = CurrentBoneNode.LclRotation.GetCurve(InAnimLayer, "Z", true);

            for (int CurveIndex = 0; CurveIndex < 3; ++CurveIndex)
            {
                FbxAnimCurve CurrentCurve = Curves[CurveIndex];
                CurrentCurve.KeyModifyBegin();

                float CurrentAngleOffset = 0.0f;
                for (int KeyIndex = 1; KeyIndex < CurrentCurve.KeyGetCount(); ++KeyIndex)
                {
                    float PreviousOutVal = CurrentCurve.KeyGetValue(KeyIndex - 1);
                    float CurrentOutVal = CurrentCurve.KeyGetValue(KeyIndex);

                    float DeltaAngle = (CurrentOutVal + CurrentAngleOffset) - PreviousOutVal;

                    if (DeltaAngle >= 180)
                    {
                        CurrentAngleOffset -= 360;
                    }
                    else if (DeltaAngle <= -180)
                    {
                        CurrentAngleOffset += 360;
                    }

                    CurrentOutVal += CurrentAngleOffset;

                    CurrentCurve.KeySetValue(KeyIndex, CurrentOutVal);
                }

                CurrentCurve.KeyModifyEnd();
            }
        }
    }

    void ExportAnimSequenceToFbx(AnimSequence AnimSeq,
                                    ref List<FbxNode> BoneNodes,
                                     FbxAnimLayer InAnimLayer,
                                     float AnimStartOffset,
                                     float AnimEndOffset,
                                     float AnimPlayRate,
                                     float StartTime)
    {
        if (AnimSeq.SequenceLength == 0)
            return;

        FbxTime ExportedStartTime = new FbxTime();
        FbxTime ExportedStopTime = new FbxTime();
        if (IsNearlyEqual(AnimSeq.FrameRate, DEFAULT_SAMPLERATE, 1.0f))
        {
            FbxTime.SetGlobalTimeMode(FbxTime.EMode.eFrames30);
            //FbxTime.SetGlobalTimeMode(FbxTime.EMode.eFrames30);
        }
        else
        {
            FbxTime.SetGlobalTimeMode(FbxTime.EMode.eCustom, AnimSeq.FrameRate);
            //ExportedStopTime.SetGlobalTimeMode(FbxTime::eCustom, FrameRate);
        }

        ExportedStartTime.SetSecondDouble(0.0f);
        ExportedStopTime.SetSecondDouble(AnimSeq.SequenceLength);
        FbxTimeSpan ExportedTimeSpan = new FbxTimeSpan();
        ExportedTimeSpan.Set(ExportedStartTime, ExportedStopTime);
        AnimStack.SetLocalTimeSpan(ExportedTimeSpan);


        // Add the animation data to the bone nodes
        for (int BoneIndex = 0; BoneIndex < BoneNodes.Count; ++BoneIndex)
        {
            FbxNode CurrentBoneNode = BoneNodes[BoneIndex];
            // Create the AnimCurves
            int NumberOfCurves = 9;
            FbxAnimCurve[] Curves = new FbxAnimCurve[NumberOfCurves];

            Curves[0] = CurrentBoneNode.LclTranslation.GetCurve(InAnimLayer, "X", true);
            Curves[1] = CurrentBoneNode.LclTranslation.GetCurve(InAnimLayer, "Y", true);
            Curves[2] = CurrentBoneNode.LclTranslation.GetCurve(InAnimLayer, "Z", true);

            Curves[3] = CurrentBoneNode.LclRotation.GetCurve(InAnimLayer, "X", true);
            Curves[4] = CurrentBoneNode.LclRotation.GetCurve(InAnimLayer, "Y", true);
            Curves[5] = CurrentBoneNode.LclRotation.GetCurve(InAnimLayer, "Z", true);

            Curves[6] = CurrentBoneNode.LclScaling.GetCurve(InAnimLayer, "X", true);
            Curves[7] = CurrentBoneNode.LclScaling.GetCurve(InAnimLayer, "Y", true);
            Curves[8] = CurrentBoneNode.LclScaling.GetCurve(InAnimLayer, "Z", true);

            float AnimTime = AnimStartOffset;
            float AnimEndTime = (AnimSeq.SequenceLength - AnimEndOffset);
            // Subtracts 1 because NumFrames includes an initial pose for 0.0 second
            float TimePerKey = AnimSeq.StepFrame;
            float AnimTimeIncrement = TimePerKey * AnimPlayRate;
            FbxTime ExportTime = new FbxTime();
            ExportTime.SetSecondDouble(StartTime);

            FbxTime ExportTimeIncrement = new FbxTime();
            ExportTimeIncrement.SetSecondDouble(TimePerKey);


            //int BoneTreeIndex = Skeleton.GetSkeletonBoneIndexFromMeshBoneIndex(SkelMesh, BoneIndex);
            //int BoneTrackIndex = Skeleton.GetAnimationTrackIndex(BoneTreeIndex, AnimSeq, true);
            //if (BoneTrackIndex == INDEX_NONE)
            //{
            //    // If this sequence does not have a track for the current bone, then skip it
            //    continue;
            //}

            foreach (FbxAnimCurve Curve in Curves)
            {
                Curve.KeyModifyBegin();
            }

            bool bLastKey = false;
            int FrameIndex = 0;
            foreach(var v in AnimSeq.animationFames)
            {
                int lKeyIndex;
                FrameIndex++;
                if (FrameIndex == AnimSeq.animationFames.Count)
                    bLastKey = true;

                BoneTransformInfo BoneAtom = v[BoneIndex].BoneTransform;

                FbxDouble3 Translation = FbxDataConverter.ConvertToFbxPos(BoneAtom.position);
                FbxDouble3 Rotation = FbxDataConverter.ConvertToFbxRot(BoneAtom.rotation);
                FbxDouble3 Scale = FbxDataConverter.ConvertToFbxScale(BoneAtom.scale);
                FbxDouble3 [] Vectors = new FbxDouble3[3]{ Translation, Rotation, Scale };

                // Loop over each curve and channel to set correct values
                for (int CurveIndex = 0; CurveIndex < 3; ++CurveIndex)
                {
                    for (int ChannelIndex = 0; ChannelIndex < 3; ++ChannelIndex)
                    {
                        int OffsetCurveIndex = (CurveIndex * 3) + ChannelIndex;

                        lKeyIndex = Curves[OffsetCurveIndex].KeyAdd(ExportTime);

                        Curves[OffsetCurveIndex].KeySetValue(lKeyIndex, (float)Vectors[CurveIndex].getDataValue(ChannelIndex));
                        Curves[OffsetCurveIndex].KeySetInterpolation(lKeyIndex, bLastKey ? FbxAnimCurveDef.EInterpolationType.eInterpolationConstant : FbxAnimCurveDef.EInterpolationType.eInterpolationCubic);

                        if (bLastKey)
                        {
                            Curves[OffsetCurveIndex].KeySetConstantMode(lKeyIndex, FbxAnimCurveDef.EConstantMode.eConstantStandard);
                        }
                    }
                }

                ExportTime = ExportTime.add(ExportTimeIncrement);
            }


            while (!bLastKey)
            {
                //FTransform BoneAtom;
                //AnimSeq.GetBoneTransform(BoneAtom, BoneTrackIndex, AnimTime, true);

                //FbxVector4 Translation = Converter.ConvertToFbxPos(BoneAtom.GetTranslation());
                //FbxVector4 Rotation = Converter.ConvertToFbxRot(BoneAtom.GetRotation().Euler());
                //FbxVector4 Scale = Converter.ConvertToFbxScale(BoneAtom.GetScale3D());
                //FbxVector4 Vectors[3] = { Translation, Rotation, Scale };

                //int lKeyIndex;

                //bLastKey = AnimTime >= AnimEndTime;

                //// Loop over each curve and channel to set correct values
                //for (uint CurveIndex = 0; CurveIndex < 3; ++CurveIndex)
                //{
                //    for (uint ChannelIndex = 0; ChannelIndex < 3; ++ChannelIndex)
                //    {
                //        uint OffsetCurveIndex = (CurveIndex * 3) + ChannelIndex;

                //        lKeyIndex = Curves[OffsetCurveIndex].KeyAdd(ExportTime);
                //        Curves[OffsetCurveIndex].KeySetValue(lKeyIndex, Vectors[CurveIndex][ChannelIndex]);
                //        Curves[OffsetCurveIndex].KeySetInterpolation(lKeyIndex, bLastKey ? FbxAnimCurveDef::eInterpolationConstant : FbxAnimCurveDef::eInterpolationCubic);

                //        if (bLastKey)
                //        {
                //            Curves[OffsetCurveIndex].KeySetConstantMode(lKeyIndex, FbxAnimCurveDef::eConstantStandard);
                //        }
                //    }
                //}

                //ExportTime += ExportTimeIncrement;
                //AnimTime += AnimTimeIncrement;
            }

            foreach (FbxAnimCurve Curve in Curves)
            {
                Curve.KeyModifyEnd();
            }
        }
    }

    void CloseDocument()
    {
        if (Scene != null)
        {
            Scene.Destroy();
            Scene = null;
        }
    }

    public void WriteToFile(string Filename)
    {

        int Major, Minor, Revision;
        bool Status = true;

        int FileFormat = -1;
        bool bEmbedMedia = false;

        // Create an exporter.
        FbxExporter Exporter = FbxExporter.Create(SdkManager, "");

        // set file format
        // Write in fall back format if pEmbedMedia is true
        FileFormat = SdkManager.GetIOPluginRegistry().GetNativeWriterFormat();
        FbxIOSettings IOS_REF = SdkManager.GetIOSettings();
        // Set the export states. By default, the export states are always set to 
        // true except for the option eEXPORT_TEXTURE_AS_EMBEDDED. The code below 
        // shows how to change these states.

        
        IOS_REF.SetBoolProp(fbx_wrapper.EXP_FBX_MATERIAL,        true);
        IOS_REF.SetBoolProp(fbx_wrapper.EXP_FBX_TEXTURE,         true);
        IOS_REF.SetBoolProp(fbx_wrapper.EXP_FBX_EMBEDDED, bEmbedMedia);
        IOS_REF.SetBoolProp(fbx_wrapper.EXP_FBX_SHAPE,           true);
        IOS_REF.SetBoolProp(fbx_wrapper.EXP_FBX_GOBO,            true);
        IOS_REF.SetBoolProp(fbx_wrapper.EXP_FBX_ANIMATION,       true);
        IOS_REF.SetBoolProp(fbx_wrapper.EXP_FBX_GLOBAL_SETTINGS, true);

        string CompatibilitySetting = fbx_wrapper.FBX_2013_00_COMPATIBLE;
        
        if (!Exporter.SetFileExportVersion(new FbxString(CompatibilitySetting), FbxSceneRenamer.ERenamingMode.eNone))
        {
            Debug.LogWarning("Call to KFbxExporter::SetFileExportVersion(FBX_2013_00_COMPATIBLE) to export 2013 fbx file format failed.\n");
        }

        //// Initialize the exporter by providing a filename.
        if( !Exporter.Initialize(Filename, FileFormat, SdkManager.GetIOSettings()) )
        {

            Debug.LogWarning("Call to KFbxExporter::Initialize() failed.\n");
            string errorString = Exporter.GetStatus().GetErrorString();
            Debug.LogWarning("Error returned:" + errorString);
            return;
        }

        //FbxManager.GetFileFormatVersion(Major, Minor, Revision);

        // Export the scene.
        Status = Exporter.Export(Scene);

        if(!Status)
        {
            string errorString = Exporter.GetStatus().GetErrorString();
            Debug.LogWarning("Error returned:" + errorString);
        }
        Clear();

        return;
    }
}

