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

public class FbxObjectPropertyChanged : FbxObjectPropertyChangedBase {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;

  internal FbxObjectPropertyChanged(global::System.IntPtr cPtr, bool cMemoryOwn) : base(fbx_wrapperPINVOKE.FbxObjectPropertyChanged_SWIGUpcast(cPtr), cMemoryOwn) {
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(FbxObjectPropertyChanged obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~FbxObjectPropertyChanged() {
    Dispose();
  }

  public override void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          fbx_wrapperPINVOKE.delete_FbxObjectPropertyChanged(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      global::System.GC.SuppressFinalize(this);
      base.Dispose();
    }
  }

  public override string GetEventName() {
    string ret = fbx_wrapperPINVOKE.FbxObjectPropertyChanged_GetEventName(swigCPtr);
    return ret;
  }

  public FbxObjectPropertyChanged(FbxProperty pProp) : this(fbx_wrapperPINVOKE.new_FbxObjectPropertyChanged(FbxProperty.getCPtr(pProp)), true) {
    if (fbx_wrapperPINVOKE.SWIGPendingException.Pending) throw fbx_wrapperPINVOKE.SWIGPendingException.Retrieve();
  }

  public FbxProperty mProp {
    set {
      fbx_wrapperPINVOKE.FbxObjectPropertyChanged_mProp_set(swigCPtr, FbxProperty.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = fbx_wrapperPINVOKE.FbxObjectPropertyChanged_mProp_get(swigCPtr);
      FbxProperty ret = (cPtr == global::System.IntPtr.Zero) ? null : new FbxProperty(cPtr, false);
      return ret;
    } 
  }

}

}
