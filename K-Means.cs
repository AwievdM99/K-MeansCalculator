using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MGL381_Calculator
{
    internal class K_Means
    {
        public static List<float> xCoordinates = new List<float>();
        public static List<float> xCoordinatePlaceHolder = new List<float>();
        public static List<float> OldC1CoordinatePlaceHolder = new List<float>();
        public static List<float> yCoordinates = new List<float>();
        public static List<float> yCoordinatePlaceHolder = new List<float>();
        public static List<float> OldC2CoordinatePlaceHolder = new List<float>();
        public static List<float> xHeatMapPlaceHolder = new List<float>();
        public static List<float> yHeatMapPlaceHolder = new List<float>();
        public static List<float> C1 = new List<float>();
        public static List<float> C2 = new List<float>();
        public static int seriesLenth;
        public static int cRound;
        public static int CoordinateRound;
        public static void StartKmeans()
        {
            int count = 1;
            Console.Clear();
            ClearAll();
            Console.Clear();
            Console.WriteLine("To what must centroids be rounded to?");
            cRound = int.Parse(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("To what must coordinates be rounded to?");
            CoordinateRound = int.Parse(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("Input series lenth.");
            seriesLenth = int.Parse(Console.ReadLine());
            PopulateX();
            PopulateY();
            PopulateC1();
            PopulateC2();
            WriteTable();
            WriteC();
            while (true) 
            {
                Console.WriteLine();
                Console.WriteLine("___________________________________________");
                Console.WriteLine("T - " + count);
                TableGen();
                DistanceMapGen();
                UpdateC();
                WriteC();
                ClearPlaceHolders();
                count++;
                if ((OldC1CoordinatePlaceHolder == C1) && (OldC2CoordinatePlaceHolder == C2))
                {
                    Console.WriteLine();
                    Console.WriteLine("___________________________________________");
                    Console.WriteLine("T - " + count);
                    TableGen();
                    DistanceMapGen();
                    UpdateC();
                    WriteC();
                    ClearPlaceHolders();
                    count++;
                    Console.WriteLine();
                    Console.WriteLine("___________________________________________");
                    Console.WriteLine("T - " + count);
                    TableGen();
                    DistanceMapGen();
                    UpdateC();
                    WriteC();
                    ClearPlaceHolders();
                    Console.WriteLine();
                    Console.WriteLine("___________________________________________");
                    Console.WriteLine("K-Means has finished!");
                    goto end;
                }
            }
            end:
            Console.ReadKey();
        }
        public static string DecimalTest(string k)
        {
            string l = "";
            for (int i = 0; i < k.Length; i++)
            {
                if (k[i] == '.')
                {
                    l = l + ",";
                }
                else {l = l + k[i];}             
            }
            return l;
        }
        public static void PopulateX()
        {
            for (int i = 0; i < seriesLenth; i++)
            {
                Console.Clear();
                Console.WriteLine("Enter x value " + (i + 1));
                xCoordinates.Add(float.Parse(DecimalTest(Console.ReadLine())));
            }
            Console.Clear();
        }
        public static void PopulateY()
        {
            for (int i = 0; i < seriesLenth; i++)
            {
                Console.Clear();
                Console.WriteLine("Enter y value " + (i + 1));
                yCoordinates.Add(float.Parse(DecimalTest(Console.ReadLine())));
            }
            Console.Clear();
        }
        public static void PopulateC1()
        {
            Console.Clear();
            Console.WriteLine("Enter C1 x value.");
            C1.Add(float.Parse(DecimalTest(Console.ReadLine())));
            Console.Clear();
            Console.WriteLine("Enter C1 y value.");
            C1.Add(float.Parse(DecimalTest(Console.ReadLine())));
            Console.Clear();
        }
        public static void PopulateC2()
        {
            Console.Clear();
            Console.WriteLine("Enter C2 x value.");
            C2.Add(float.Parse(DecimalTest(Console.ReadLine())));
            Console.Clear();
            Console.WriteLine("Enter C2 y value.");
            C2.Add(float.Parse(DecimalTest(Console.ReadLine())));
            Console.Clear();
        }
        public static void WriteTable()
        {
            Console.Clear();
            Console.WriteLine("T - i");
            Console.WriteLine();
            Console.Write("|" + "X" + "|" + "\t");
            for (int i = 0; i < xCoordinates.Count; i++)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(Math.Round(xCoordinates[i],CoordinateRound) + "\t");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write('|' + "\t");
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.Write("|" + "Y" + "|" + "\t");
            for (int i = 0; i < yCoordinates.Count; i++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(Math.Round(yCoordinates[i], CoordinateRound) + "\t");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write('|' + "\t");
            }
        }
        public static void TableGen()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("|" + "X" + "|" + "\t");
            for (int i = 0; i < xCoordinates.Count; i++)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(Math.Round(CalcNewX(xCoordinates[i], yCoordinates[i]),CoordinateRound) + "\t");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write('|' + "\t");
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.Write("|" + "Y" + "|" + "\t");
            for (int i = 0; i < yCoordinates.Count; i++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(Math.Round(CalcNewY(xCoordinates[i], yCoordinates[i]), CoordinateRound) + "\t");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write('|' + "\t");
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void DistanceMapGen()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("|" + "X" + "|" + "\t");
            for (int i = 0; i < xCoordinates.Count; i++)
            {
                Console.Write(CalcDistanceMapX(xCoordinatePlaceHolder[i], yCoordinatePlaceHolder[i]) + "\t");
                Console.Write('|' + "\t");
            }
            Console.WriteLine();
            Console.Write("|" + "Y" + "|" + "\t");
            for (int i = 0; i < yCoordinates.Count; i++)
            {
                Console.Write(CalcDistanceMapY(xCoordinatePlaceHolder[i], yCoordinatePlaceHolder[i]) + "\t");
                Console.Write('|' + "\t");
            }
        }
        public static float CalcNewX(float x, float y)
        {
            double z;
            z = Math.Sqrt(Math.Pow(x - C1[0],2) + Math.Pow(y - C1[1], 2));
            xCoordinatePlaceHolder.Add(float.Parse(z.ToString()));
            return float.Parse(z.ToString());
        }
        public static float CalcNewY(float x, float y)
        {
            double z;
            z = Math.Sqrt(Math.Pow(x - C2[0], 2) + Math.Pow(y - C2[1], 2));
            yCoordinatePlaceHolder.Add(float.Parse(z.ToString()));
            return float.Parse(z.ToString());
        }
        public static int CalcDistanceMapX(float x, float y)
        {
            int z;
            if (x < y)
            {
                z = 1;
            }
            else { z = 0; }
            xHeatMapPlaceHolder.Add(z);
            return z;
        }
        public static int CalcDistanceMapY(float x, float y)
        {
            int z;
            if (x > y)
            {
                z = 1;
            }
            else { z = 0; }
            yHeatMapPlaceHolder.Add(z);
            return z;
        }
        public static void ClearAll()
        {
            xCoordinates.Clear();
            yCoordinates.Clear();
            xCoordinatePlaceHolder.Clear();
            yCoordinatePlaceHolder.Clear();
            xHeatMapPlaceHolder.Clear();
            yHeatMapPlaceHolder.Clear();
            C1.Clear();
            C2.Clear();
        }
        public static void ClearPlaceHolders()
        {
            xCoordinatePlaceHolder.Clear();
            yCoordinatePlaceHolder.Clear();
            xHeatMapPlaceHolder.Clear();
            yHeatMapPlaceHolder.Clear();
        }
        public static void UpdateC()
        {
            int xCount = 0;
            int yCount = 0;
            float xPositiveCount = 0;
            float yPositiveCount = 0;
            float xNegativeCount = 0;
            float yNegativeCount = 0;
            for (int i = 0; i < xHeatMapPlaceHolder.Count; i++)
            {
                OldC1CoordinatePlaceHolder = C1;
                OldC2CoordinatePlaceHolder = C2;
                if (xHeatMapPlaceHolder[i] == 1)
                {
                    xPositiveCount = xPositiveCount + xCoordinates[i];
                    xCount++;
                }
                if (xHeatMapPlaceHolder[i] == 0)
                {
                    xNegativeCount = xNegativeCount + yCoordinates[i];
                }
            }
            for (int i = 0; i < yHeatMapPlaceHolder.Count; i++)
            {
                if (yHeatMapPlaceHolder[i] == 1)
                {
                    yPositiveCount = yPositiveCount + xCoordinates[i];
                    yCount++;
                }
                if (yHeatMapPlaceHolder[i] == 0)
                {
                    yNegativeCount = yNegativeCount + yCoordinates[i];
                }
            }
            double z = xPositiveCount / xCount;
            Math.Round(z, cRound);
            C1[0] = float.Parse(z.ToString());
            z = yNegativeCount / xCount;
            Math.Round(z, cRound);
            C1[1] = float.Parse(z.ToString());
            z = yPositiveCount / yCount;
            Math.Round(z, cRound);
            C2[0] = float.Parse(z.ToString());
            z = xNegativeCount / yCount;
            Math.Round(z, cRound);
            C2[1] = float.Parse(z.ToString());
        }
        public static void WriteC()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("|" + "C1" + "|" + "\t");
            for (int i = 0; i < C1.Count; i++)
            {
                if (i == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                if (i == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                Console.Write(Math.Round(C1[i], cRound) + "\t");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write('|' + "\t");
            }
            Console.WriteLine();
            Console.Write("|" + "C2" + "|" + "\t");
            for (int i = 0; i < C2.Count; i++)
            {
                if (i == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                if (i == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                Console.Write(Math.Round(C2[i], cRound) + "\t");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write('|' + "\t");
            }
        }
    }
}
