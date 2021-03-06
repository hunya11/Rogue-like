﻿using System;
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



        private double sizeX;
        /// <summary>
        /// 画像のX方向への大きさ
        /// </summary>
        public double SizeX {
            get {
                return sizeX;
            }
            set {
                sizeX = value;
            }
        }
        private double sizeY;
        /// <summary>
        /// 画像のY方向への大きさ
        /// </summary>
        public double SizeY {
            get {
                return sizeY;
            }
            set {
                sizeY = value;
            }
        }

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

            posX = 0;
            posY = 0;

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
