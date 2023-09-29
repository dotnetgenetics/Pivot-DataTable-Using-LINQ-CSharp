using System.Data;

namespace PivotDataTableUsingLINQCSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataTable dt = new DataTable("StudentTable");
            dt.Columns.Add("StudID", typeof(string));
            dt.Columns.Add("Subject", typeof(string));
            dt.Columns.Add("Score", typeof(decimal));
            dt.Rows.Add(new object[] {
                "1001",
                "English",
                11.22
            });
            dt.Rows.Add(new object[] {
                "1002",
                "English",
                15.00
            });
            dt.Rows.Add(new object[] {
                "1003",
                "English",
                16.25
            });
            dt.Rows.Add(new object[] {
                "1004",
                "English",
                13.50
            });
            dt.Rows.Add(new object[] {
                "1001",
                "Math",
                18.00
            });
            dt.Rows.Add(new object[] {
                "1002",
                "Math",
                18.00
            });
            dt.Rows.Add(new object[] {
                "1003",
                "Math",
                17.00
            });
            dt.Rows.Add(new object[] {
                "1004",
                "Math",
                16.00
            });
            dt.Rows.Add(new object[] {
                "1001",
                "CompProg1",
                17.50
            });
            dt.Rows.Add(new object[] {
                "1002",
                "CompProg1",
                16.00
            });
            dt.Rows.Add(new object[] {
                "1003",
                "CompProg1",
                15.25
            });
            dt.Rows.Add(new object[] {
                "1004",
                "CompProg1",
                18.50
            });
            var query = (from students in dt.AsEnumerable()
                         group students by students.Field<string>("StudID") into g
                         select new
                         {
                             StudID = g.Key,
                             English = g.Where(c => c.Field<string>("Subject") == "English").Sum(c => c.Field<decimal>("Score")),
                             Math = g.Where(c => c.Field<string>("Subject") == "Math").Sum(c => c.Field<decimal>("Score")),
                             CompProg1 = g.Where(c => c.Field<string>("Subject") == "CompProg1").Sum(c => c.Field<decimal>("Score")),
                         }).ToList();

            Console.WriteLine($"StudID\tEnglish\tMath\tCompProg1");
            foreach (var student in query)
            {
                Console.WriteLine($"{student.StudID}\t{student.English.ToString("N")}\t{student.Math.ToString("N")}\t{student.CompProg1.ToString("N")}");
            }
        }
    }
}