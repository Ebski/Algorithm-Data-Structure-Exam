using Graphs.ExamQuestions._10;
using Graphs.ExamQuestions._11;
using Graphs.ExamQuestions._12;

namespace Graphs
{
    public class Program
    {
        public static void Main(string[] args)
        {
            UndirectedGraph examQuestion10 = new UndirectedGraph();
            examQuestion10.showDepthFirstAndBreathFirstSearches();

            DirectedGraph examQuestion11 = new DirectedGraph();
            examQuestion11.showCycleDetection();

            WeigthedGraph examQuestion12 = new WeigthedGraph();
            examQuestion12.findShortestPath();

            while (true)
            {
                
            }
        }
    }
}
