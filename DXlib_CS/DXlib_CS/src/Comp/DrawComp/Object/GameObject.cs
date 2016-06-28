using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DXlib_CS.src.Comp.DrawComp.Image;

namespace DXlib_CS.src.Comp.DrawComp.Object {
    abstract class GameObject : DrawableComponent{


        protected double posX;
        public abstract double PosX {
            get;
            set;
        }

        protected double posY;
        public abstract double PosY {
            get;
            set;
        }



        private bool isCollision;
        public bool IsCollision {
            get { return isCollision; }
            set { isCollision = value; }
        }

        public GameObject(double posX , double posY) {
            this.posX = posX;
            this.posY = posY;

            this.Init();
        }


        public override void Init() {
            this.isCollision = false;
        }

        public override void UpData() {

        }

        public override void Draw() {
        }

    }
}
