using System;
using System.Collections.Generic;
using Graphs.ExamQuestions._10;
using Graphs.Services.Algorithms;
using Graphs.Services.Model;

namespace Graphs
{
    public class Program
    {
        public static void Main(string[] args)
        {
            UndirectedGrap examQuestion10 = new UndirectedGrap();
            examQuestion10.showDepthFirstAndBreathFirstSearches();
        }
    }
}
