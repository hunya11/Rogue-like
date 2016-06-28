using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXlib_CS.src {
    static class GrHandleController {

        static private Dictionary<int , int[]> dicGrHandle;

        /// <summary>
        /// key:ImageId
        /// value:grHandle
        /// 静止画の場合配列の一番最初に格納
        /// アニメーションの場合それぞれ分割されて格納
        /// </summary>
        public static Dictionary<int , int[]> DicGrHandle {
            get {
                return GrHandleController.dicGrHandle;
            }
            set {
                GrHandleController.dicGrHandle = value;
            }
        }

        static GrHandleController(){
            dicGrHandle = new Dictionary<int , int[]>();
            
        }

       

    }
}
