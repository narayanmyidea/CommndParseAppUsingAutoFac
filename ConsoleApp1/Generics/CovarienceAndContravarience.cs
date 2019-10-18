using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;


namespace Generics
{
   
    class Covarience
    {
        
        public static void Entry()
        {
            MyButton bton=new MyButton();
            bton.keyEventHandler += Bton_keyEventHandler;
            bton.mouseEventHandle += Bton_keyEventHandler;

            bton.DoAction();
        }

        private static void Bton_keyEventHandler(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        public class MyButton
        {
            public event EventHandler<MouseEventArgs> mouseEventHandle;
            public event EventHandler<KeyEventArgs> keyEventHandler;

            public  void DoAction()
            {
                mouseEventHandle(this,new MouseEventArgs());
                keyEventHandler(this, new KeyEventArgs());
            }
        }
        
        public class EventArgs
        {
            
        }
        public class MouseEventArgs: EventArgs
        {

        }
        public class KeyEventArgs : EventArgs
        {

        }

    }

    
}
