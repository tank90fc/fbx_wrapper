using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fbx;
namespace test
{
    class FbxDataConverter
    {
        void Test()
        {
            FbxVector4 Out = new FbxVector4();
            double_p pp = new double_p();
            pp.assign(10.0f);
            Out.setDataValue(0, pp.cast());
        }
    }
}
