using System;
using System.Collections.Generic;
using Fbx;
using UnityEngine;

struct FMeshBoneInfo
{
    // Bone's name.
    public string Name;
    public int ParentIndex;
    public Transform BoneTransform;
};

class AnimSequence
{
    public int NumFrames = 0;
    public float SequenceLength = 0;
};

class MyExport
{
    public FbxManager SdkManager = null;
    public FbxScene Scene = null;
    public bool bForceFrontXAxis = false;
    public FbxAnimStack AnimStack;
    public FbxAnimLayer AnimLayer;
    public const float DEFAULT_SAMPLERATE = 30.0f;
    public void Init()
    {
        SdkManager = FbxManager.Create();
        FbxIOSettings ios = FbxIOSettings.Create(SdkManager, "IOSRoot");
        SdkManager.SetIOSettings(ios);
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
        Scene.GetGlobalSettings().SetAxisSystem(UnrealZUp);
        Scene.GetGlobalSettings().SetOriginalUpAxis(UnrealZUp);
        Scene.GetGlobalSettings().SetSystemUnit(FbxSystemUnit.cm);

        Scene.SetSceneInfo(SceneInfo);

        // setup anim stack
        AnimStack = FbxAnimStack.Create(Scene, "Unreal Take");
        //KFbxSet<KTime>(AnimStack->LocalStart, KTIME_ONE_SECOND);
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
                //SkeletonAttribute->Size.Set(1.0);
            }
            else
            {
                SkeletonAttribute.SetSkeletonType(FbxSkeleton.EType.eRoot);
                //SkeletonAttribute->Size.Set(1.0);
            }

            // Create the node
            FbxNode BoneNode = FbxNode.Create(Scene, CurrentBone.Name);
            BoneNode.SetNodeAttribute(SkeletonAttribute);

            Vector3 UnrealRotation = CurrentBone.BoneTransform.localRotation.eulerAngles;
            FbxDouble3 LocalPos = FbxDataConverter.ConvertToFbxPos(CurrentBone.BoneTransform.localPosition);
            FbxDouble3 LocalRot = FbxDataConverter.ConvertToFbxRot(UnrealRotation);
            FbxDouble3 LocalScale = FbxDataConverter.ConvertToFbxScale(CurrentBone.BoneTransform.localScale);

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

    public FbxNode ExportAnimSequence()
    {
        if (Scene == null)
        {
            return null;
        }
        List<FMeshBoneInfo> boneInfos = null;
        List<FbxNode> BoneNodes = new List<FbxNode>();
        FbxNode RootNode = Scene.GetRootNode();
        FbxNode SkeletonRootNode = CreateSkeleton(boneInfos,ref BoneNodes);
        RootNode.AddChild(SkeletonRootNode);

        return SkeletonRootNode;

    }
    static bool IsNearlyEqual(float A, float B, float ErrorTolerance)
    {
        return Mathf.Abs(A - B) <= ErrorTolerance;
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
        float FrameRate = AnimSeq.NumFrames / AnimSeq.SequenceLength;

        FbxTime ExportedStartTime = new FbxTime();
        FbxTime ExportedStopTime = new FbxTime();
        if (IsNearlyEqual(FrameRate, DEFAULT_SAMPLERATE, 1.0f))
        {
            FbxTime.SetGlobalTimeMode(FbxTime.EMode.eFrames30);
            //FbxTime.SetGlobalTimeMode(FbxTime.EMode.eFrames30);
        }
        else
        {
            FbxTime.SetGlobalTimeMode(FbxTime.EMode.eCustom, FrameRate);
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
            float TimePerKey = (AnimSeq.SequenceLength / (AnimSeq.NumFrames - 1));
            float AnimTimeIncrement = TimePerKey * AnimPlayRate;
            FbxTime ExportTime = new FbxTime();
            ExportTime.SetSecondDouble(StartTime);

            FbxTime ExportTimeIncrement = new FbxTime();
            ExportTimeIncrement.SetSecondDouble(TimePerKey);


            //int32 BoneTreeIndex = Skeleton->GetSkeletonBoneIndexFromMeshBoneIndex(SkelMesh, BoneIndex);
            //int32 BoneTrackIndex = Skeleton->GetAnimationTrackIndex(BoneTreeIndex, AnimSeq, true);
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

            while (!bLastKey)
            {
                //FTransform BoneAtom;
                //AnimSeq->GetBoneTransform(BoneAtom, BoneTrackIndex, AnimTime, true);

                //FbxVector4 Translation = Converter.ConvertToFbxPos(BoneAtom.GetTranslation());
                //FbxVector4 Rotation = Converter.ConvertToFbxRot(BoneAtom.GetRotation().Euler());
                //FbxVector4 Scale = Converter.ConvertToFbxScale(BoneAtom.GetScale3D());
                //FbxVector4 Vectors[3] = { Translation, Rotation, Scale };

                //int32 lKeyIndex;

                //bLastKey = AnimTime >= AnimEndTime;

                //// Loop over each curve and channel to set correct values
                //for (uint32 CurveIndex = 0; CurveIndex < 3; ++CurveIndex)
                //{
                //    for (uint32 ChannelIndex = 0; ChannelIndex < 3; ++ChannelIndex)
                //    {
                //        uint32 OffsetCurveIndex = (CurveIndex * 3) + ChannelIndex;

                //        lKeyIndex = Curves[OffsetCurveIndex]->KeyAdd(ExportTime);
                //        Curves[OffsetCurveIndex]->KeySetValue(lKeyIndex, Vectors[CurveIndex][ChannelIndex]);
                //        Curves[OffsetCurveIndex]->KeySetInterpolation(lKeyIndex, bLastKey ? FbxAnimCurveDef::eInterpolationConstant : FbxAnimCurveDef::eInterpolationCubic);

                //        if (bLastKey)
                //        {
                //            Curves[OffsetCurveIndex]->KeySetConstantMode(lKeyIndex, FbxAnimCurveDef::eConstantStandard);
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
}

