using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXlib_CS.src.Comp.DrawComp {
    abstract class DrawableComponent : Component{

        protected double posX;

        /// <summary>
        /// X軸の中心座標
        /// </summary>
        public double PosX {
            get {
                return posX;
            }
            set {
                posX = value;
            }
        }

        protected double posY;

        /// <summary>
        /// Y軸の中心座標
        /// </summary>
        public double PosY {
            get {
                return posY;
            }
            set {
                posY = value;
            }
        }

        /// <summary>
        /// 描画処理
        /// </summary>
        public abstract void Draw();
    
    }
}
