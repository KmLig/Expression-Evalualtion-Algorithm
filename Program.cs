using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_21880067
{
	public class Program
	{
		public static void Main(string[] args)
        {
			string deskDir = Environment.CurrentDirectory;            
            string[] dongBieuThuc = LuuTruDuLieu.GetData(deskDir);
            LuuTruDuLieu.ReadAndPrintLines(dongBieuThuc);
            LuuTruDuLieu.WriteDataLines(deskDir, dongBieuThuc);            
		}
    }
}
