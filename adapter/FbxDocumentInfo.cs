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

public class FbxDocumentInfo : FbxObject {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;

  internal FbxDocumentInfo(global::System.IntPtr cPtr, bool cMemoryOwn) : base(fbx_wrapperPINVOKE.FbxDocumentInfo_SWIGUpcast(cPtr), cMemoryOwn) {
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(FbxDocumentInfo obj) {
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
      fbx_wrapperPINVOKE.FbxDocumentInfo_ClassId_set(SWIGTYPE_p_FbxClassId.getCPtr(value));
      if (fbx_wrapperPINVOKE.SWIGPendingException.Pending) throw fbx_wrapperPINVOKE.SWIGPendingException.Retrieve();
    } 
    get {
      SWIGTYPE_p_FbxClassId ret = new SWIGTYPE_p_FbxClassId(fbx_wrapperPINVOKE.FbxDocumentInfo_ClassId_get(), true);
      if (fbx_wrapperPINVOKE.SWIGPendingException.Pending) throw fbx_wrapperPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    } 
  }

  public override SWIGTYPE_p_FbxClassId GetClassId() {
    SWIGTYPE_p_FbxClassId ret = new SWIGTYPE_p_FbxClassId(fbx_wrapperPINVOKE.FbxDocumentInfo_GetClassId(swigCPtr), true);
    return ret;
  }

  public new static FbxDocumentInfo Create(FbxManager pManager, string pName) {
    global::System.IntPtr cPtr = fbx_wrapperPINVOKE.FbxDocumentInfo_Create__SWIG_0(FbxManager.getCPtr(pManager), pName);
    FbxDocumentInfo ret = (cPtr == global::System.IntPtr.Zero) ? null : new FbxDocumentInfo(cPtr, false);
    return ret;
  }

  public new static FbxDocumentInfo Create(FbxObject pContainer, string pName) {
    global::System.IntPtr cPtr = fbx_wrapperPINVOKE.FbxDocumentInfo_Create__SWIG_1(FbxObject.getCPtr(pContainer), pName);
    FbxDocumentInfo ret = (cPtr == global::System.IntPtr.Zero) ? null : new FbxDocumentInfo(cPtr, false);
    return ret;
  }

  public SWIGTYPE_p_FbxPropertyTT_FbxString_t LastSavedUrl {
    set {
      fbx_wrapperPINVOKE.FbxDocumentInfo_LastSavedUrl_set(swigCPtr, SWIGTYPE_p_FbxPropertyTT_FbxString_t.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = fbx_wrapperPINVOKE.FbxDocumentInfo_LastSavedUrl_get(swigCPtr);
      SWIGTYPE_p_FbxPropertyTT_FbxString_t ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_FbxPropertyTT_FbxString_t(cPtr, false);
      return ret;
    } 
  }

  public SWIGTYPE_p_FbxPropertyTT_FbxString_t Url {
    set {
      fbx_wrapperPINVOKE.FbxDocumentInfo_Url_set(swigCPtr, SWIGTYPE_p_FbxPropertyTT_FbxString_t.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = fbx_wrapperPINVOKE.FbxDocumentInfo_Url_get(swigCPtr);
      SWIGTYPE_p_FbxPropertyTT_FbxString_t ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_FbxPropertyTT_FbxString_t(cPtr, false);
      return ret;
    } 
  }

  public FbxProperty Original {
    set {
      fbx_wrapperPINVOKE.FbxDocumentInfo_Original_set(swigCPtr, FbxProperty.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = fbx_wrapperPINVOKE.FbxDocumentInfo_Original_get(swigCPtr);
      FbxProperty ret = (cPtr == global::System.IntPtr.Zero) ? null : new FbxProperty(cPtr, false);
      return ret;
    } 
  }

  public SWIGTYPE_p_FbxPropertyTT_FbxString_t Original_ApplicationVendor {
    set {
      fbx_wrapperPINVOKE.FbxDocumentInfo_Original_ApplicationVendor_set(swigCPtr, SWIGTYPE_p_FbxPropertyTT_FbxString_t.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = fbx_wrapperPINVOKE.FbxDocumentInfo_Original_ApplicationVendor_get(swigCPtr);
      SWIGTYPE_p_FbxPropertyTT_FbxString_t ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_FbxPropertyTT_FbxString_t(cPtr, false);
      return ret;
    } 
  }

  public SWIGTYPE_p_FbxPropertyTT_FbxString_t Original_ApplicationName {
    set {
      fbx_wrapperPINVOKE.FbxDocumentInfo_Original_ApplicationName_set(swigCPtr, SWIGTYPE_p_FbxPropertyTT_FbxString_t.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = fbx_wrapperPINVOKE.FbxDocumentInfo_Original_ApplicationName_get(swigCPtr);
      SWIGTYPE_p_FbxPropertyTT_FbxString_t ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_FbxPropertyTT_FbxString_t(cPtr, false);
      return ret;
    } 
  }

  public SWIGTYPE_p_FbxPropertyTT_FbxString_t Original_ApplicationVersion {
    set {
      fbx_wrapperPINVOKE.FbxDocumentInfo_Original_ApplicationVersion_set(swigCPtr, SWIGTYPE_p_FbxPropertyTT_FbxString_t.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = fbx_wrapperPINVOKE.FbxDocumentInfo_Original_ApplicationVersion_get(swigCPtr);
      SWIGTYPE_p_FbxPropertyTT_FbxString_t ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_FbxPropertyTT_FbxString_t(cPtr, false);
      return ret;
    } 
  }

  public SWIGTYPE_p_FbxPropertyTT_FbxString_t Original_FileName {
    set {
      fbx_wrapperPINVOKE.FbxDocumentInfo_Original_FileName_set(swigCPtr, SWIGTYPE_p_FbxPropertyTT_FbxString_t.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = fbx_wrapperPINVOKE.FbxDocumentInfo_Original_FileName_get(swigCPtr);
      SWIGTYPE_p_FbxPropertyTT_FbxString_t ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_FbxPropertyTT_FbxString_t(cPtr, false);
      return ret;
    } 
  }

  public SWIGTYPE_p_FbxPropertyTT_FbxDateTime_t Original_DateTime_GMT {
    set {
      fbx_wrapperPINVOKE.FbxDocumentInfo_Original_DateTime_GMT_set(swigCPtr, SWIGTYPE_p_FbxPropertyTT_FbxDateTime_t.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = fbx_wrapperPINVOKE.FbxDocumentInfo_Original_DateTime_GMT_get(swigCPtr);
      SWIGTYPE_p_FbxPropertyTT_FbxDateTime_t ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_FbxPropertyTT_FbxDateTime_t(cPtr, false);
      return ret;
    } 
  }

  public FbxProperty LastSaved {
    set {
      fbx_wrapperPINVOKE.FbxDocumentInfo_LastSaved_set(swigCPtr, FbxProperty.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = fbx_wrapperPINVOKE.FbxDocumentInfo_LastSaved_get(swigCPtr);
      FbxProperty ret = (cPtr == global::System.IntPtr.Zero) ? null : new FbxProperty(cPtr, false);
      return ret;
    } 
  }

  public SWIGTYPE_p_FbxPropertyTT_FbxString_t LastSaved_ApplicationVendor {
    set {
      fbx_wrapperPINVOKE.FbxDocumentInfo_LastSaved_ApplicationVendor_set(swigCPtr, SWIGTYPE_p_FbxPropertyTT_FbxString_t.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = fbx_wrapperPINVOKE.FbxDocumentInfo_LastSaved_ApplicationVendor_get(swigCPtr);
      SWIGTYPE_p_FbxPropertyTT_FbxString_t ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_FbxPropertyTT_FbxString_t(cPtr, false);
      return ret;
    } 
  }

  public SWIGTYPE_p_FbxPropertyTT_FbxString_t LastSaved_ApplicationName {
    set {
      fbx_wrapperPINVOKE.FbxDocumentInfo_LastSaved_ApplicationName_set(swigCPtr, SWIGTYPE_p_FbxPropertyTT_FbxString_t.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = fbx_wrapperPINVOKE.FbxDocumentInfo_LastSaved_ApplicationName_get(swigCPtr);
      SWIGTYPE_p_FbxPropertyTT_FbxString_t ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_FbxPropertyTT_FbxString_t(cPtr, false);
      return ret;
    } 
  }

  public SWIGTYPE_p_FbxPropertyTT_FbxString_t LastSaved_ApplicationVersion {
    set {
      fbx_wrapperPINVOKE.FbxDocumentInfo_LastSaved_ApplicationVersion_set(swigCPtr, SWIGTYPE_p_FbxPropertyTT_FbxString_t.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = fbx_wrapperPINVOKE.FbxDocumentInfo_LastSaved_ApplicationVersion_get(swigCPtr);
      SWIGTYPE_p_FbxPropertyTT_FbxString_t ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_FbxPropertyTT_FbxString_t(cPtr, false);
      return ret;
    } 
  }

  public SWIGTYPE_p_FbxPropertyTT_FbxDateTime_t LastSaved_DateTime_GMT {
    set {
      fbx_wrapperPINVOKE.FbxDocumentInfo_LastSaved_DateTime_GMT_set(swigCPtr, SWIGTYPE_p_FbxPropertyTT_FbxDateTime_t.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = fbx_wrapperPINVOKE.FbxDocumentInfo_LastSaved_DateTime_GMT_get(swigCPtr);
      SWIGTYPE_p_FbxPropertyTT_FbxDateTime_t ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_FbxPropertyTT_FbxDateTime_t(cPtr, false);
      return ret;
    } 
  }

  public SWIGTYPE_p_FbxPropertyTT_FbxString_t EmbeddedUrl {
    set {
      fbx_wrapperPINVOKE.FbxDocumentInfo_EmbeddedUrl_set(swigCPtr, SWIGTYPE_p_FbxPropertyTT_FbxString_t.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = fbx_wrapperPINVOKE.FbxDocumentInfo_EmbeddedUrl_get(swigCPtr);
      SWIGTYPE_p_FbxPropertyTT_FbxString_t ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_FbxPropertyTT_FbxString_t(cPtr, false);
      return ret;
    } 
  }

  public SWIGTYPE_p_FbxString mTitle {
    set {
      fbx_wrapperPINVOKE.FbxDocumentInfo_mTitle_set(swigCPtr, SWIGTYPE_p_FbxString.getCPtr(value));
      if (fbx_wrapperPINVOKE.SWIGPendingException.Pending) throw fbx_wrapperPINVOKE.SWIGPendingException.Retrieve();
    } 
    get {
      SWIGTYPE_p_FbxString ret = new SWIGTYPE_p_FbxString(fbx_wrapperPINVOKE.FbxDocumentInfo_mTitle_get(swigCPtr), true);
      if (fbx_wrapperPINVOKE.SWIGPendingException.Pending) throw fbx_wrapperPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    } 
  }

  public SWIGTYPE_p_FbxString mSubject {
    set {
      fbx_wrapperPINVOKE.FbxDocumentInfo_mSubject_set(swigCPtr, SWIGTYPE_p_FbxString.getCPtr(value));
      if (fbx_wrapperPINVOKE.SWIGPendingException.Pending) throw fbx_wrapperPINVOKE.SWIGPendingException.Retrieve();
    } 
    get {
      SWIGTYPE_p_FbxString ret = new SWIGTYPE_p_FbxString(fbx_wrapperPINVOKE.FbxDocumentInfo_mSubject_get(swigCPtr), true);
      if (fbx_wrapperPINVOKE.SWIGPendingException.Pending) throw fbx_wrapperPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    } 
  }

  public SWIGTYPE_p_FbxString mAuthor {
    set {
      fbx_wrapperPINVOKE.FbxDocumentInfo_mAuthor_set(swigCPtr, SWIGTYPE_p_FbxString.getCPtr(value));
      if (fbx_wrapperPINVOKE.SWIGPendingException.Pending) throw fbx_wrapperPINVOKE.SWIGPendingException.Retrieve();
    } 
    get {
      SWIGTYPE_p_FbxString ret = new SWIGTYPE_p_FbxString(fbx_wrapperPINVOKE.FbxDocumentInfo_mAuthor_get(swigCPtr), true);
      if (fbx_wrapperPINVOKE.SWIGPendingException.Pending) throw fbx_wrapperPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    } 
  }

  public SWIGTYPE_p_FbxString mKeywords {
    set {
      fbx_wrapperPINVOKE.FbxDocumentInfo_mKeywords_set(swigCPtr, SWIGTYPE_p_FbxString.getCPtr(value));
      if (fbx_wrapperPINVOKE.SWIGPendingException.Pending) throw fbx_wrapperPINVOKE.SWIGPendingException.Retrieve();
    } 
    get {
      SWIGTYPE_p_FbxString ret = new SWIGTYPE_p_FbxString(fbx_wrapperPINVOKE.FbxDocumentInfo_mKeywords_get(swigCPtr), true);
      if (fbx_wrapperPINVOKE.SWIGPendingException.Pending) throw fbx_wrapperPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    } 
  }

  public SWIGTYPE_p_FbxString mRevision {
    set {
      fbx_wrapperPINVOKE.FbxDocumentInfo_mRevision_set(swigCPtr, SWIGTYPE_p_FbxString.getCPtr(value));
      if (fbx_wrapperPINVOKE.SWIGPendingException.Pending) throw fbx_wrapperPINVOKE.SWIGPendingException.Retrieve();
    } 
    get {
      SWIGTYPE_p_FbxString ret = new SWIGTYPE_p_FbxString(fbx_wrapperPINVOKE.FbxDocumentInfo_mRevision_get(swigCPtr), true);
      if (fbx_wrapperPINVOKE.SWIGPendingException.Pending) throw fbx_wrapperPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    } 
  }

  public SWIGTYPE_p_FbxString mComment {
    set {
      fbx_wrapperPINVOKE.FbxDocumentInfo_mComment_set(swigCPtr, SWIGTYPE_p_FbxString.getCPtr(value));
      if (fbx_wrapperPINVOKE.SWIGPendingException.Pending) throw fbx_wrapperPINVOKE.SWIGPendingException.Retrieve();
    } 
    get {
      SWIGTYPE_p_FbxString ret = new SWIGTYPE_p_FbxString(fbx_wrapperPINVOKE.FbxDocumentInfo_mComment_get(swigCPtr), true);
      if (fbx_wrapperPINVOKE.SWIGPendingException.Pending) throw fbx_wrapperPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    } 
  }

  public SWIGTYPE_p_FbxThumbnail GetSceneThumbnail() {
    global::System.IntPtr cPtr = fbx_wrapperPINVOKE.FbxDocumentInfo_GetSceneThumbnail(swigCPtr);
    SWIGTYPE_p_FbxThumbnail ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_FbxThumbnail(cPtr, false);
    return ret;
  }

  public void SetSceneThumbnail(SWIGTYPE_p_FbxThumbnail pSceneThumbnail) {
    fbx_wrapperPINVOKE.FbxDocumentInfo_SetSceneThumbnail(swigCPtr, SWIGTYPE_p_FbxThumbnail.getCPtr(pSceneThumbnail));
  }

  public void Clear() {
    fbx_wrapperPINVOKE.FbxDocumentInfo_Clear(swigCPtr);
  }

  public override FbxObject Copy(FbxObject pObject) {
    FbxObject ret = new FbxObject(fbx_wrapperPINVOKE.FbxDocumentInfo_Copy(swigCPtr, FbxObject.getCPtr(pObject)), false);
    if (fbx_wrapperPINVOKE.SWIGPendingException.Pending) throw fbx_wrapperPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

}

}