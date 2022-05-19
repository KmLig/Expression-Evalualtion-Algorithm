using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn_21880067
{
    public class XL_BieuThuc_InFix
    {
		public static double Tinh(string bieuThuc)
		{
			//tách biểu thức nhập vào thành mảng ký tự
			char[] tokens = bieuThuc.ToCharArray();

			// tạo stack để lưu toán hạng			
			Stack_Double values = new Stack_Double();

			// tạo stack để lưu toán tử			
			Stack_Char operators = new Stack_Char();
			for (int i = 0; i < tokens.Length; i++)
			{
				// bỏ qua khoảng trắng
				if (tokens[i] == ' ')
				{
					continue;
				}

				// nếu token là số, push vào stack cho toán hạng
				if (tokens[i] >= '0' && tokens[i] <= '9')
				{
					StringBuilder sbuf = new StringBuilder();
					// Áp dụng cho toán hạng có nhiều hơn 1 chữ số và dấu chấm thập phân
					while (i < tokens.Length && tokens[i] >= '0' && tokens[i] <= '9' || i < tokens.Length && tokens[i] == '.')
					{
						sbuf.Append(tokens[i++]);
					}
					values.Push(double.Parse(sbuf.ToString()));
					i--; // Vòng while bên trên tăng i dư 1 khi lặp, nên cần giảm 1 để bù lại		
				}

				// nếu token là ngoặc mở '(', push vào Stack operators
				else if (tokens[i] == '(')
				{
					operators.Push(tokens[i]);
				}

				// nếu gặp ngoặc đóng ')', xử lý toàn bộ phép tính trong ngoặc				
				else if (tokens[i] == ')')
				{
					while (operators.Peek() != '(')  // điều kiện chạy đến dấu mở ngoặc '(' ở đầu
					{
						values.Push(applyOp(operators.Pop(), values.Pop(), values.Pop()));
					}
					operators.Pop();
				}

				// Xử lý khi token[i] là toán tử
				else if (tokens[i] == '+' || tokens[i] == '-' || tokens[i] == '*' || tokens[i] == '/' || tokens[i] == '^' || tokens[i] == '!')
				{
					// Xử lý cho số âm, push 0 vào stack toán hạng để thực hiện phép tính 0 - a = -a
					if (tokens[i] == '-' && (i == 0 || (i > 0 && tokens[i - 1] == '(')))
					{
						values.Push(0);						
					}
					// Xử lý giai thừa, push 0 vào stack toán hạng, và khi gọi hàm giai thừa bỏ qua 0
					if (tokens[i] == '!')
					{
						values.Push(0);
					}					
					// Kiểm tra độ ưu tiên của toán tử tại đỉnh stack operators
					// nếu true, tiến hành phép  tính và push kết quả vào stack toán hạng
					while (operators.Count() > 0 && hasPrecedence(tokens[i], operators.Peek()))
					{
						values.Push(applyOp(operators.Pop(), values.Pop(), values.Pop()));
					}

					// push token[i] vào stack toán tử
					operators.Push(tokens[i]);
				}
			}			

			// tiến hành xử lý sau khi push biểu thức vào 2 stack tương ứng
			while (operators.Count() > 0)
			{
				values.Push(applyOp(operators.Pop(), values.Pop(), values.Pop()));
			}
			
			// sau khi tính toán, trả về kết quả của dòng biểu thức nằm tại đỉnh stack values 
			return values.Pop();
		}
		
		// Kiểm tra độ ưu tiên của 2 toán tử
		public static bool hasPrecedence(char op1, char op2)
		{
			if (op2 == '(' || op2 == ')')
			{
				return false;
			}
			if ((op1 == '*' || op1 == '/') && (op2 == '+' || op2 == '-'))
			{
				return false;
			}
			else
			{
				return true;
			}
		}
		// hàm tính giai thừa
		public static double GiaiThua(double n)
		{
			double giaithua = 1;
			for (int i = 2; i <= n; i++)
				giaithua *= i;
			return giaithua;
		}
				
		// thực hiện xử lý theo toán tử tương ứng, trả về kết quả
		public static double applyOp(char op, double b, double a)
		{
			switch (op)
			{
				case '+':
					return a + b;
				case '-':
					return a - b;
				case '*':
					return a * b;
				case '/':
					if (b == 0)
					{
						throw new
						System.NotSupportedException(
							"Cannot divide by zero");
					}
					return a / b;
				case '!':
					return GiaiThua(a);
				case '^':
					return Math.Pow(a, b);
			}
			return 0;
		}
	}
}
