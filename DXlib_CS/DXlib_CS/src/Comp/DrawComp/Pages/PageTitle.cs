using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DxLibDLL;

namespace DXlib_CS.src.Comp.DrawComp.Pages {
    sealed class PageTitle : Page{

        int posSelectMenu = 0;
        private int PosSelectMenu {
            get { return posSelectMenu; }
            set {
                posSelectMenu = value;
                if(this.posSelectMenu < 0) {
                    posSelectMenu = 1;
                }
                if(this.posSelectMenu > 1) {
                    posSelectMenu = 0;
                }
            }
        }

        /// <summary>
        /// ふぉんと
        /// </summary>
        int fontHandleHowToUse;


        /// <summary>
        /// ふぉんと
        /// </summary>
        int fontHandleTitle;

        public PageTitle() {

        }

        ~PageTitle() {

        }

        public override void Init() {
            base.Init();
            this.LoadResource();
            fontHandleHowToUse = DX.CreateFontToHandle(null , 25 , 2);
            fontHandleTitle = DX.CreateFontToHandle(null , 125 , 8);
        }

        public override void UpData() {
            base.UpData();

            //menu関連/////////////////////////////////////////

            //menuの選択
            if(keys.Pressed(DX.KEY_INPUT_UP)) {
                PosSelectMenu--;
            }else if(keys.Pressed(DX.KEY_INPUT_DOWN)) {
                PosSelectMenu++;
            }

            //enter押したときの処理
            if(keys.Pressed(DX.KEY_INPUT_RETURN)) {
                switch(this.PosSelectMenu){
                    case 0:
                        pageState = (int)Page.State.GAME;
                        break;
                    case 1:
                        pageState = (int)Page.State.END;
                        break;
                }
            }
            //////////////////////////////////////////////////
            
            //escでおわり
            if(keys.Pressed(DX.KEY_INPUT_ESCAPE)) {
                pageState = (int)Page.State.END;
            }
        
            

        }
                
        public override void Draw() {
            DX.DrawString(0 , 0 , "たいとる" , DX.GetColor(255 , 255 , 0));
            DX.DrawString(0 , 15 , "globaltimer:" + globalTimer.Elapsed , DX.GetColor(255 , 255 , 0));
            DX.DrawString(0 , 30 , "localtimer:" + localTimer.Elapsed , DX.GetColor(255 , 255 , 0));



            //menu関連/////////////////////////////////////////
            DX.DrawStringToHandle(Frame.WindowSizeX - 200 , Frame.WindowSizeY - 100 + 25 * this.PosSelectMenu , "＞" , DX.GetColor(255 , 255 , 0), fontHandleHowToUse);
            DX.DrawStringToHandle(Frame.WindowSizeX - 165 , Frame.WindowSizeY - 100 , "Start" , DX.GetColor(255 , 255 , 0), fontHandleHowToUse);
            DX.DrawStringToHandle(Frame.WindowSizeX - 165 , Frame.WindowSizeY - 70 , "End" , DX.GetColor(255 , 255 , 0), fontHandleHowToUse);
            //////////////////////////////////////////////////
        }

        public override void LoadResource() {
        }

    }
}
