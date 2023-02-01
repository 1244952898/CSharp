using System;
using System.Collections.Generic;
using System.Text;

namespace DesignModel.BuilderPattern
{
    /*
     * 将一个复杂的构建与其表示相分离，使得同样的构建过程可以创建不同的表示。
     * JAVA 中的 StringBuilder。
     *      
     */

    /// <summary>
    /// 将一个复杂的对象的构建与表示分离，使得同样的构建过程可以创建不同的表示
    /// </summary>
    internal class BuilderPatternDemo
    {
        public static void main()
        {
            MealBuilder mealBuilder = new MealBuilder();

            Meal vegMeal = mealBuilder.PrepareVegMeal();
            vegMeal.ShowItems();
            Console.WriteLine("Total Cost: " + vegMeal.GetPrice());

            Meal nonVegMeal = mealBuilder.prepareNonVegMeal();
            nonVegMeal.ShowItems();
            Console.WriteLine("Total Cost: " + nonVegMeal.GetPrice());
        }
    }
}
