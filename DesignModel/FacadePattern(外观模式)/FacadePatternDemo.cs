using System;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.FacadePattern
{
    /*
     * 隐藏系统的复杂性，并向客户端提供了一个客户端可以访问系统的接口。
     * 1、去医院看病，可能要去挂号、门诊、划价、取药，很复杂，如果有提供接待人员，只让接待人员来处理，就很方便。 
     * 2、JAVA 的三层开发模式。
     */
    internal class FacadePatternDemo
    {
        public static void main1()
        {
            ShapeMaker shapeMaker = new ShapeMaker();

            shapeMaker.drawCircle();
            shapeMaker.drawRectangle();
            shapeMaker.drawSquare();
        }
    }
}
