using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DXlib_CS.src.Comp.DrawComp.Image;

namespace DXlib_CS.src.Comp.DrawComp.Object {
    class Cell : DrawableComponent {

        private ImageObject onBlock;
        private ImageObject offBLock;

        public double cellImageSizeX {
            get {
                return this.onBlock.SizeX;
            }
        }

        public double cellImageSizeY {
            get {
                return this.onBlock.SizeY;
            }
        }


        public Cell(double posX , double posY , ImageObject on , ImageObject off) {

            this.onBlock = on;
            this.offBLock = off;
        }

        public override void Init() {
        }


        public override void UpData() {
        }

        public override void Draw() {
        }

    }


}
