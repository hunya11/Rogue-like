using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DxLibDLL;
using System.IO;


using DXlib_CS.src.Comp.DrawComp.Image;
using DXlib_CS.src.Comp.DrawComp.Object;

namespace DXlib_CS.src.Comp.DrawComp.Pages {
    class PageGame : Page {

        Cell[,] cells;

        public PageGame() {

        }

        ~PageGame() {

        }

        public override void Init() {

            base.Init();
            this.LoadResource();

            cells = new Cell[10 , 10];
            double cellSizeX = new ImageObject(2).SizeX;
            double cellSizeY = new ImageObject(2).SizeY;
            for(int y = 0 ; y < 10 ; y++) {
                for(int x = 0 ; x < 10 ; x++) {
                    cells[y , x] = new Cell(new ImageObject(1) , new ImageObject(2));
                    cells[y , x].PosX = 100 + cellSizeX * x + cellSizeX * y / 2;
                    cells[y , x].PosY = 100 + cellSizeY / 4 * y;
                }
            }

        }

        public override void UpData() {
            base.UpData();

            foreach(var item in cells) {
                item.UpData();
            }

            //escでめにゅー
            if(keys.Pressed(DX.KEY_INPUT_ESCAPE)) {
                pageState = (int)Page.State.TITLE;
            }
        }

        public override void Draw() {

#if DEBUG
            DX.DrawString(0 , 0 , "げーむ" , DX.GetColor(255 , 255 , 0));
            DX.DrawString(0 , 15 , "globaltimer:" + globalTimer.Elapsed , DX.GetColor(255 , 255 , 0));
            DX.DrawString(0 , 30 , "localtimer:" + localTimer.Elapsed , DX.GetColor(255 , 255 , 0));

            int mouseX , mouseY;
            DX.GetMousePoint(out mouseX , out mouseY);
            DX.DrawString(0 , 45 , "mouseX:" + mouseX , DX.GetColor(255 , 255 , 0));
            DX.DrawString(0 , 60 , "mouseY:" + mouseY , DX.GetColor(255 , 255 , 0));
#endif

            foreach(var item in cells) {
                item.Draw();
            }



        }

        public override void LoadResource() {

            GrHandleController.DicGrHandle.Add(0 , new[] { DX.LoadGraph(@"./Data/Image/mon_014.png") });
            GrHandleController.DicGrHandle.Add(1 , new[] { DX.LoadGraph(@"./Data/Image/hoge.png") });
            GrHandleController.DicGrHandle.Add(2 , new[] { DX.LoadGraph(@"./Data/Image/huga.png") });


            //grHandleが-1＝画像ファイルがない・画像ファイルの読み込みに失敗したということなので、例外をげろげろ
            foreach(var handle in GrHandleController.DicGrHandle) {
                foreach(var value in handle.Value) {
                    if(value == -1) {
                        throw new FileNotFoundException();
                    }
                }
            }


        }



    }
}
