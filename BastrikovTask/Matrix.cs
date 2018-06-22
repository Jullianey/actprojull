using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BastrikovTask
{
    public class Matrix
    {
         public int[,] TargetMatrix;

        // Классы для решения задачи Коммивояжера
        private static BruteForce bruteForce = new BruteForce();
        private static BranchClassic branchClassic = new BranchClassic();
        private static BranchClassicPlus branchClassicPlus = new BranchClassicPlus();
        private static BranchOleg branchOleg = new BranchOleg();

        // Путь для каждого из методов
        Dictionary<int, int> BruteForceWay;
        Dictionary<int, int> BranchClassicWay;
        Dictionary<int, int> BranchClassicPlusWay;
        Dictionary<int, int> BranchOlegWay;

        // Время для каждого из методов
        long BruteForceTime;
        long BranchClassicTime;
        long BranchClassicPlusTime;
        long BranchOlegTime;

        // Сумма расстояний для каждого из методов
        int BruteForceSum;
        int BranchClassicSum;
        int BranchClassicPlusSum;
        int BranchOlegSum;

        public Matrix() { }

        public void setTargetMatrix(int[,] _some_matrix)
        {
            TargetMatrix = _some_matrix;
        }

        private void BruteForceSolution()
        {
            bruteForce.BruteForceStart(TargetMatrix, 0, out BruteForceSum, out BruteForceWay, out BruteForceTime);
        }

        private void BranchClassicSolution() {
            branchClassic.Start(TargetMatrix, out BranchClassicSum, out BranchClassicWay, out BranchClassicTime, true);
        }

        private void BranchClassicPlusSolution() {
            branchClassicPlus.Start(TargetMatrix, out BranchClassicPlusSum, out BranchClassicPlusWay, out BranchClassicPlusTime, true);
        }

        private void BranchOlegSolution()
        {
          //  branchOleg.StartBranchBuild();
        }

        public string getBruteForceSolutionString()
        {
            BruteForceSolution();

            string solution = "Полный перебор для матрицы " + TargetMatrix.GetLength(0) + "x" + TargetMatrix.GetLength(0) +
                " ,путь : ";

            foreach (var item in BruteForceWay)
            {
                string temp = "(" + item.Key + "," + item.Value + ");";
                solution += temp;
            }

            solution += " сумма расстояний : " + BruteForceSum;
            solution += ", время работы алгоритма : " + BruteForceTime + "ms. .";
            return solution;
        }

        public string getBranchClassicSolutionString(int mode)
        {
            BranchClassicSolution();
            string solution = "";

            if (mode == 0)
            {
                 solution = "Метод ветвей и границ для матрицы " + TargetMatrix.GetLength(0) + "x" + TargetMatrix.GetLength(0) +
                    " ,путь : ";
            }
            else {
                solution = "Метод с объеденением " + TargetMatrix.GetLength(0) + "x" + TargetMatrix.GetLength(0) +
                   " ,путь : ";
            }

            foreach (var item in BranchClassicWay)
            {
                string temp = "(" + item.Key + "," + item.Value + ");";
                solution += temp;
            }

            solution += " сумма расстояний : " + BranchClassicSum;
            solution += ", время работы алгоритма : " + BranchClassicTime + "ms. .";
            
            return solution;
        }

        public string getBranchClassicPlusSolutionString()
        {
            BranchClassicPlusSolution();

            string solution = "Метод ветвей и границ+ для матрицы " + TargetMatrix.GetLength(0) + "x" + TargetMatrix.GetLength(0) +
                " ,путь : ";

            foreach (var item in BranchClassicPlusWay)
            {
                string temp = "(" + item.Key + "," + item.Value + ");";
                solution += temp;
            }

            solution += " сумма расстояний : " + BranchClassicPlusSum;
            solution += ", время работы алгоритма : " + BranchClassicPlusTime + "ms. .";
            return solution;
        }
    }
}
