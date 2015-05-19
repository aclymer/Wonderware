using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace Wonderware.Data
{
    public class Transformer
    {
        public String Value;
        public float ScaleX;
        public float X12;
        public float X21;
        public float ScaleY;
        public float TransX;
        public float TransY;

        public Transformer(String p_sValue)
        {
            Value = p_sValue;
            String[] Values = Value.Split(new String[] { " " }, StringSplitOptions.None);
            if (Values.Length != 6)
            {
            }
            try
            {
                ScaleX = System.Convert.ToSingle(Values[0]);
                X12 = System.Convert.ToSingle(Values[1]);
                X21 = System.Convert.ToSingle(Values[2]);
                ScaleY = System.Convert.ToSingle(Values[3]);
                TransX = System.Convert.ToSingle(Values[4]);
                TransY = System.Convert.ToSingle(Values[5]);
            }
            catch
            {
            }
        }

		public Transformer(float transX, float transY)
		{
			ScaleX = 1; X12 = 1; X21 = 1; ScaleY = 1; TransX = transX; TransY = transY;
		}
		
		public Transformer(float scaleX, float x12, float x21, float scaleY, float transX, float transY)
		{
			ScaleX = scaleX; X12 = x12; X21 = x21; ScaleY = scaleY; TransX = transX; TransY = transY;
		}
				
        ~Transformer()
        {
        }

        public MatrixTransform GetMatrixTransform()
        {
            return new MatrixTransform(ScaleX, X21, X12, ScaleY, TransX, TransY);
        }
    }
}
