%module fbx_wrapper
%{
#include <fbxsdk.h>
#include <fbxsdk\fileio\collada\fbxcolladatokens.h>
#include <fbxsdk\fileio\fbxbase64coder.h>
#include <fbxsdk\scene\shading\fbxlayerentryview.h>
#include <fbxsdk\utils\fbxembeddedfilesaccumulator.h>
#include <fbxsdk\scene\fbxobjectscontainer.h>
#include <fbxsdk\utils\fbxrenamingstrategyfbx7.h>
%}

#define _WIN64
#define _MSC_VER 1800
#define _M_X64

#pragma SWIG nowarn=451,516


%rename(add)             operator+;
%rename(pos)             operator+();
%rename(pos)             operator+() const;

%rename(sub)             operator-;
%rename(neg)             operator-() const;
%rename(neg)             operator-();

%rename(mul)             operator*;
%rename(deref)           operator*();
%rename(deref)           operator*() const;

%rename(div)             operator/;
%rename(mod)             operator%;
%rename(logxor)          operator^;
%rename(logand)          operator&;
%rename(logior)          operator|;
%rename(lognot)          operator~();
%rename(lognot)          operator~() const;


%rename(assign)          operator=;

%rename(add_assign)      operator+=;
%rename(sub_assign)      operator-=;
%rename(mul_assign)      operator*=;
%rename(div_assign)      operator/=;
%rename(mod_assign)      operator%=;
%rename(logxor_assign)   operator^=;
%rename(logand_assign)   operator&=;
%rename(logior_assign)   operator|=;

%rename(eq)              operator==;
%rename(ne)              operator!=;
%rename(lt)              operator<;
%rename(gt)              operator>;
%rename(lte)             operator<=;
%rename(gte)             operator>=;

%rename(at)              operator[];
%rename(cast)            operator();

%ignore FbxIOPropInfo;
%ignore FbxCleanUpConnectionsAtDestructionBoundary;
%ignore FbxMarkObject;
%ignore PropertyNotify;
%ignore CollectAnimFromCurveNode;

%include "fbxsdk/core/arch/fbxarch.h"
%include "fbxsdk/core/arch/fbxtypes.h"

%template(FbxDouble2) FbxVectorTemplate2<FbxDouble>;
%template(FbxDouble3) FbxVectorTemplate3<FbxDouble>;
%template(FbxDouble4) FbxVectorTemplate4<FbxDouble>;
%template(FbxDouble4x4) FbxVectorTemplate4<FbxDouble4>;

%include "fbxsdk/core/math/fbxvector2.h"
%include "fbxsdk/core/math/fbxvector4.h"
%include "fbxsdk/core/fbxmanager.h"
%include "fbxsdk/core/arch/fbxnew.h"
%include "fbxsdk/core/fbxevent.h"
%template(FbxObjectPropertyChangedBase) FbxEvent<FbxObjectPropertyChanged>;
%include "fbxsdk/core/fbxemitter.h"
%include "fbxsdk/core/fbxobject.h"
%include "fbxsdk/fileio/fbxiosettings.h"
%include "fbxsdk/core/fbxproperty.h"
%include "fbxsdk/scene/fbxdocumentinfo.h"
%include "fbxsdk/scene/fbxcollection.h"
%include "fbxsdk/scene/fbxdocument.h"
%include "fbxsdk/scene/fbxscene.h"
%include "fbxsdk/scene/fbxaxissystem.h"
%include "fbxsdk/scene/animation/fbxanimcurvebase.h"
%include "fbxsdk/scene/animation/fbxanimcurvenode.h"
%include "fbxsdk/scene/animation/fbxanimlayer.h"
%include "fbxsdk/scene/animation/fbxanimstack.h"
%include "fbxsdk/scene/geometry/fbxnode.h"