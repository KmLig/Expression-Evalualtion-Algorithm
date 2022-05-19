using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_21880067
{
    public class LuuTruDuLieu
    {
        public static string[] GetData(string deskDir)
        {
            string filePath_Read = $"{deskDir}\\BIEUTHUC.INP";
            StreamReader reader = new StreamReader(filePath_Read);
            string stringData = reader.ReadToEnd();
            reader.Close();
            string[] dongBieuThuc = stringData.Split('\n');

            return dongBieuThuc;
        }

        public static void ReadAndPrintLines(string[] dongBieuThuc)
        {            
            Console.WriteLine("Doc du lieu tu file BIEUTHUC.INP");
            for (int i = 0; i < dongBieuThuc.Length; i++)
            {
                Console.WriteLine(dongBieuThuc[i]);
            }
            Console.WriteLine("====================================================");
        }
        public static void WriteDataLines(string deskDir, string[] dongBieuThuc)
        {
            StreamWriter writer = new StreamWriter($"{deskDir}\\KETQUA.OUT");
            Console.WriteLine("Ghi du lieu vao file KETQUA.OUT");
            double result;
            for (int i = 1; i < dongBieuThuc.Length; i++)
            {
                result = XL_BieuThuc_InFix.Tinh(dongBieuThuc[i]);
                Console.WriteLine($"Ket qua bieu thuc {i} la: {result}");
                writer.WriteLine(result);
            }
            writer.Close();
            Console.WriteLine("====================================================");
        }
    }
}
