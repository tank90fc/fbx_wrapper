using System;
using System.Collections.Generic;
using Fbx;

namespace test
{
    class MyExport
    {
        public FbxManager SdkManager = null;
        public FbxScene Scene = null;
        public bool bForceFrontXAxis = false;
        public FbxAnimStack AnimStack;
        public FbxAnimLayer AnimLayer;

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


        }


        public void CreateSkeleton()
        {

        }

        public void ExportAnimSequence()
        {
            FbxNode RootNode = Scene.GetRootNode();

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
}
