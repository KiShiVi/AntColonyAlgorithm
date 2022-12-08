using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using MathParserSpace;
namespace BeeColonies
{
    class Bee
    {
        public double x;
        public double y;
        public double z;
        public Random random;
        public Bee(double x1, double x2,double y1, double y2,string polynomial,double diapXmin,double diapXmax,double diapYmin,double diapYmax)
        {
            random = new Random();
            if (x1 < diapXmin)
                x1 = diapXmin;
            if (x2 > diapXmax)
                x2 = diapXmax;
            if (y1 < diapYmin)
                y1 = diapYmin;
            if (y2 > diapYmax)
                y2 = diapYmax;
            x = (x2 - x1) * random.NextDouble() + x1;
            y = (y2 - y1) * random.NextDouble() + y1;
            z = MathParser.calculate(x, y, polynomial);
        }
    }
    class Colonies:IComparer<Bee>
    {

        public List<Bee> list;
        private double xMin, xMax, yMin, yMax, rangeOfValuesX, rangeOfValuesY;
        private string polynomial;
        private int counBeeVip, countStandardBee, countBee, vip, standard;
        public Colonies(int num, double xMin, double xMax, double yMin, double yMax, string polynomial, int counBeeVip, int countStandardBee, int vip, int standard, double rangeOfValuesX, double rangeOfValuesY)
        {
            this.xMin = xMin;
            this.xMax = xMax;
            this.yMin = yMin;
            this.yMax = yMax;
            this.polynomial = polynomial;
            this.counBeeVip = counBeeVip;
            this.countStandardBee = countStandardBee;
            this.countBee = num - (counBeeVip + countStandardBee);
            this.vip = vip;
            this.rangeOfValuesX = rangeOfValuesX;
            this.rangeOfValuesY = rangeOfValuesY;
            this.standard = standard - vip;
            list = new List<Bee>();
            for(int i = 0; i < num; i++)
            {
                list.Add(new Bee(xMin, xMax, yMin, yMax, polynomial,xMin,xMax,yMin,yMax));
            }
            list.Sort(Compare);
            list.RemoveRange(counBeeVip + countStandardBee, countBee);
        }
        public void OneIterationOfTheAlgorithm()// диапазон 
        {
            for (int i = 0; i < vip; i++)
                for (int j = 0; j < counBeeVip; j++)
                    list.Add(new Bee((list[i].x - rangeOfValuesX), (list[i].x + rangeOfValuesX), (list[i].y - rangeOfValuesY), (list[i].y + rangeOfValuesY), polynomial, xMin, xMax, yMin, yMax));

            for (int i = vip; i < vip + standard; i++)
                for (int j = 0; j < countStandardBee; j++)

                    list.Add(new Bee((list[i].x - rangeOfValuesX), (list[i].x + rangeOfValuesX), (list[i].y - rangeOfValuesY), (list[i].y + rangeOfValuesY), polynomial, xMin, xMax, yMin, yMax));
            for (int i = 0; i < countBee; i++)

                list.Add(new Bee(xMin, xMax, yMin, yMax, polynomial, xMin, xMax, yMin, yMax));
            list.Sort(Compare);
        }
        public int Compare(Bee bee1, Bee bee2)
        {
            if (bee1.z < bee2.z)
                return -1;
            if (bee1.z >= bee2.z)
                return 1;
            return 0;
        }

    }
}
