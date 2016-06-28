using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DxLibDLL;

namespace DXlib_CS.src.Comp.DrawComp.Image {

    /// <summary>
    /// 静止グラフィックデータクラス
    /// </summary>
    class ImageObject : DrawableComponent {


        private double posX;

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

        private double posY;

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


        private double sizeX;
        private double sizeY;

        /// <summary>
        /// グラフィックハンドル
        /// </summary>
        private int GrHandle;

        private double alphaBlend;

        /// <summary>
        /// 画像の透過度
        /// 0~1の値をとり、1に近いほど濃く描画される。
        /// </summary>
        public double AlphaBlend {
            get {
                return alphaBlend;
            }
            set {
                if(value < 0) {
                    value = 0;
                } else if(value > 255) {
                    value = 255;
                }
                alphaBlend = value;
            }
        }

        public ImageObject(int imageId) {

            this.Init();

            this.GrHandle = GrHandleController.DicGrHandle[imageId][0];
            int tempSizeX , tempSizeY;
            DX.GetGraphSize(this.GrHandle , out tempSizeX , out tempSizeY);
            sizeX = tempSizeX;
            sizeY = tempSizeY;

        }

        public override void Init() {

            alphaBlend = 1.0;

        }

        public override void UpData() {
            throw new NotImplementedException();
        }

        public override void Draw() {
            int drawX = (int)((posX - sizeX / 2) + 0.5);
            int drawY = (int)((posY - sizeY / 2) + 0.5);
            int numAlpha = (int)((this.alphaBlend * 255) + 0.5);

            DX.SetDrawBlendMode(DX.DX_BLENDMODE_ALPHA , numAlpha);
            DX.DrawGraph(drawX , drawY , this.GrHandle , 1);
            DX.SetDrawBlendMode(DX.DX_BLENDMODE_NOBLEND , 0);
        }

    }

}
