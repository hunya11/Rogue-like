using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DXlib_CS.src.Comp.DrawComp.Image;

namespace DXlib_CS.src.Comp.DrawComp.Object {
    class Cell : DrawableComponent {

        private ImageObject onBlock;
        private ImageObject offBlock;

        private bool isBlock;

        public double CellImageSizeX {
            get {
                return this.onBlock.SizeX;
            }
        }

        public double CellImageSizeY {
            get {
                return this.onBlock.SizeY;
            }
        }


        public Cell(double posX , double posY , ImageObject on , ImageObject off) {
            this.posX = posX;
            this.posY = posY;

            this.onBlock = on;
            this.offBlock = off;

            this.Init();
        }

        public Cell(ImageObject on , ImageObject off) {
            this.onBlock = on;
            this.offBlock = off;

            this.Init();
        }

        public override void Init() {
            isBlock = true;
        }


        public override void UpData() {

            onBlock.PosX = this.posX;
            onBlock.PosY = this.posY;
            offBlock.PosX = this.posX;
            offBlock.PosY = this.posY;

        }

        public override void Draw() {

            if(isBlock) {
                onBlock.Draw();
            } else {
                offBlock.Draw();
            }
        
        }

    }


}
