//------------------------------------------------------------------------------
// <auto-generated />
//
// This file was automatically generated by SWIG (http://www.swig.org).
// Version 3.0.12
//
// Do not make changes to this file unless you know what you are doing--modify
// the SWIG interface file instead.
//------------------------------------------------------------------------------

namespace Fbx {

public class FbxAnimCurveBase : FbxObject {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;

  internal FbxAnimCurveBase(global::System.IntPtr cPtr, bool cMemoryOwn) : base(fbx_wrapperPINVOKE.FbxAnimCurveBase_SWIGUpcast(cPtr), cMemoryOwn) {
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(FbxAnimCurveBase obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  public override void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          throw new global::System.MethodAccessException("C++ destructor does not have public access");
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      global::System.GC.SuppressFinalize(this);
      base.Dispose();
    }
  }

  public static SWIGTYPE_p_FbxClassId ClassId {
    set {
      fbx_wrapperPINVOKE.FbxAnimCurveBase_ClassId_set(SWIGTYPE_p_FbxClassId.getCPtr(value));
      if (fbx_wrapperPINVOKE.SWIGPendingException.Pending) throw fbx_wrapperPINVOKE.SWIGPendingException.Retrieve();
    } 
    get {
      SWIGTYPE_p_FbxClassId ret = new SWIGTYPE_p_FbxClassId(fbx_wrapperPINVOKE.FbxAnimCurveBase_ClassId_get(), true);
      if (fbx_wrapperPINVOKE.SWIGPendingException.Pending) throw fbx_wrapperPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    } 
  }

  public override SWIGTYPE_p_FbxClassId GetClassId() {
    SWIGTYPE_p_FbxClassId ret = new SWIGTYPE_p_FbxClassId(fbx_wrapperPINVOKE.FbxAnimCurveBase_GetClassId(swigCPtr), true);
    return ret;
  }

  public new static FbxAnimCurveBase Create(FbxManager pManager, string pName) {
    global::System.IntPtr cPtr = fbx_wrapperPINVOKE.FbxAnimCurveBase_Create(FbxManager.getCPtr(pManager), pName);
    FbxAnimCurveBase ret = (cPtr == global::System.IntPtr.Zero) ? null : new FbxAnimCurveBase(cPtr, false);
    return ret;
  }

  public virtual void KeyClear() {
    fbx_wrapperPINVOKE.FbxAnimCurveBase_KeyClear(swigCPtr);
  }

  public virtual int KeyGetCount() {
    int ret = fbx_wrapperPINVOKE.FbxAnimCurveBase_KeyGetCount(swigCPtr);
    return ret;
  }

  public virtual int KeyAdd(SWIGTYPE_p_FbxTime pTime, FbxAnimCurveKeyBase pKey, SWIGTYPE_p_int pLast) {
    int ret = fbx_wrapperPINVOKE.FbxAnimCurveBase_KeyAdd__SWIG_0(swigCPtr, SWIGTYPE_p_FbxTime.getCPtr(pTime), FbxAnimCurveKeyBase.getCPtr(pKey), SWIGTYPE_p_int.getCPtr(pLast));
    if (fbx_wrapperPINVOKE.SWIGPendingException.Pending) throw fbx_wrapperPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual int KeyAdd(SWIGTYPE_p_FbxTime pTime, FbxAnimCurveKeyBase pKey) {
    int ret = fbx_wrapperPINVOKE.FbxAnimCurveBase_KeyAdd__SWIG_1(swigCPtr, SWIGTYPE_p_FbxTime.getCPtr(pTime), FbxAnimCurveKeyBase.getCPtr(pKey));
    if (fbx_wrapperPINVOKE.SWIGPendingException.Pending) throw fbx_wrapperPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual bool KeySet(int pIndex, FbxAnimCurveKeyBase pKey) {
    bool ret = fbx_wrapperPINVOKE.FbxAnimCurveBase_KeySet(swigCPtr, pIndex, FbxAnimCurveKeyBase.getCPtr(pKey));
    if (fbx_wrapperPINVOKE.SWIGPendingException.Pending) throw fbx_wrapperPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual bool KeyRemove(int pIndex) {
    bool ret = fbx_wrapperPINVOKE.FbxAnimCurveBase_KeyRemove__SWIG_0(swigCPtr, pIndex);
    return ret;
  }

  public virtual bool KeyRemove(int pStartIndex, int pEndIndex) {
    bool ret = fbx_wrapperPINVOKE.FbxAnimCurveBase_KeyRemove__SWIG_1(swigCPtr, pStartIndex, pEndIndex);
    return ret;
  }

  public virtual SWIGTYPE_p_FbxTime KeyGetTime(int arg0) {
    SWIGTYPE_p_FbxTime ret = new SWIGTYPE_p_FbxTime(fbx_wrapperPINVOKE.FbxAnimCurveBase_KeyGetTime(swigCPtr, arg0), true);
    return ret;
  }

  public virtual void KeySetTime(int pKeyIndex, SWIGTYPE_p_FbxTime pTime) {
    fbx_wrapperPINVOKE.FbxAnimCurveBase_KeySetTime(swigCPtr, pKeyIndex, SWIGTYPE_p_FbxTime.getCPtr(pTime));
    if (fbx_wrapperPINVOKE.SWIGPendingException.Pending) throw fbx_wrapperPINVOKE.SWIGPendingException.Retrieve();
  }

  public void SetPreExtrapolation(FbxAnimCurveBase.EExtrapolationType pExtrapolation) {
    fbx_wrapperPINVOKE.FbxAnimCurveBase_SetPreExtrapolation(swigCPtr, (int)pExtrapolation);
  }

  public FbxAnimCurveBase.EExtrapolationType GetPreExtrapolation() {
    FbxAnimCurveBase.EExtrapolationType ret = (FbxAnimCurveBase.EExtrapolationType)fbx_wrapperPINVOKE.FbxAnimCurveBase_GetPreExtrapolation(swigCPtr);
    return ret;
  }

  public void SetPreExtrapolationCount(uint pCount) {
    fbx_wrapperPINVOKE.FbxAnimCurveBase_SetPreExtrapolationCount(swigCPtr, pCount);
  }

  public uint GetPreExtrapolationCount() {
    uint ret = fbx_wrapperPINVOKE.FbxAnimCurveBase_GetPreExtrapolationCount(swigCPtr);
    return ret;
  }

  public void SetPostExtrapolation(FbxAnimCurveBase.EExtrapolationType pExtrapolation) {
    fbx_wrapperPINVOKE.FbxAnimCurveBase_SetPostExtrapolation(swigCPtr, (int)pExtrapolation);
  }

  public FbxAnimCurveBase.EExtrapolationType GetPostExtrapolation() {
    FbxAnimCurveBase.EExtrapolationType ret = (FbxAnimCurveBase.EExtrapolationType)fbx_wrapperPINVOKE.FbxAnimCurveBase_GetPostExtrapolation(swigCPtr);
    return ret;
  }

  public void SetPostExtrapolationCount(uint pCount) {
    fbx_wrapperPINVOKE.FbxAnimCurveBase_SetPostExtrapolationCount(swigCPtr, pCount);
  }

  public uint GetPostExtrapolationCount() {
    uint ret = fbx_wrapperPINVOKE.FbxAnimCurveBase_GetPostExtrapolationCount(swigCPtr);
    return ret;
  }

  public virtual float Evaluate(SWIGTYPE_p_FbxTime pTime, SWIGTYPE_p_int pLast) {
    float ret = fbx_wrapperPINVOKE.FbxAnimCurveBase_Evaluate__SWIG_0(swigCPtr, SWIGTYPE_p_FbxTime.getCPtr(pTime), SWIGTYPE_p_int.getCPtr(pLast));
    if (fbx_wrapperPINVOKE.SWIGPendingException.Pending) throw fbx_wrapperPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual float Evaluate(SWIGTYPE_p_FbxTime pTime) {
    float ret = fbx_wrapperPINVOKE.FbxAnimCurveBase_Evaluate__SWIG_1(swigCPtr, SWIGTYPE_p_FbxTime.getCPtr(pTime));
    if (fbx_wrapperPINVOKE.SWIGPendingException.Pending) throw fbx_wrapperPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual float EvaluateIndex(double pIndex) {
    float ret = fbx_wrapperPINVOKE.FbxAnimCurveBase_EvaluateIndex(swigCPtr, pIndex);
    return ret;
  }

  public virtual bool GetTimeInterval(SWIGTYPE_p_FbxTimeSpan pTimeInterval) {
    bool ret = fbx_wrapperPINVOKE.FbxAnimCurveBase_GetTimeInterval(swigCPtr, SWIGTYPE_p_FbxTimeSpan.getCPtr(pTimeInterval));
    if (fbx_wrapperPINVOKE.SWIGPendingException.Pending) throw fbx_wrapperPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public override FbxObject Copy(FbxObject pObject) {
    FbxObject ret = new FbxObject(fbx_wrapperPINVOKE.FbxAnimCurveBase_Copy(swigCPtr, FbxObject.getCPtr(pObject)), false);
    if (fbx_wrapperPINVOKE.SWIGPendingException.Pending) throw fbx_wrapperPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual bool Store(SWIGTYPE_p_FbxIO pFileObject, bool pLegacyVersion) {
    bool ret = fbx_wrapperPINVOKE.FbxAnimCurveBase_Store__SWIG_0(swigCPtr, SWIGTYPE_p_FbxIO.getCPtr(pFileObject), pLegacyVersion);
    return ret;
  }

  public virtual bool Store(SWIGTYPE_p_FbxIO pFileObject) {
    bool ret = fbx_wrapperPINVOKE.FbxAnimCurveBase_Store__SWIG_1(swigCPtr, SWIGTYPE_p_FbxIO.getCPtr(pFileObject));
    return ret;
  }

  public virtual bool Retrieve(SWIGTYPE_p_FbxIO pFileObject) {
    bool ret = fbx_wrapperPINVOKE.FbxAnimCurveBase_Retrieve(swigCPtr, SWIGTYPE_p_FbxIO.getCPtr(pFileObject));
    return ret;
  }

  public virtual void ExtrapolationSyncCallback() {
    fbx_wrapperPINVOKE.FbxAnimCurveBase_ExtrapolationSyncCallback(swigCPtr);
  }

  public enum EExtrapolationType {
    eConstant = 1,
    eRepetition = 2,
    eMirrorRepetition = 3,
    eKeepSlope = 4,
    eRelativeRepetition = 5
  }

}

}
